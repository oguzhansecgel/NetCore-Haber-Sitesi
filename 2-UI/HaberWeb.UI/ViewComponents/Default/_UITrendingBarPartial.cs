using HaberWeb.UI.Dtos.SocialMedia;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HaberWeb.UI.ViewComponents.Default
{
    public class _UITrendingBarPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UITrendingBarPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responserMessage = await client.GetAsync("https://localhost:7187/api/SocialMedia");
            if (responserMessage.IsSuccessStatusCode)
            {
                var jsonData = await responserMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
