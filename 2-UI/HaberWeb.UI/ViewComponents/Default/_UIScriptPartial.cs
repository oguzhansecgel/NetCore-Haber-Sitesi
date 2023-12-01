using Microsoft.AspNetCore.Mvc;

namespace HaberWeb.UI.ViewComponents.Default
{
    public class _UIScriptPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
