
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using RunningGroupWebApp.Repositories;
using RunningGroupWebApp.ViewModels;

namespace RunningGroupWebApp.Controllers;

public class UserController : Controller
{
	private readonly IUserRepository _userRepository;

	public UserController(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}
	
	[HttpGet("Users")]
	public async Task<IActionResult> Index()
	{
		var results = await _userRepository.GetAllUser();
		List<VMUser> users = new();
		
		foreach(var user in results)
		{
			users.Add(new VMUser()
			{
				Id = user.Id,
				UserName = user.UserName,
				Pace = user.Pace,
				Mileage = user.Mileage
			});
		}
		
		return View(users);
	}
	
	public async Task<IActionResult> Detail(string id)
	{
		var user = await _userRepository.GetUserById(id);
		if(user == null)
		{
			return RedirectToAction("Index");
		}
		
		var userDetails = new VMUserDetails()
		{
			Id = user.Id,
			UserName = user.UserName,
			Pace = user.Pace,
			Mileage = user.Mileage
		};
		
		return View(userDetails);
	}
}