using UtbildningSEAMS.Business.Domain;

namespace UtbildningSEAMS.Business.Application.Ports;

public interface IDensityCalculator
{
    City? FindDensestCity(List<City> cities);
}