using WebApplication1.Models;

namespace WebApplication1.Services.Contracts;

public interface IWeatherForecast
{
    public  Task<WeatherApi>  GetWeatherToDay();
}