namespace RunningGroupWebApp.Interfaces;

public interface IRaceRepository
{
	Task<IEnumerable<Race>> GetAllRacesAsync();
	Task<Race> GetRaceByIdAsync(int id);
	Task<Race> GetRaceByIdNoTrackingAsync(int id);
	Task<IEnumerable<Race>> GetRacesByCityAsync(string city);

	bool Add(Race race);
	bool Update(Race race);
	bool Delete(Race race);
	bool Save();
}