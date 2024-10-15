using Microsoft.EntityFrameworkCore;
using RunningGroupWebApp.Data;
using RunningGroupWebApp.Interfaces;

namespace RunningGroupWebApp.Repositories;

public class RaceRepository : IRaceRepository
{
	private readonly AppDbContext _db;

	public RaceRepository(AppDbContext dbContext)
	{
		_db = dbContext;
	}
	
	
	public bool Add(Race race)
	{
		_db.Add(race);
		return Save();
	}

	public bool Delete(Race race)
	{
		_db.Remove(race);
		return Save();
	}

	public async Task<IEnumerable<Race>> GetAllRacesAsync()
	{
		return await _db.Races.ToListAsync(); 
	}

	public async Task<Race> GetRaceByIdAsync(int id)
	{
		return await _db.Races.Include(r => r.Address).FirstOrDefaultAsync(r => r.Id == id);
	}

	public async Task<Race> GetRaceByIdNoTrackingAsync(int id)
	{
		return await _db.Races.Include(r => r.Address).AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
	}

	public async Task<IEnumerable<Race>> GetRacesByCityAsync(string city)
	{
		return await _db.Races.Where(r => r.Address.City == city).ToListAsync();
	}

	public bool Save()
	{
		var savedEntries = _db.SaveChanges();
		return savedEntries > 0;
	}

	public bool Update(Race race)
	{
		_db.Races.Update(race);
		return Save();
	}
}