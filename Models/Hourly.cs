namespace WebApplication1.Models;

public class Hourly
{
    public List<string> time { get; set; }
    public List<double> temperature_2m { get; set; }

    /*public Hourly(List<string> time, List<double> temperature_2m)
    {
        this.temperature_2m = temperature_2m;
        this.time = time;
    }*/
}