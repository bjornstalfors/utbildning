using UtbildningSEAMS.Business.Domain;

namespace UtbildningSEAMS.Business.Application.Ports;

public interface IRepository
{
    Task<List<City>> GetCities();     
}