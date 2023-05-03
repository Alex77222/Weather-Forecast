using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services.Contracts;

namespace WebApplication1.Controllers;

public  class WeatherForecastController : ControllerBase
{
    private readonly IWeatherForecast _weatherForecast;

    public WeatherForecastController(IWeatherForecast weatherForecast)
    {
        _weatherForecast = weatherForecast;
    }

    [HttpGet]
    [Route("today")]
    public async Task<IActionResult> WeatherToDay()
    {
        try
        {
            var result = await _weatherForecast.GetWeatherToDay();
            return Ok(new Response<Hourly>()
            {
                IsSuccess = true,
                Data = result.Hourly
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