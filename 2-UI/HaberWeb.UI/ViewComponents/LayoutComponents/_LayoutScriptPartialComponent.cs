﻿using Microsoft.AspNetCore.Mvc;

namespace HaberWeb.UI.ViewComponents.LayoutComponents
{
	public class _LayoutScriptPartialComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
