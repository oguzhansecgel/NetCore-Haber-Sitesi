using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.Category;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HaberWeb.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryService _categoryService;
		private readonly IMapper _mapper;

		public CategoryController(ICategoryService categoryService, IMapper mapper)
		{
			_categoryService = categoryService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult CategoryList()
		{
			var values = _categoryService.TGetListAll();
			return Ok(values);
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteCategory(int id)
		{
			var values = _categoryService.TGetByID(id);
			_categoryService.TDelete(values);
			return Ok("Kategori Silindi");
		}
		[HttpPost]
		public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
		{
			var values = _mapper.Map<Category>(createCategoryDto);
			_categoryService.TAdd(values);
			return Ok("Kategori Oluşturuldu");
		}
		[HttpPut]
		public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
		{
			var values = _mapper.Map<Category>(updateCategoryDto);
			_categoryService.TUpdate(values);
			return Ok("Kategori Güncellendi.");
		}
	}
}
