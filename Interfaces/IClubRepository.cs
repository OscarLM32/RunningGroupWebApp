using RunningGroupWebApp.Models;

namespace RunningGroupWebApp.Interfaces;

public interface IClubRepository
{
	Task<IEnumerable<Club>> GetAllClubsAsync();
	Task<Club> GetClubByIdAsync(int id);
	Task<Club> GetClubByIdNoTrackingAsync(int id);
	Task<IEnumerable<Club>> GetClubsByCityAsync(string city);
	
	
	bool Add(Club club);
	bool Update(Club club);
	bool Delete(Club club);
	bool Save();
}