using AutoMapper;
using DtoLayer.NewsImage;
using EntityLayer.Concrete;

namespace HaberWeb.Api.AutoMapper
{
	public class NewsImageMapping : Profile
	{
        public NewsImageMapping()
        {
            CreateMap<ResultNewsImageDto, NewsImage>().ReverseMap();
            CreateMap<CreateNewsImageDto, NewsImage>().ReverseMap();
            CreateMap<UpdateNewsImageDto, NewsImage>().ReverseMap();
            CreateMap<ResultImageWithNews, NewsImage>().ReverseMap();
        }
    }
}
