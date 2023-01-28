using AutoMapper;
using WeatherAPI.Domain;
using WeatherAPI.Domain.DTOs;
using WeatherAPI.Domain.RequestPayloads;

namespace WeatherAPI.Presentation.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, AppUserDTO>().ReverseMap();
            CreateMap<AppUser, RegistrationRequest>().ReverseMap();
            CreateMap<RegistrationDTO, RegistrationRequest>().ReverseMap();
        }
    }
}
