using HaberWeb.UI.Dtos.NewsImageDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HaberWeb.UI.Controllers.AdminPaneli
{
	public class NewsImageController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly IConfiguration _configuration;
		private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;

		public NewsImageController(IHttpClientFactory httpClientFactory, IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
		{
			_httpClientFactory = httpClientFactory;
			_configuration = configuration;
			_environment = environment;
		}

		public async Task<IActionResult> Index()
		{

			var client = _httpClientFactory.CreateClient();
			var responserMessage = await client.GetAsync("https://localhost:7187/api/NewsImage");
			if (responserMessage.IsSuccessStatusCode)
			{
				var jsonData = await responserMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultNewsImageDto>>(jsonData);
				return View(values);
			}
			return View();
		}
		public async Task<IActionResult> DeleteNewsImage(int id)
		{

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7187/api/NewsImage/{id}");

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();


		}
		[HttpGet]
		public async Task<IActionResult> CreateNewsImage(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7187/api/News/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<CreateNewsImageDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateNewsImage(CreateNewsImageDto model)
		{
				var date = DateTime.Now;
				var extension = Path.GetExtension(model.FileImage.FileName);
				var fileName = $"{date.Day}_{date.Month}_{date.Year}_{date.Hour}_{date.Minute}_{date.Second}_{date.Millisecond}{extension}";
				var filePath = Path.Combine(_environment.WebRootPath, _configuration["Paths:NewsImages"], fileName);

				using (FileStream fs = new FileStream(filePath, FileMode.Create))
				{

					using (var httpclient = new HttpClient())
					{
						var formData = new MultipartFormDataContent();
						formData.Add(new StringContent(model.NewsID.ToString()), "NewsID");
						using (var stream = new MemoryStream())
						{
							model.FileImage.CopyTo(stream);
							var byteArrayContent = new ByteArrayContent(stream.ToArray());
							formData.Add(byteArrayContent, "UploadedImage", model.FileImage.FileName);
						}

						var response = await httpclient.PostAsync("https://localhost:7187/api/NewsImage", formData);

						if (response.IsSuccessStatusCode)
						{
							return RedirectToAction("Index", "News");
						}
						else
						{
							return View();
						}
					}
				}

		}

	}
}
