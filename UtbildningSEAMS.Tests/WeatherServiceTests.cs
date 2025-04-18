using Moq;
using UtbildningSEAMS.Business;
using UtbildningSEAMS.Business.Application;
using UtbildningSEAMS.Business.Application.Ports;
using UtbildningSEAMS.Business.Domain;
using Xunit;

namespace UtbildningSEAMS.Tests;


public class WeatherServiceTests
{
    private readonly Mock<IRepository> repository = new();
    private readonly Mock<ITemperatureService> temperatureService = new();
    private readonly Mock<IDensityCalculator> densityCalculator = new();
    private readonly Mock<ILogger> logger = new();

    private static readonly City Dense = CreateCity("Paris", p: 2_165_423, a: 105, lon: 12.2d, lat: 34.2d); 
    private static readonly City Sparse = CreateCity("Strömsund", p: 3423, a: 10005, lon: 25.2d, lat: 56.2d);
    
    private readonly List<City> twoCities = [Dense, Sparse];
    
    public WeatherServiceTests()
    {
        repository.Setup(x => x.GetCities()).Returns(twoCities);
        densityCalculator.Setup(x => x.FindDensestCity(twoCities)).Returns(Dense);
    }

    [Fact]
    public async Task FindCities()
    {
        var sut = CreateSut();
        
        await sut.WeatherInMostDenseCity();
        
        repository.Verify(x => x.GetCities(), Times.Once);
    }

    [Fact]
    public async Task CalculatesDensestCity()
    {
        var sut = CreateSut();
        
        await sut.WeatherInMostDenseCity();
        
        densityCalculator.Verify(x => x.FindDensestCity(twoCities));
    }
    
    [Fact]
    public async Task ChecksWeatherInMostDensestCity()
    {
        var sut = CreateSut();
        
        await sut.WeatherInMostDenseCity();
        
        temperatureService.Verify(x => x.GetLatestTemperature(Dense.Longitude, Dense.Latitude), Times.Once);
    }

    [Fact]
    public async Task PrintNothingIfItsLagomt()
    {
        var sut = CreateSut();
        SetTemperature(7.6d);
        
        await sut.WeatherInMostDenseCity();
        
        logger.Verify(x => x.LogInfo(It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public async Task PrintSnarkyCommentIfTooWarm()
    {
        var sut = CreateSut();
        SetTemperature(12.1d);
        
        await sut.WeatherInMostDenseCity();
        
        logger.Verify(x => x.LogInfo("Norrlandsvarning, kvalmigt!"), Times.Once);
    }

    private WeatherService CreateSut()
    {
        return new WeatherService(repository.Object, temperatureService.Object, densityCalculator.Object, logger.Object);
    }
    
    private static City CreateCity(string name, int p, int a, double lon, double lat)
    {
        return new City { Name = name, Population = p, Area = a, Longitude = lon, Latitude = lat };
    }
    
    private void SetTemperature(double temperature)
    {
        temperatureService.Setup(x => x.GetLatestTemperature(Dense.Longitude, Dense.Latitude)).Returns(Task.FromResult(temperature));
    }
}
