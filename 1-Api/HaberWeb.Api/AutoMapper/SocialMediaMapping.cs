using AutoMapper;
using DtoLayer.SocialMedia;
using EntityLayer.Concrete;

namespace HaberWeb.Api.AutoMapper
{
	public class SocialMediaMapping : Profile
	{
        public SocialMediaMapping()
        {
            CreateMap<ResultSocialMediaDto,SocialMedia>().ReverseMap();
            CreateMap<CreateSocialMediaDto,SocialMedia>().ReverseMap();
            CreateMap<UpdateSocialMediaDto,SocialMedia>().ReverseMap();
        }
    }
}
