using System.Diagnostics;
using System.Globalization;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RunningGroupWebApp.Helpers;
using RunningGroupWebApp.Interfaces;
using RunningGroupWebApp.Models;
using RunningGroupWebApp.ViewModels;

namespace RunningGroupWebApp.Controllers;

public class HomeController : Controller
{
	private readonly ILogger<HomeController> _logger;
	private readonly IClubRepository _clubRepository;
	private readonly IRaceRepository _raceRepository;

	public HomeController(ILogger<HomeController> logger, IClubRepository clubRepository, IRaceRepository raceRepository)
	{
		_logger = logger;
		_clubRepository = clubRepository;
		_raceRepository = raceRepository;
	}

	public async Task<IActionResult> Index()
	{
		var ipInfo = new IpInfo();
		var vmHome = new VMHome();
		
		try
		{
			string url = "https://ipinfo.io";
			var info = await new HttpClient().GetStringAsync(url);	
			ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);
			RegionInfo myRegionInfo = new RegionInfo(ipInfo.Country);
			ipInfo.Country = myRegionInfo.EnglishName;
			vmHome.City = ipInfo.City;
			vmHome.State = ipInfo.Region;
			if(vmHome.City != null)
			{
				vmHome.Clubs = await _clubRepository.GetClubsByCityAsync(vmHome.City);
			}
			return View(vmHome);
		}
		catch(Exception ex)
		{
			vmHome.Clubs = null;
		}
		
		return View(vmHome);
	}

	public IActionResult Privacy()
	{
		return View();
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}
