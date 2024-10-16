using System.ComponentModel.DataAnnotations;
using CloudinaryDotNet.Actions;

namespace RunningGroupWebApp.ViewModels;

public class VMRegister
{
	[Display(Name = "Email Address")]
	[Required(ErrorMessage = "Email address is requiered")]
	public string Email { get; set; }
	
	[Required]
	[DataType(DataType.Password)]
	public string Password { get; set; }
	
	[Display(Name = "Confirm password")]
	[Required(ErrorMessage ="Confirm password is required")]
	[DataType(DataType.Password)]
	[Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
	public string PasswordConfirmation { get; set; }
	
}