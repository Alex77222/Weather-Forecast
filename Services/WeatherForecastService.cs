using WebApplication1.Data;
using WebApplication1.Helper;
using WebApplication1.Models;
using WebApplication1.Services.Contracts;

namespace WebApplication1.Services;

public class WeatherForecastService : IWeatherForecast
{
    private readonly AppDbContext _appContext;

    public WeatherForecastService(AppDbContext appContext)
    {
        _appContext = appContext;
    }

    public async Task<WeatherApi> GetWeatherToDay()
    {
        
        var dataToday = DateTime.Now;
        var weather =  await HttpHelper.GetWeather(dataToday.ToString("yyyy-MM-dd"),
            dataToday.ToString("yyyy-MM-dd"));

        return weather;
    }
    
}