using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UtbildningSEAMS.Business.Application;
using UtbildningSEAMS.Business.Application.Ports;
using UtbildningSEAMS.Business.Domain;
using UtbildningSEAMS.External;

#region IoC
var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddTransient<IDensityCalculator, DensityCalculator>();
builder.Services.AddTransient<ILogger, Logger>();
builder.Services.AddTransient<IRepository, Repository>();
builder.Services.AddTransient<ITemperatureService, TemperatureService>();
builder.Services.AddTransient<WeatherService>();
builder.Services.AddDbContext<UserDatabaseContext>(o => o.UseSqlite("Data Source=utbildning_user_database.db"));
var host = builder.Build();
#endregion IoC

using var scope = host.Services.CreateScope();

#region Database
var context = scope.ServiceProvider.GetRequiredService<UserDatabaseContext>();
if (context.Database.EnsureCreated())
{
    context.Cities.AddRange(
        new City { Name = "Tokyo", Population = 37400068, Area = 2194, Latitude = 35.6895, Longitude = 139.6917 },
        new City { Name = "Delhi", Population = 31870000, Area = 1484, Latitude = 28.7041, Longitude = 77.1025 },
        new City { Name = "São Paulo", Population = 22430000, Area = 1521, Latitude = -23.5505, Longitude = -46.6333 },
        new City { Name = "Shanghai", Population = 24800000, Area = 6340, Latitude = 31.2304, Longitude = 121.4737 },
        new City { Name = "Cairo", Population = 21150000, Area = 3085, Latitude = 30.0444, Longitude = 31.2357 },
        new City { Name = "Istanbul", Population = 15600000, Area = 5461, Latitude = 41.0082, Longitude = 28.9784 },
        new City { Name = "New York City", Population = 19200000, Area = 783, Latitude = 40.7128, Longitude = -74.0060 },
        new City { Name = "London", Population = 9300000, Area = 1572, Latitude = 51.5074, Longitude = -0.1278 },
        new City { Name = "Bangkok", Population = 10500000, Area = 1569, Latitude = 13.7563, Longitude = 100.5018 },
        new City { Name = "Moscow", Population = 12500000, Area = 2561, Latitude = 55.7558, Longitude = 37.6176 },
        new City { Name = "Buenos Aires", Population = 15100000, Area = 203, Latitude = -34.6037, Longitude = -58.3816 },
        new City { Name = "Paris", Population = 11000000, Area = 105, Latitude = 48.8566, Longitude = 2.3522 },
        new City { Name = "Lagos", Population = 16000000, Area = 1171, Latitude = 6.5244, Longitude = 3.3792 },
        new City { Name = "Jakarta", Population = 10500000, Area = 661, Latitude = -6.2088, Longitude = 106.8456 },
        new City { Name = "Los Angeles", Population = 12700000, Area = 1302, Latitude = 34.0522, Longitude = -118.2437 },
        new City { Name = "Kinshasa", Population = 15500000, Area = 9965, Latitude = -4.4419, Longitude = 15.2663 },
        new City { Name = "Mexico City", Population = 21900000, Area = 1485, Latitude = 19.4326, Longitude = -99.1332 },
        new City { Name = "Tehran", Population = 9200000, Area = 730, Latitude = 35.6892, Longitude = 51.3890 },
        new City { Name = "Sydney", Population = 5300000, Area = 12367, Latitude = -33.8688, Longitude = 151.2093 },
        new City { Name = "Toronto", Population = 6300000, Area = 630, Latitude = 43.6511, Longitude = -79.3837 },
        new City { Name = "Berlin", Population = 3800000, Area = 891, Latitude = 52.5200, Longitude = 13.4050 },
        new City { Name = "Madrid", Population = 6600000, Area = 604, Latitude = 40.4168, Longitude = -3.7038 },
        new City { Name = "Seoul", Population = 9500000, Area = 605, Latitude = 37.5665, Longitude = 126.9780 },
        new City { Name = "Nairobi", Population = 4700000, Area = 696, Latitude = -1.2921, Longitude = 36.8219 },
        new City { Name = "Stockholm", Population = 1250000, Area = 188, Latitude = 59.3293, Longitude = 18.0686 }
    );
    context.SaveChanges(); 
}
#endregion Database

#region Service
var service = scope.ServiceProvider.GetRequiredService<WeatherService>();
var (city, temp) = await service.WeatherInMostDenseCity();
#endregion Service

Console.WriteLine($"Dom har det bra i {city} där är det {temp} grader");