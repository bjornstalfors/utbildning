using UtbildningSEAMS.Business.Application.Ports;
using UtbildningSEAMS.External;
using Xunit;

namespace UtbildningSEAMS.Tests;

public class TemperatureServiceTests
{
    [Fact]
    public void ReturnsNullOnBadRequest()
    {
        var sut = CreateSut();
        
        // ????? Hur testar vi den här?????
        var result = sut.GetLatestTemperature(12.34d, 23.45d);
        
        Assert.Null(result);
    }
    
    private ITemperatureService CreateSut()
    {
        return new TemperatureService();
    }
}