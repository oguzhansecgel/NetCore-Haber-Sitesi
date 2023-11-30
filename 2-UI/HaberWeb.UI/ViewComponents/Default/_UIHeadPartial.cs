using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
