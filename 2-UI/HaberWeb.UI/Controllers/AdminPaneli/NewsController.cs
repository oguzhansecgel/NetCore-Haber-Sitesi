﻿using HaberWeb.UI.Dtos.CategoryDtos;
using HaberWeb.UI.Dtos.NewsDtos;
using HaberWeb.UI.Dtos.NewsImageDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using X.PagedList;

namespace HaberWeb.UI.Controllers.AdminPaneli
{
    public class NewsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NewsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
		[Route("AdminHaber")]
		public async Task<IActionResult> Index(int page = 1)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://api.vatan19tv.com/api/News/ListNewsWithCategory");
			var responserMessage2 = await client.GetAsync($"https://api.vatan19tv.com/api/NewsImage");
			if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultNewsWithCategoryDto>>(jsonData).ToPagedList(page,10);
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
		[Route("habersil{id}")]
		public async Task<IActionResult> DeleteNews(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://api.vatan19tv.com/api/News/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> CreateNews()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://api.vatan19tv.com/api/Category");
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
			List<SelectListItem> values2 = (from x in values
											select new SelectListItem
											{
												Text = x.CategoryName,
												Value = x.CategoryID.ToString()
											}).ToList();
			ViewBag.v = values2;
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateNews(CreateNewsDto createNewsDto)
		{
			if(ModelState.IsValid)
			{
                createNewsDto.EditorPick = false;
                createNewsDto.NewsEnterTime = DateTime.Now;
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createNewsDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://api.vatan19tv.com/api/News", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
			
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> UpdateNews(int id)
		{
			var client1 = _httpClientFactory.CreateClient();
			var responseMessage1 = await client1.GetAsync("https://api.vatan19tv.com/api/Category");
			var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
			var values1 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData1);
			List<SelectListItem> values2 = (from x in values1
											select new SelectListItem
											{
												Text = x.CategoryName,
												Value = x.CategoryID.ToString()
											}).ToList();
			ViewBag.v = values2;
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://api.vatan19tv.com/api/News/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateNewsDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateNews(UpdateNewsDto updateNewsDto)
		{
			updateNewsDto.NewsEnterTime=DateTime.Now;
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateNewsDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://api.vatan19tv.com/api/News/", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}






	}
}
