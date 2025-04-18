using Microsoft.EntityFrameworkCore;
using UtbildningSEAMS.Business.Application.Ports;
using UtbildningSEAMS.Business.Domain;

namespace UtbildningSEAMS.External;

public class Repository(UserDatabaseContext context) : IRepository
{
    public Task<List<City>> GetCities()
    {
        return context.Cities.ToListAsync();
    }
}