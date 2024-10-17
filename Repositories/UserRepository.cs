using Microsoft.EntityFrameworkCore;
using RunningGroupWebApp.Data;
using RunningGroupWebApp.Models;

namespace RunningGroupWebApp.Repositories;

public class UserRepository : IUserRepository
{
	private readonly AppDbContext _dbContext;

	public UserRepository(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	
	public async Task<IEnumerable<AppUser>> GetAllUser()
	{
		return await _dbContext.Users.ToListAsync();
	}

	public async Task<AppUser> GetUserById(string id)
	{
		return await _dbContext.Users.FindAsync(id);
	}


	public bool Add(AppUser user)
	{
		throw new NotImplementedException();
	}

	public bool Delete(AppUser user)
	{
		throw new NotImplementedException();
	}
	
	public bool Update(AppUser user)
	{
		_dbContext.Update(user);
		return Save();
	}

	public bool Save()
	{
		var saved = _dbContext.SaveChanges();
		return saved > 0;
	}

}