using Microsoft.AspNetCore.Mvc;

namespace HaberWeb.UI.ViewComponents.Default
{
    public class _UIHeaderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
