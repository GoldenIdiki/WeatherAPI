using AutoMapper;
using WeatherAPI.Domain;
using WeatherAPI.Domain.DTOs;

namespace WeatherAPI.Presentation.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, AppUserDTO>().ReverseMap();
        }
    }
}
