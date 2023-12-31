using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using DtoLayer.Category;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HaberWeb.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
    [AllowAnonymous]
    public class CategoryController : ControllerBase
	{
		private readonly ICategoryService _categoryService;
		private readonly IMapper _mapper;
		private readonly Context _context;
        public CategoryController(ICategoryService categoryService, IMapper mapper, Context context)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
		public IActionResult CategoryList()
		{
			var values = _categoryService.TGetListAll();
			return Ok(values);
		}
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var value = _categoryService.TGetByID(id);
            return Ok(value);
        }
        // kategoriye göre ürün listeleme
        [HttpGet("news{categoryId}")]
        public IActionResult GetNewsByCategoryId(int categoryId)
        {
            var products = _context.Newses.Where(p => p.CategoryID == categoryId).ToList();
            return Ok(products);
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
