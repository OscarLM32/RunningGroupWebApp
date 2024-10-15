using RunningGroupWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace RunningGroupWebApp.Data
{
	public class AppDbContext : IdentityDbContext<AppUser>
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