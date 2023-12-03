using EntityLayer.Concrete;
using HaberWeb.UI.Dtos.CategoryDtos;
using HaberWeb.UI.Dtos.NewsDtos;
using HaberWeb.UI.Dtos.NewsImageDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using X.PagedList;

namespace HaberWeb.UI.Controllers.UI
{
	public class HomePageController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public HomePageController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index(int categoryID)
		{

			var client = _httpClientFactory.CreateClient();
			var responserMessage = await client.GetAsync("https://localhost:7187/api/Category/news" + categoryID);
			var responserMessage2 = await client.GetAsync($"https://localhost:7187/api/NewsImage");
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
		public async Task<IActionResult> SingleContent(int newsID)
		{
         
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7187/api/News/{newsID}");
			var responserMessage2 = await client.GetAsync($"https://localhost:7187/api/NewsImage");
			if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultNewsDto>(jsonData);

                return View(new List<ResultNewsDto> { values });

            }
            return View();
        }
	}
}
