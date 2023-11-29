using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using DtoLayer.Category;
using DtoLayer.News;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HaberWeb.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NewsController : ControllerBase
	{
		private readonly INewsService _newsService;
		private readonly IMapper _mapper;

		public NewsController(INewsService newsService, IMapper mapper)
		{
			_newsService = newsService;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult NewsList() 
		{
			var values = _newsService.TGetListAll();
			return Ok(values);
		}
		[HttpGet("ListNewsWithCategory")]
		public IActionResult ListNewsWithCategory() 
		{
			var context = new Context();
			var values = context.Newses.Include(x => x.Category).Select(y => new ResultNewsWithCategoryDto
			{
				 CategoryName=y.Category.CategoryName,
				 EditorPick=y.EditorPick,
				 NewsContent=y.NewsContent,
				 NewsEnterTime=y.NewsEnterTime,	
				 NewsTitle=y.NewsTitle,
				 NewsSummary=y.NewsSummary,
				 NewsID=y.NewsID,
			});
			return Ok(values.ToList());
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteNews(int id) 
		{ 
			var values = _newsService.TGetByID(id);
			_newsService.TDelete(values);
			return Ok("Haber Silindi");
		}
		[HttpPost]
		public IActionResult CreateNews(CreateNewsDto createNewsDto)
		{
			var values = _mapper.Map<News>(createNewsDto);
			_newsService.TAdd(values);
			return Ok("Haber Eklendi");
		}
		[HttpPut]
		public IActionResult UpdateNews(UpdateNewsDto updateNewsDto)
		{
			var values = _mapper.Map<News>(updateNewsDto);
			_newsService.TUpdate(values);
			return Ok("Kategori Güncellendi.");
		}
	}
}
