using RestSharp;
using WebApplication1.Models;

namespace WebApplication1.Helper;

public class HttpHelper
{
    private const string Api =
        "https://api.open-meteo.com/v1/";
    public static async Task<WeatherApi> GetWeather(string dataStart,string dataEnd)
    {
        var client = new RestClient(Api);
        var request = new RestRequest($"forecast?latitude=53.69&longitude=23.83&hourly=temperature_2m&current_weather=true&forecast_days=1&start_date={dataStart}&end_date={dataEnd}&timezone=Europe%2FMoscow");
        var data = await  client.GetAsync<WeatherApi>(request);
        if (data != null) return data;
        throw new Exception("No data in API");
    }
}