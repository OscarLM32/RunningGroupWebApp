using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RunningGroupWebApp.ViewModels;

public class VMLogin
{
	[DisplayName("Email Address")]
	[Required(ErrorMessage = "Email address required")]
	public string Email { get; set; }
	
	[DataType(DataType.Password)]
	[Required]
	public string Password { get; set; }
}