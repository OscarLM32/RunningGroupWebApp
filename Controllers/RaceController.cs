
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunningGroupWebApp.Data;
using RunningGroupWebApp.Helpers.Extensions;
using RunningGroupWebApp.Interfaces;
using RunningGroupWebApp.ViewModels;

namespace RunningGroupWebApp.Controllers
{
	public class RaceController : Controller
	{
		private readonly IRaceRepository _repository;
		private readonly IPhotoService _photoService;

		public RaceController(IRaceRepository repository, IPhotoService photoService)
		{
			_repository = repository;
			_photoService = photoService;
		}

		public async Task<IActionResult> Index()
		{
			var races = await _repository.GetAllRacesAsync();
			return View(races);
		}
		
		public async Task<IActionResult> Detail(int id)
		{
			Race? race = await _repository.GetRaceByIdAsync(id);
			return View(race);
		}
		
		public IActionResult Create()
		{
			return View();
		}
		
		[HttpPost]
		public async Task<IActionResult> Create(VMCreateRace createRace)
		{
			if (!ModelState.IsValid)
			{
				ModelState.AddModelError("", "Photo upload failed");
				return View(createRace);
			}

			var result = await _photoService.AddPhotoAsync(createRace.Image);
			Race race = new()
			{
				Title = createRace.Title,
				Description = createRace.Description,
				Image = result.Url.ToString(),
				RaceCategory = createRace.RaceCategory,
				Address = new()
				{
					Street = createRace.Address.Street,
					City = createRace.Address.City,
					State = createRace.Address.State
				}
			};
			_repository.Add(race);
			return RedirectToAction("Index");
		}


		public async Task<IActionResult> Edit(int id)
		{
			var race = await _repository.GetRaceByIdAsync(id);
			if (race == null)
			{
				return RedirectToAction("Index");
			}

			return View(race.ToVMEditRace());
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, VMEditRace editRace)
		{
			if (!ModelState.IsValid)
			{
				return View(editRace);
			}

			var race = await _repository.GetRaceByIdNoTrackingAsync(id);
			if (race == null)
			{
				ModelState.AddModelError("", "The race to be updated could not be found");
				return RedirectToAction("Index");
			}

			race = editRace.ToRace(race);

			if (editRace.Image != null)
			{
				try
				{
					var imgPublicId = Path.GetFileNameWithoutExtension(race.Image);
					var result = await _photoService.AddPhotoAsync(editRace.Image);

					await _photoService.DeletePhotoAsync(imgPublicId);
					race.Image = result.Url.ToString();
				}
				catch
				{
					ModelState.AddModelError("", "Error deleting or uploading the photo");
					return View(editRace);
				}
			}

			_repository.Update(race);

			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Delete(int id)
		{
			var race = await _repository.GetRaceByIdNoTrackingAsync(id);
			if (race == null)
			{
				return View("Error");
			}

			return View(race);
		}

		[HttpPost, ActionName("DeleteRace")]
		public async Task<IActionResult> DeleteRace(int id)
		{
			Race race = await _repository.GetRaceByIdAsync(id);
			if (race == null)
			{
				return View("Error");
			}

			await _photoService.DeletePhotoAsync(Path.GetFileNameWithoutExtension(race.Image));

			_repository.Delete(race);
			return RedirectToAction("Index");
		}
	}
}