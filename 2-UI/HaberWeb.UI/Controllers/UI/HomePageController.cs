﻿using EntityLayer.Concrete;
using HaberWeb.UI.Dtos.CategoryDtos;
using HaberWeb.UI.Dtos.NewsDtos;
using HaberWeb.UI.Dtos.NewsImageDtos;
using Microsoft.AspNetCore.Authorization;
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


        [Route("Haberler")]
        [AllowAnonymous]
        public async Task<IActionResult> Index(int categoryID)
        {

            var client = _httpClientFactory.CreateClient();
            var responserMessage = await client.GetAsync("https://api.vatan19tv.com/api/Category/news" + categoryID);
            var responserMessage2 = await client.GetAsync($"https://api.vatan19tv.com" +
                $"/api/NewsImage");
            var responserMessage3 = await client.GetAsync($"https://api.vatan19tv.com/api/Category");
            if (responserMessage.IsSuccessStatusCode)
            {
                var jsonData = await responserMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultNewsWithCategoryDto>>(jsonData);
                var imageJsonData = await responserMessage2.Content.ReadAsStringAsync();
                var imageValues = JsonConvert.DeserializeObject<List<ResultNewsImageDto>>(imageJsonData);
				var categoryJsonData = await responserMessage3.Content.ReadAsStringAsync();
				var categoryValues = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categoryJsonData);
				foreach (var news in values)
                {
                    news.NewsImage = imageValues
                        .Where(img => img.NewsID == news.NewsID)
                        .ToList();
                    news.Categories = categoryValues.Where(cat => cat.CategoryID == news.CategoryID).ToList();
                }
                return View(values);

            }
            return View();
        }

    }
}
