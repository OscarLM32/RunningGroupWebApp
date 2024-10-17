using RunningGroupWebApp.Data;
using RunningGroupWebApp.Helpers.Extensions;
using RunningGroupWebApp.Interfaces;
using RunningGroupWebApp.Models;

namespace RunningGroupWebApp.Repositories;

public class DashboardRepository : IDashboardRepository
{
	private readonly AppDbContext _dbContext;
	private readonly IHttpContextAccessor _httpContextAccessor;

	public DashboardRepository(AppDbContext context, IHttpContextAccessor httpContextAccessor)
	{
		_dbContext = context;
		_httpContextAccessor = httpContextAccessor;
	}
	
	public async Task<List<Club>> GetAllUserClubs()
	{
		var currentUser = _httpContextAccessor.HttpContext?.User.GetUserId();
		var userClubs = _dbContext.Clubs.Where(c => c.AppUserId == currentUser);
		return userClubs.ToList();
	}

	public async Task<List<Race>> GetAllUserRaces()
	{
		var currentUser = _httpContextAccessor.HttpContext?.User.GetUserId();
		var userRaces = _dbContext.Races.Where(r => r.AppUserId == currentUser);
		return userRaces.ToList();
	}
}