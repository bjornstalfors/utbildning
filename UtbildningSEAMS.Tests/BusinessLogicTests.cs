using Xunit;

namespace UtbildningSEAMS.Tests;

public class BusinessLogicTests
{
    [Fact]
    public async Task ReturnsCityWithHighestPopulationDensity()
    {
        // Arrange
        var sut = CreateSut();
        
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
        return new BusinessLogic();
    }
}