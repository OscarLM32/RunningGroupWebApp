using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RunningGroupWebApp.Data;
using RunningGroupWebApp.Helpers.Extensions;
using RunningGroupWebApp.Interfaces;
using RunningGroupWebApp.Repositories;
using RunningGroupWebApp.ViewModels;

namespace RunningGroupWebApp.Controllers;

public class DashboardController : Controller
{
	private readonly IDashboardRepository _dashboardRepository;
	private readonly IUserRepository _userRepository;
	private readonly IHttpContextAccessor _contextAccessor;
	private readonly IPhotoService _photoService;

	public DashboardController(IDashboardRepository repository, IUserRepository userRepository,IHttpContextAccessor contextAccessor, IPhotoService photoService)
	{
		_dashboardRepository = repository;
		_userRepository = userRepository;
		_contextAccessor = contextAccessor;
		_photoService = photoService;
	}
	
	public async Task<IActionResult> Index()
	{
		var userRaces = await _dashboardRepository.GetAllUserRaces();
		var userClubs = await _dashboardRepository.GetAllUserClubs();
		
		var dashboardVM = new VMDashboard()
		{
			Clubs = userClubs,
			Races = userRaces
		};
		
		return View(dashboardVM);
	}
	
	public async Task<IActionResult> EditUserProfile()
	{
		var currentUserId = _contextAccessor.HttpContext.User.GetUserId();
		var user = await _userRepository.GetUserById(currentUserId);
		
		if(user == null) return View("Error");
		var editUser = new VMEditUser()
		{
			Pace = user.Pace,
			Mileage = user.Mileage,
			ProfileImageUrl = user.ProfileImageUrl,
			City = user.City,
			State = user.State
		};
		
		return View(editUser);
	}
	
	[HttpPost]
	public async Task<IActionResult> EditUserpRofile(VMEditUser editUser)
	{
		if(!ModelState.IsValid)
		{
			ModelState.AddModelError("", "Failed to update user profile");
			return View(editUser);
		}
		
		var user = await _userRepository.GetUserNoTrackingById(_contextAccessor.HttpContext.User.GetUserId());

		user.Id = user.Id;
		user.Pace = editUser.Pace != null ? editUser.Pace : user.Pace;
		user.Mileage = editUser.Mileage != null ? editUser.Mileage : user.Mileage;
		user.City = editUser.City != null ? editUser.City : user.City;
		user.State = editUser.State != null ? editUser.State : user.State;

		if(editUser.Image != null)
		{	
			try
			{
				var imgPublicId = Path.GetFileNameWithoutExtension(user.ProfileImageUrl);
				var result = await _photoService.AddPhotoAsync(editUser.Image);

				await _photoService.DeletePhotoAsync(imgPublicId);
				user.ProfileImageUrl = result.Url.ToString();
			}
			catch
			{
				ModelState.AddModelError("", "Error deleting or uploading the photo");
				return View(editUser);
			}
		}
		
		_userRepository.Update(user);
		return RedirectToAction("Index");
	}
}