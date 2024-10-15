

using Microsoft.AspNetCore.Mvc;
using RunningGroupWebApp.Helpers.Extensions;
using RunningGroupWebApp.Interfaces;
using RunningGroupWebApp.Models;
using RunningGroupWebApp.ViewModels;

namespace RunningGroupWebApp.Controllers
{
	public class ClubController : Controller
	{
		private readonly IClubRepository _repository;
		private readonly IPhotoService _photoService;

		public ClubController(IClubRepository repository, IPhotoService photoService)
		{
			_repository = repository;
			_photoService = photoService;
		}
		
		public async Task<IActionResult> Index()
		{
			var clubs = await _repository.GetAllClubsAsync();
			return View(clubs);
		}
		
		public async Task<IActionResult> Detail(int id)
		{
			Club? club = await _repository.GetClubByIdAsync(id);
			return View(club); 
		}
		
		
		public IActionResult Create()
		{
			return View();
		}
		
		[HttpPost]
		public async Task<IActionResult> Create(VMCreateClub createClub)
		{
			if(!ModelState.IsValid)
			{
				ModelState.AddModelError("", "Photo upload failed");
				return View(createClub);
			}
			
			var result = await _photoService.AddPhotoAsync(createClub.Image);
			Club club = new()
			{
				Title = createClub.Title,
				Description = createClub.Description,
				Image = result.Url.ToString(),
				ClubCategory = createClub.ClubCategory,
				Address = new()
				{
					Street = createClub.Address.Street,
					City = createClub.Address.City,
					State = createClub.Address.State
				}
			};
			_repository.Add(club);
			return RedirectToAction("Index");
		}
		
		public async Task<IActionResult> Edit(int id)
		{
			var club = await _repository.GetClubByIdAsync(id);
			if(club == null)
			{
				return RedirectToAction("Index");
			}
			
			return View(club.ToVMEditClub());
		}
		
		[HttpPost]
		public async Task<IActionResult> Edit(int id, VMEditClub editClub)
		{
			if(!ModelState.IsValid)
			{
				return View(editClub);
			}
			
			var oldClub = await _repository.GetClubByIdNoTrackingAsync(id);
			if(oldClub == null)
			{
				ModelState.AddModelError("", "The club to be updated could not be found");
				return RedirectToAction("Index");
			}
		
			
			Club club = editClub.ToClub(oldClub);

			if(editClub.Image != null)
			{
				try
				{
					var imgPublicId = Path.GetFileNameWithoutExtension(oldClub.Image);
					var result = await _photoService.AddPhotoAsync(editClub.Image);
					
					await _photoService.DeletePhotoAsync(imgPublicId);
					club.Image = result.Url.ToString();
				}
				catch
				{
					ModelState.AddModelError("", "Error deleting or uploading the photo");
					return View(editClub);
				}
			}
			
			_repository.Update(club);
			
			return RedirectToAction("Index");
		}
		
		
		public async Task<IActionResult> Delete(int id)
		{
			var club = await _repository.GetClubByIdNoTrackingAsync(id);
			if(club == null)
			{
				return View("Error");
			}
			
			return View(club);
		}
		
		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteClub(int id)
		{
			Club club = await _repository.GetClubByIdAsync(id);
			if(club == null)
			{
				return View("Error");
			}
			
			await _photoService.DeletePhotoAsync(Path.GetFileNameWithoutExtension(club.Image));
			
			_repository.Delete(club);
			return RedirectToAction("Index");
		}
	}
}

