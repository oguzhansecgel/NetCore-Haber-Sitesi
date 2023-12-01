using Microsoft.AspNetCore.Mvc;

namespace HaberWeb.UI.Controllers.UI
{
	public class DefaultController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
        public IActionResult GetContentDetail([FromQuery] int categoryId)
        {
            return ViewComponent("_UIContentPartial", new
            {
                categoryId = categoryId
            });
        }
    }
}
