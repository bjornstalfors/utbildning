using System.Globalization;
using System.Text.Json;

namespace UtbildningSEAMS;

public class BusinessLogic
{
    public async Task<(string, double)> WeatherInMostDenseCity()
    {
        var context = new UserDatabaseContext();
        
        var cities = context.Cities.ToList();
        
        // Advanced business logic (calculate density)
        var convertedCities = cities.Select(x => new
        {
            x.Name,
            Density = x.Population / x.Area,
            x.Longitude,
            x.Latitude
        }).ToList();
        
        // Advanced business logic (find densest city)
        var densestCity = convertedCities.OrderByDescending(x => x.Density).FirstOrDefault();
        
        // https://api.open-meteo.com/v1/forecast?latitude=52.52&longitude=13.41&hourly=temperature_2m
        var client = new HttpClient();
        client.BaseAddress = new Uri("https://api.open-meteo.com/v1/");
        var response = await client.GetAsync($"forecast?latitude={densestCity.Latitude.ToString(CultureInfo.InvariantCulture)}&longitude={densestCity.Longitude.ToString(CultureInfo.InvariantCulture)}&hourly=temperature_2m");

        response.EnsureSuccessStatusCode();
        
        var content = await response.Content.ReadAsStringAsync();
        
        var temperature = JsonSerializer.Deserialize<Temperature>(content);
        var latestTemp = temperature.hourly.temperature_2m[0];
        
        // Snarky comment if they have it good
        if (latestTemp > 10.00)
        {
            Console.WriteLine("!");
        }

        return (densestCity.Name, latestTemp);
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