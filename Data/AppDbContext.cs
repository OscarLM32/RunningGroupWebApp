using Microsoft.EntityFrameworkCore;
using RunningGroupWebApp.Models;

namespace RunningGroupWebApp.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) 
			:base(options)
		{
			
		}
		
		public DbSet<AppUser> Users { get; set; }
		public DbSet<Address> Addresses { get; set; }
		public DbSet<Race> Races {get; set;}
		public DbSet<Club> Clubs { get; set; }
	}
}