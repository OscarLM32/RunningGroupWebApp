using RunningGroupWebApp.Interfaces;
using RunningGroupWebApp.Models;
using RunningGroupWebApp.ViewModels;

namespace RunningGroupWebApp.Helpers.Extensions;


public static class EditClubExtensions
{
	public static VMEditClub ToVMEditClub(this Club club)
	{
		return new VMEditClub()
		{
			Title = club.Title,
			Description = club.Description, 
			Address = club.Address,
			Image = null, 
			ClubCategory = club.ClubCategory
		};
	}
	
	
	public static Club ToClub(this VMEditClub editClub, Club original)
	{
		return new Club()
		{
			Id = original.Id,
			Title = editClub.Title != null ? editClub.Title : original.Title,
			Description = editClub.Description != null ? editClub.Description : original.Description,
			Address = editClub.Address != null ? editClub.Address : original.Address,
			Image = original.Image,
			ClubCategory = editClub.ClubCategory
		};
	}
}