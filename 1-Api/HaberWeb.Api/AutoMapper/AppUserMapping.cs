using AutoMapper;
using DtoLayer.AppUser;
using EntityLayer.Concrete;

namespace HaberWeb.Api.AutoMapper
{
	public class AppUserMapping : Profile
	{
        public AppUserMapping()
        {
            CreateMap<LoginDto, AppUser>().ReverseMap();
            CreateMap<RegisterDto, AppUser>().ReverseMap();
        }
    }
}
