using Microsoft.AspNetCore.Mvc;

namespace HaberWeb.UI.Controllers.UI
{
	public class DefaultController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
