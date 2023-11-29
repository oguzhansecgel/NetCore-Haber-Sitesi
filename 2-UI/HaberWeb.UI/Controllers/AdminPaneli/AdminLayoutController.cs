using Microsoft.AspNetCore.Mvc;

namespace HaberWeb.UI.Controllers.AdminPaneli
{
	public class AdminLayoutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
