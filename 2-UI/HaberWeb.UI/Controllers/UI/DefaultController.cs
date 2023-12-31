using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HaberWeb.UI.Controllers.UI
{
	public class DefaultController : Controller
	{
        [AllowAnonymous]
        public IActionResult Index()
		{
			return View();
		}
	}
}
