using RunningGroupWebApp.Models;

namespace RunningGroupWebApp.ViewModels;

public class VMHome
{
	public IEnumerable<Club> Clubs { get; set; }
	public IEnumerable<Race> Races { get; set; }
	public string City {get; set;}
	public string State { get; set; }
}