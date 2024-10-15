using Microsoft.EntityFrameworkCore;
using RunningGroupWebApp.Data;
using RunningGroupWebApp.Interfaces;
using RunningGroupWebApp.Models;

namespace RunningGroupWebApp.Repositories;

public class ClubRepository : IClubRepository
{
	private readonly AppDbContext _db;
	
	public ClubRepository(AppDbContext dbContext)
	{
		_db = dbContext;
	}
	
	public bool Add(Club club)
	{
		_db.Add(club);
		return Save();
	}

	public bool Delete(Club club)
	{
		_db.Remove(club);
		return Save();
	}

	public async Task<IEnumerable<Club>> GetAllClubsAsync()
	{
		return await _db.Clubs.ToListAsync();
	}

	public async Task<Club> GetClubByIdAsync(int id)
	{
		return await _db.Clubs.Include(c => c.Address).FirstOrDefaultAsync(c => c.Id == id);
	}

	public async Task<Club> GetClubByIdNoTrackingAsync(int id)
	{
		return await _db.Clubs.Include(c => c.Address).AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
	}

	public async Task<IEnumerable<Club>> GetClubsByCityAsync(string city)
	{	
		return await _db.Clubs.Where(c => c.Address.City == city).ToListAsync();
	}

	public bool Save()
	{
		var savedEntries = _db.SaveChanges();
		return savedEntries > 0;
	}

	public bool Update(Club update)
	{
		if (update.AddressId.HasValue && update.Address != null)
		{
			_db.Entry(update.Address).State = EntityState.Modified;
		}

		_db.Clubs.Update(update);
		return Save();
	}
}