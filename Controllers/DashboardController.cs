using Microsoft.AspNetCore.Mvc;
using RunningGroupWebApp.Data;
using RunningGroupWebApp.Interfaces;
using RunningGroupWebApp.ViewModels;

namespace RunningGroupWebApp.Controllers;

public class DashboardController : Controller
{
	private readonly IDashboardRepository _dashboardRepository;

	public DashboardController(IDashboardRepository repository)
	{
		_dashboardRepository = repository;
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
}