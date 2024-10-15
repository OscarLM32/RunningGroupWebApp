using RunningGroupWebApp.Data.Enum;
using RunningGroupWebApp.Models;

namespace RunningGroupWebApp.ViewModels;

public class VMEditRace
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public Address? Address { get; set; }
    public IFormFile? Image { get; set; }
    public RaceCategory? RaceCategory { get; set; }
}