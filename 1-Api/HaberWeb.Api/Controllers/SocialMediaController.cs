using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.News;
using DtoLayer.SocialMedia;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HaberWeb.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SocialMediaController : ControllerBase
	{
		private readonly ISocialMediaService _socialMediaService;
		private readonly IMapper _mapper;

		public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
		{
			_socialMediaService = socialMediaService;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult SocialMediaList()
		{
			var values = _socialMediaService.TGetListAll();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public IActionResult GetSocialMedia(int id)
		{
			var values = _socialMediaService.TGetByID(id);
			return Ok(values);
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteSocialMedia(int id)
		{
			var values = _socialMediaService.TGetByID(id);
			_socialMediaService.TDelete(values);
			return Ok("Link Silindi");
		}
		[HttpPost]
		public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
		{
			
			var values = _mapper.Map<SocialMedia>(createSocialMediaDto);
			_socialMediaService.TAdd(values);
			return Ok("Link Eklendi");
		}
		[HttpPut]
		public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
		{
			var values = _mapper.Map<SocialMedia>(updateSocialMediaDto);
			_socialMediaService.TUpdate(values);
			return Ok("Link Güncellendi.");
		}
	}
}
