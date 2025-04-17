using Moq;
using Xunit;

namespace UtbildningSEAMS.Tests;


public class BusinessLogicTests
{
    private readonly Mock<IRepository> repositoryMock = new();
    
    
    [Fact]
    public async Task ReturnsCityWithHighestPopulationDensity()
    {
        // Arrange
        var sut = CreateSut();
        
        repositoryMock.Setup(x => x.GetCities()).Returns([
            new City { Name = "Paris", Population = 2_165_423, Area = 105, Longitude = 12.2, Latitude = 34.2 },
            new City { Name = "Strömsund", Population = 3423, Area = 10005, Longitude = 25.2, Latitude = 56.2 }
        ]);
        
        // Act
        var result = await sut.WeatherInMostDenseCity();
        
        // Assert
        Assert.Equal("Paris", result.Item1);
        Assert.Equal(9.7d, result.Item2);  // Worked at 08.54 today
    }
    
    [Fact]
    public async Task PrintSomethingSnarkyIfTheirWeatherIsTooGood()
    {
        var sut = CreateSut();
        
        var result = await sut.WeatherInMostDenseCity();
        
        //Assert.Equal("!", ??????);
    }

    private BusinessLogic CreateSut()
    {
        //return new BusinessLogic(new TestRepository());
        
        return new BusinessLogic(repositoryMock.Object);
    }
}