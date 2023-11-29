using AutoMapper;
using DtoLayer.Category;
using EntityLayer.Concrete;

namespace HaberWeb.Api.AutoMapper
{
	public class CategoryMapping : Profile
	{
		public CategoryMapping() 
		{
			CreateMap<ResultCategoryDto, Category>().ReverseMap();
			CreateMap<CreateCategoryDto, Category>().ReverseMap();
			CreateMap<UpdateCategoryDto, Category>().ReverseMap();
			
		}
	}
}
