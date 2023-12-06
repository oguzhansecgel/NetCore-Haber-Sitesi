using Microsoft.AspNetCore.Mvc;

namespace HaberWeb.UI.Controllers.UI
{
	public class UIHomePageController : Controller
	{
		
		public IActionResult Index()
		{
			return View();
		}
	}
}
