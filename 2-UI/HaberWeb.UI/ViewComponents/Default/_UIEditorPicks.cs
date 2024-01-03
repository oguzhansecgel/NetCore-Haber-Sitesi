using HaberWeb.UI.Dtos.CategoryDtos;
using HaberWeb.UI.Dtos.NewsDtos;
using HaberWeb.UI.Dtos.NewsImageDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HaberWeb.UI.ViewComponents.Default
{
	public class _UIEditorPicks : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _UIEditorPicks(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
        [AllowAnonymous]
        public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responserMessage = await client.GetAsync("https://api.vatan19tv.com/api/News/ListNewsWithCategory");
            var responserMessage2 = await client.GetAsync($"https://api.vatan19tv.com/api/NewsImage");
            if (responserMessage.IsSuccessStatusCode)
			{
				var jsonData = await responserMessage.Content.ReadAsStringAsync();
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
