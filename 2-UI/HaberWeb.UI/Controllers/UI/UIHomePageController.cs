using HaberWeb.UI.Dtos.NewsDtos;
using HaberWeb.UI.Dtos.NewsImageDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace HaberWeb.UI.Controllers.UI
{
	public class UIHomePageController : Controller
	{
        private readonly IHttpClientFactory _httpClientFactory;

        public UIHomePageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("")]
        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient();
            var responserMessage = await client.GetAsync("https://localhost:7187/api/News/ListNewsWithCategory");
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
    }
}
