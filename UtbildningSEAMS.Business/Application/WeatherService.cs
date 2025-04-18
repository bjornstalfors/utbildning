using UtbildningSEAMS.Business.Application.Ports;

namespace UtbildningSEAMS.Business.Application;

public class WeatherService(IRepository repository, ITemperatureService temperatureService, IDensityCalculator densityCalculator, ILogger logger) 
{
    public async Task<(string, double)> WeatherInMostDenseCity()
    {
        var cities = repository.GetCities();

        var densestCity = densityCalculator.FindDensestCity(cities);

        var temp = await temperatureService.GetLatestTemperature(densestCity.Longitude, densestCity.Latitude);

        if (temp > 10.00)
        {
            logger.LogInfo("Norrlandsvarning, kvalmigt!");
        }

        return (densestCity.Name, temp);
    }
}