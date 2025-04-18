using UtbildningSEAMS.Business.Application.Ports;
using UtbildningSEAMS.Business.Domain;

namespace UtbildningSEAMS.External;

public class Repository(UserDatabaseContext context) : IRepository
{
    public List<City> GetCities()
    {
        return context.Cities.ToList();
    }
}