using System.Globalization;
using System.Text.Json;
using UtbildningSEAMS.Business.Application.Ports;

namespace UtbildningSEAMS.External;

public class TemperatureService : ITemperatureService
{
    public async Task<double?> GetLatestTemperature(double longitude, double latitude)
    {
        // TODO Hur testar vi den här? Behöver vi testa den här?
        var client = new HttpClient();      // så här får man egentligen inte göra heller...
        client.BaseAddress = new Uri("https://api.open-meteo.com/v1/");
        var response = await client.GetAsync($"forecast?latitude={latitude.ToString(CultureInfo.InvariantCulture)}&longitude={longitude.ToString(CultureInfo.InvariantCulture)}&hourly=temperature_2m");

        response.EnsureSuccessStatusCode();
        
        var content = await response.Content.ReadAsStringAsync();
        
        var temperature = JsonSerializer.Deserialize<Temperature>(content);
        var latestTemp = temperature.hourly.temperature_2m[0];
        return latestTemp;
    }
    
    public record Temperature(
        double latitude,
        double longitude,
        double generationtime_ms,
        int utc_offset_seconds,
        string timezone,
        string timezone_abbreviation,
        double elevation,
        Hourly_units hourly_units,
        Hourly hourly
    );

    public record Hourly_units(
        string time,
        string temperature_2m
    );

    public record Hourly(
        string[] time,
        double[] temperature_2m
    );    

}