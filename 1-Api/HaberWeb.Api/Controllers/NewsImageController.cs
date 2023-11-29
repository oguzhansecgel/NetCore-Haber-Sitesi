using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.NewsImage;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HaberWeb.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NewsImageController : ControllerBase
	{
		private readonly INewsImageService _newsImageService;
		private readonly IMapper _mapper;
		private readonly IConfiguration _config;
		private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;

		public NewsImageController(INewsImageService newsImageService, IMapper mapper, IConfiguration config, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
		{
			_newsImageService = newsImageService;
			_mapper = mapper;
			_config = config;
			_environment = environment;
		}
		[HttpGet]
		public IActionResult ImageList()
		{
			var values = _newsImageService.TGetListAll();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult AddNewsImage([FromForm] CreateNewsImageDto model)
		{

			var date = DateTime.Now;
			var extension = Path.GetExtension(model.UploadedImage.FileName);
			var fileName = $"{date.Day}_{date.Month}_{date.Year}_{date.Hour}_{date.Minute}_{date.Second}_{date.Millisecond}{extension}";
			var filePath = Path.Combine(_environment.WebRootPath, _config["Paths:NewsImages"], fileName);

			using (FileStream fs = new FileStream(filePath, FileMode.Create))
			{
				model.UploadedImage.CopyTo(fs);
				fs.Close();
			}
			var newsImageEntity = _mapper.Map<NewsImage>(model);
			newsImageEntity.Path = Path.Combine(_config["Paths:NewsImages"], fileName);



			_newsImageService.TAdd(newsImageEntity);

			return Ok();

		}
		[HttpDelete("{id}")]
		public IActionResult DeleteNewsImage(int id)
		{
			var values = _newsImageService.TGetByID(id);

			var filePath = Path.Combine(_environment.WebRootPath, values.Path);
			if (System.IO.File.Exists(filePath))
			{

				System.IO.File.Delete(filePath);

			}
			_newsImageService.TDelete(values);
			return Ok();
		}
	}
}
