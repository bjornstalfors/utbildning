using UtbildningSEAMS.Business.Application.Ports;

namespace UtbildningSEAMS.Business.Domain;

public class DensityCalculator : IDensityCalculator
{
    public City? FindDensestCity(List<City> cities)
    {
        if (cities.Count == 0)
            return null;
        
        return cities.OrderByDescending(x => x.Population / x.Area).FirstOrDefault();
    }
}