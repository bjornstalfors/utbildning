using UtbildningSEAMS.Business.Application.Ports;

namespace UtbildningSEAMS.Business.Application;

public class WeatherService(IRepository repository, ITemperatureService temperatureService, IDensityCalculator densityCalculator, ILogger logger) 
{
    public async Task<(string, double)> WeatherInMostDenseCity()
    {
        var cities = await repository.GetCities();
        // TODO tom lista? ingen kontakt med DB?

        var densestCity = densityCalculator.FindDensestCity(cities);
        // TODO ingen stad funnen? möjligt ens?

        var temp = await temperatureService.GetLatestTemperature(densestCity.Longitude, densestCity.Latitude);
        // TODO Vad händer om vi inte får svar?

        if (temp > 10.00d)
        {
            logger.LogInfo("Norrlandsvarning, kvalmigt!");
        }

        return (densestCity.Name, (double)temp!);   // TODO explicit konvertering
    }
}