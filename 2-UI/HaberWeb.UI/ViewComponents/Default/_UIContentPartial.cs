using HaberWeb.UI.Dtos.NewsDtos;
using HaberWeb.UI.Dtos.NewsImageDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HaberWeb.UI.ViewComponents.Default
{
    public class _UIContentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UIContentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(int categoryId)
        {

            var client = _httpClientFactory.CreateClient();
            var responserMessage = await client.GetAsync($"https://localhost:7187/api/Category/news{categoryId}");
            var responserMessage2 = await client.GetAsync($"https://localhost:7187/api/NewsImage");
            if (responserMessage.IsSuccessStatusCode && responserMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responserMessage.Content.ReadAsStringAsync();
                var newsValues = JsonConvert.DeserializeObject<List<ResultNewsDto>>(jsonData);
                var imageJsonData = await responserMessage2.Content.ReadAsStringAsync();
                var imageValues = JsonConvert.DeserializeObject<List<ResultNewsImageDto>>(imageJsonData);
                foreach (var news in newsValues)
                {
                    news.NewsImage= imageValues
                        .Where(img => img.NewsID == news.NewsID)
                        .ToList();
                }
                return View(newsValues);
            }
            return View();
        }
    }
}
