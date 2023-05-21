using WebApplication1.Models;

namespace WebApplication1.Services.Contracts;

public interface IWeatherForecast
{
    public  Task<List<WeatherFrom>>  GetWeather(DateTime? dateFrom, DateTime? dateTo);
    public  Task<Weather>  GetWeatherNow();
}