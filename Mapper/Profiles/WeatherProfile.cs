using AutoMapper;
using WebApplication1.Data.Entities;
using WebApplication1.Models;

namespace WebApplication1.Mapper.Profiles;

public class WeatherProfile : Profile
{
    public WeatherProfile()
    {
        CreateMap<WeatherNow, Weather>();
        CreateMap<CurrentWeather, Weather>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(x => x.time))
            .ForMember(dest => dest.Temperature, opt => opt.MapFrom(x => x.temperature));
    }
}