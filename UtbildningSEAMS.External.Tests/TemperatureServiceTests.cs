using UtbildningSEAMS.Business.Application.Ports;
using Xunit;

namespace UtbildningSEAMS.External.Tests;

public class TemperatureServiceTests
{
    [Fact]
    public async Task ReturnsNullOnBadRequest()
    {
        var sut = CreateSut();
        
        // ????? Hur testar vi den här????? Just nu är detta ett integrationstest...
        var result = await sut.GetLatestTemperature(12.34d, 23.45d);
        
        Assert.Null(result);
    }
    
    private ITemperatureService CreateSut()
    {
        return new TemperatureService();
    }
}