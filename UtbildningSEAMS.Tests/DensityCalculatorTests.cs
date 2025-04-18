using UtbildningSEAMS.Business.Application.Ports;
using UtbildningSEAMS.Business.Domain;
using Xunit;

namespace UtbildningSEAMS.Tests;

public class DensityCalculatorTests
{
    [Fact]
    public void NoCitiesReturnsNull()
    {
        var sut = CreateSut();
        
        Assert.Null(sut.FindDensestCity([]));
    }

    [Fact]
    public void OneCityIsDensestByItself()
    {
        var sut = CreateSut();
        var city = CreateCity();
        
        var result = sut.FindDensestCity([city]);
        
        Assert.Same(city, result);
    }

    [Fact]
    public void ReturnsDensestCity()
    {
        var sut = CreateSut();
        var dense = CreateCity(population: 1000, area: 1);
        var sparse = CreateCity(population: 1, area: 1000);
        
        var result = sut.FindDensestCity([dense, sparse]);
        
        Assert.Same(dense, result);
    }
    
    // TODO Finns det några fler testfall här jag vill täcka av?

    private static City CreateCity(int population = 1, int area = 1)
    {
        return new City
        {
            Area = area,
            Population = population
        };
    }

    private IDensityCalculator CreateSut()
    {
        return new DensityCalculator();
    }
}
