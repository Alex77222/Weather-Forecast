using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services.Contracts;

namespace WebApplication1.Controllers;

public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherForecast _weatherForecast;

    public WeatherForecastController(IWeatherForecast weatherForecast)
    {
        _weatherForecast = weatherForecast;
    }

    [HttpGet]
    [Route("today")]
    public async Task<IActionResult> Weather(DateTime? dateTo = null, DateTime? dateFrom = null)

    {
        try
        {
            var result = await _weatherForecast.GetWeather(dateFrom,dateTo);
            return Ok(new Response<List<Weather>>()
            {
                IsSuccess = true,
                Data = result
            });
        }
        catch (Exception e)
        {
            return BadRequest(new Response<string>()
            {
                IsSuccess = false,
                Errors = new List<string> { e.Message }
            });
        }
    }
    
    [HttpGet]
    [Route("now")]
    public async Task<IActionResult> WeatherNow()
    {
        try
        {
            var result = await _weatherForecast.GetWeatherNow();
            return Ok(new Response<Weather>()
            {
                IsSuccess = true,
                Data = result
            });
        }
        catch (Exception e)
        {
            return BadRequest(new Response<string>()
            {
                IsSuccess = false,
                Errors = new List<string> { e.Message }
            });
        }
    }
}