using Microsoft.AspNetCore.Mvc;

namespace HaberWeb.UI.ViewComponents.Default
{
    public class _UIHeadPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
