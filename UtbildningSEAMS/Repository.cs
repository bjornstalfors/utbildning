namespace UtbildningSEAMS;

public class Repository : IRepository
{
    public List<City> GetCities()
    {
        var context = new UserDatabaseContext();
        var cities = context.Cities.ToList();
        return cities;
    }
}