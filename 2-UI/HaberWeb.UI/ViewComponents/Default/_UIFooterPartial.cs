using Microsoft.AspNetCore.Mvc;

namespace HaberWeb.UI.ViewComponents.Default
{
    public class _UIFooterPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
