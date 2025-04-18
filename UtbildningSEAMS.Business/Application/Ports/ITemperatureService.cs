namespace UtbildningSEAMS.Business.Application.Ports;

public interface ITemperatureService
{
    Task<double> GetLatestTemperature(double longitude, double latitude);
}