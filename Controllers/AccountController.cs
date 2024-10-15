using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RunningGroupWebApp.Data;
using RunningGroupWebApp.Models;
using RunningGroupWebApp.ViewModels;

namespace RunningGroupWebApp.Controllers;

public class AccountController : Controller
{
	private readonly UserManager<AppUser> _userManager;
	private readonly SignInManager<AppUser> _signInManager;
	private readonly AppDbContext _context;

	public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, AppDbContext context)
	{
		_userManager = userManager;
		_signInManager = signInManager;
		_context = context;
	}

	public IActionResult Login()
	{
		var response = new VMLogin();
		return View(response);
	}
	
	[HttpPost]
	public async Task<IActionResult> Login(VMLogin loginInfo)
	{
		if(!ModelState.IsValid) return View(loginInfo);
		
		var user = await _userManager.FindByEmailAsync(loginInfo.Email);
		if(user == null)
		{
			ModelState.AddModelError("","There is no user with that email registered");
			return View(loginInfo);
		}
		
		//User found
		bool passwordCheck = await _userManager.CheckPasswordAsync(user, loginInfo.Password);
		if(!passwordCheck)
		{
			ModelState.AddModelError("", "The inserted password is not correct");
			return View(loginInfo);
		}
		
		//Password matched
		var result = await _signInManager.PasswordSignInAsync(user, loginInfo.Password, false, false);
		if(!result.Succeeded)
		{
			ModelState.AddModelError("", "Something went wrong. It was not possible to sign in");
			return View(loginInfo);
		}
		
		//Sign in worked
		return RedirectToAction("Index", "Home");
	}
}