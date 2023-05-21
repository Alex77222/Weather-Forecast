using AutoMapper;
using WebApplication1.Data;
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

    public async Task<List<WeatherFrom>> GetWeather(DateTime? dateFrom, DateTime? dateTo)
    {
        var dateToday = DateTime.Now;
        var dateStart = dateFrom ??= dateToday;
        var dateEnd = dateTo ??= dateToday;
        var weather = await HttpHelper.GetWeather(dateStart.ToString("yyyy-MM-dd"),
            dateEnd.ToString("yyyy-MM-dd"));
        var result = new List<WeatherFrom>();
        for (int i = 0; i < weather.Hourly.time.Count; i++)
        {
            var weatherFrom = new WeatherFrom()
            {
                Id = i,
                Date = weather.Hourly.time[i],
                Temperature = weather.Hourly.temperature_2m[i]
            };
            result.Add(weatherFrom);
        }
        return result;
    }

    public async Task<Weather> GetWeatherNow()
    {
        var dateToday = DateTime.Now;
        var weather = await HttpHelper.GetWeather(dateToday.ToString("yyyy-MM-dd"),
            dateToday.ToString("yyyy-MM-dd"));
        var dbWeather = await _appContext.WeatherNow.FindAsync(1);
        if (dbWeather != null && weather.current_Weather != null &&
            dbWeather.Date.AddHours(2) <= weather.current_Weather.time)
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