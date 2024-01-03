using HaberWeb.UI.Dtos.CategoryDtos;
using HaberWeb.UI.Dtos.NewsDtos;
using HaberWeb.UI.Dtos.NewsImageDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using X.PagedList;

namespace HaberWeb.UI.ViewComponents.LayoutComponents
{
	public class _LayoutSidebarPartialComponent : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _LayoutSidebarPartialComponent(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://api.vatan19tv.com/api/Category");			
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultNewsWithCategoryDto>>(jsonData);				
				return View(values);

			}
			return View();
		}
	}
}
