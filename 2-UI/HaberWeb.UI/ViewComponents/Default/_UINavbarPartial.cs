using HaberWeb.UI.Dtos.CategoryDtos;
using HaberWeb.UI.Dtos.NewsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HaberWeb.UI.ViewComponents.Default
{
    public class _UINavbarPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UINavbarPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responserMessage = await client.GetAsync("https://localhost:7187/api/Category");
            if (responserMessage.IsSuccessStatusCode)
            {
                var jsonData = await responserMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
 
    }
}
