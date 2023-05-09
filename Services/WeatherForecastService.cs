using AutoMapper;
using WebApplication1.Data;
using WebApplication1.Data.Entities;
using WebApplication1.Helper;
using WebApplication1.Models;
using WebApplication1.Services.Contracts;

namespace WebApplication1.Services;

public class WeatherForecastService : IWeatherForecast
{
    private readonly AppDbContext _appContext;
    private readonly IMapper _mapper;

    public WeatherForecastService(AppDbContext appContext, IMapper mapper)
    {
        _appContext = appContext;
        _mapper = mapper;
    }

    public async Task<Weather> GetWeatherToDay()
    {
        
        var dateToday = DateTime.Now;
        var weather =  await HttpHelper.GetWeather(dateToday.ToString("yyyy-MM-dd"),
            dateToday.ToString("yyyy-MM-dd"));

        return _mapper.Map<Weather>(weather.Hourly);
    }
    public async Task<Weather> GetWeatherNow()
    {
        
        var dateToday = DateTime.Now;
        var weather =  await HttpHelper.GetWeather(dateToday.ToString("yyyy-MM-dd"),
            dateToday.ToString("yyyy-MM-dd"));
        var dbWeather = await _appContext.WeatherNow.FindAsync(1);
        if (dbWeather != null && weather.current_Weather != null && dbWeather.Date.AddHours(2)>=weather.current_Weather.time )
        {
            dbWeather.Date = weather.current_Weather.time;
            dbWeather.Temperature = weather.current_Weather.temperature;
            _appContext.WeatherNow.Update(dbWeather);
            await _appContext.SaveChangesAsync();
            return _mapper.Map<Weather>(weather.current_Weather);
        }

        return _mapper.Map<Weather>(dbWeather);
    }
    
}