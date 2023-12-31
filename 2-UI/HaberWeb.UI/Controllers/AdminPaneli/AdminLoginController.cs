
using EntityLayer.Concrete;
using HaberWeb.UI.Dtos.LoginDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HaberWeb.UI.Controllers.AdminPaneli
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;

		public AdminLoginController(SignInManager<AppUser> signInManager)
		{
			_signInManager = signInManager;
		}

		[HttpGet]
		[Route("Login")]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		[Route("Login")]
		public async Task<IActionResult> Index(LoginDto loginUserDto)
		{
			var result = await _signInManager.PasswordSignInAsync(loginUserDto.Username, loginUserDto.Password, false, false);
			if (result.Succeeded)
			{
				return RedirectToAction("Index", "Category");
			}
			else
			{
				return View();
			}

		}
	}
}
