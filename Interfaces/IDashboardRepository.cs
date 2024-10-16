using RunningGroupWebApp.Models;

namespace RunningGroupWebApp.Interfaces;

public interface IDashboardRepository
{
	Task<List<Race>> GetAllUserRaces();
	Task<List<Club>> GetAllUserClubs();
}