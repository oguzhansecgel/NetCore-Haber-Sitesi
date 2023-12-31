using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using DtoLayer.AppUser;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HaberWeb.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
    [AllowAnonymous]
    public class AppUserController : ControllerBase
	{
		private readonly IAppUserService _appUserService;
		private readonly IMapper _mapper;
		private readonly Context _context;
		private readonly UserManager<AppUser> _userManager;

		public AppUserController(IAppUserService appUserService, IMapper mapper, Context context, UserManager<AppUser> userManager)
		{
			_appUserService = appUserService;
			_mapper = mapper;
			_context = context;
			_userManager = userManager;
		}
		[HttpGet]

		public IActionResult AppUserList()
		{
			var values = _appUserService.TGetListAll();
			return Ok(values);
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteAppUser(int id)
		{
			var usersExist = _context.Users.Any(x => x.Id == id);
			if (!usersExist)
			{
				var errorMessage = $"{id} kimlik numarasına sahip kullanıcı bulunamadı ve silme işlemi gerçekleşmedi";
				return BadRequest(errorMessage);
			}

			var values = _appUserService.TGetByID(id);
			_appUserService.TDelete(values);
			return Ok();
		}

		[HttpPost("register")]

		public async Task<IActionResult> Register(RegisterDto registerDto)
		{

			var usersMail = _context.Users.Any(x => x.Email == registerDto.Email);
			var usersName = _context.Users.Any(x => x.UserName == registerDto.Username);

			if (usersMail)
			{
				var errorMessage = $"Girdiğiniz mail adresine kayıtlı kullanıcı bulunmakta";
				return BadRequest(errorMessage);

			}
			if (usersName)
			{
				var errorMessage = $"Girdiğiniz kullanıcı adı kullanılmaktadır.";
				return BadRequest(errorMessage);

			}
			if (registerDto.Password != registerDto.ConfirmPassword)
			{
				var errorMessage = "Şifreler uyuşmuyor.";
				return BadRequest(errorMessage);
			}
			var appUser = _mapper.Map<AppUser>(registerDto);
			var result = await _userManager.CreateAsync(appUser, registerDto.Password);

			if (!result.Succeeded)
			{
				var errorMessages = result.Errors.Select(e => e.Description);
				return BadRequest(new { Errors = errorMessages });
			}

			return Ok();



		}


		[HttpPost("login")]

		public async Task<IActionResult> Login(LoginDto loginDto)
		{

			var user = await _userManager.FindByNameAsync(loginDto.Username);

			if (user != null && await _userManager.CheckPasswordAsync(user, loginDto.Password))
			{
				return Ok();

			}
			else
			{
				var errorMessage = $"Girdiğiniz bilgiler yanlış";
				return BadRequest(errorMessage);
			}
		}
	}
}
