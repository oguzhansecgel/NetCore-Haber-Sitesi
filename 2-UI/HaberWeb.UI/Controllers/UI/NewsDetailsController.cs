using EntityLayer.Concrete;
using HaberWeb.UI.Dtos.CategoryDtos;
using HaberWeb.UI.Dtos.NewsDtos;
using HaberWeb.UI.Dtos.NewsImageDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace HaberWeb.UI.Controllers.UI
{
    public class NewsDetailsController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public NewsDetailsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("HaberDetayi")]
        public async Task<IActionResult> SingleContent(int newsID)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7187/api/News/{newsID}");
            var responserMessage2 = await client.GetAsync($"https://localhost:7187/api/NewsImage");
            var responserMessage3 = await client.GetAsync($"https://localhost:7187/api/Category");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultNewsDto>(jsonData);
                var imageJsonData = await responserMessage2.Content.ReadAsStringAsync();
                var imageValues = JsonConvert.DeserializeObject<List<ResultNewsImageDto>>(imageJsonData);
                var categoryJsonData = await responserMessage3.Content.ReadAsStringAsync();
                var categoryValues = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categoryJsonData);

                values.NewsImage = imageValues
                .Where(img => img.NewsID == values.NewsID)
                .ToList();
 
                return View(new List<ResultNewsDto> { values });

            }
            return View();
        }
    }
}
