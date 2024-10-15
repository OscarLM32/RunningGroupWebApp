using RunningGroupWebApp.Data.Enum;
using RunningGroupWebApp.Interfaces;
using RunningGroupWebApp.Models;
using RunningGroupWebApp.ViewModels;

namespace RunningGroupWebApp.Helpers.Extensions;


public static class EditRaceExtensions
{
    public static VMEditRace ToVMEditRace(this Race race)
    {
        return new VMEditRace()
        {
            Title = race.Title,
            Description = race.Description,
            Address = race.Address,
            Image = null,
            RaceCategory = race.RaceCategory
        };
    }


    public static Race ToRace(this VMEditRace editRace, Race original)
    {
        return new Race()
        {
            Id = original.Id,
            Title = editRace.Title != null ? editRace.Title : original.Title,
            Description = editRace.Description != null ? editRace.Description : original.Description,
            Address = editRace.Address != null ? editRace.Address : original.Address,
            Image = original.Image,
            RaceCategory = editRace.RaceCategory != null ? (RaceCategory)editRace.RaceCategory : original.RaceCategory
        };
    }
}