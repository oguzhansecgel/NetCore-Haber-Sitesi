using HaberWeb.UI.Dtos.NewsDtos;
using HaberWeb.UI.Dtos.NewsImageDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http;

namespace HaberWeb.UI.ViewComponents.Default
{
    [AllowAnonymous]
    public class _UIHeadPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _UIHeadPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
        {
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://api.vatan19tv.com/api/News/ListNewsWithCategory");
			var responserMessage2 = await client.GetAsync($"https://api.vatan19tv.com/api/NewsImage");
 
            if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultNewsWithCategoryDto>>(jsonData);
				var imageJsonData = await responserMessage2.Content.ReadAsStringAsync();
				var imageValues = JsonConvert.DeserializeObject<List<ResultNewsImageDto>>(imageJsonData);
				foreach (var news in values)
				{
					news.NewsImage = imageValues
						.Where(img => img.NewsID == news.NewsID)
						.ToList();
				}
				return View(values);

			}
			return View();
		}
    }
}
