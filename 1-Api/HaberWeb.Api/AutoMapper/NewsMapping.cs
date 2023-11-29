using AutoMapper;
using DtoLayer.Category;
using DtoLayer.News;
using EntityLayer.Concrete;

namespace HaberWeb.Api.AutoMapper
{
	public class NewsMapping : Profile
	{
        public NewsMapping()
        {
			CreateMap<ResultNewsDto, News>().ReverseMap();
			CreateMap<CreateNewsDto, News>().ReverseMap();
			CreateMap<UpdateNewsDto, News>().ReverseMap();
			CreateMap<ResultNewsWithCategoryDto, News>().ReverseMap();
		}
    }
}
