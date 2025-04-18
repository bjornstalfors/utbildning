using Xunit;

namespace UtbildningSEAMS.External.Tests;

public class RepositoryTests
{
    [Fact]
    public void ReturnsAllCities()
    {
        var sut = CreateSut();
        
        // ??????
    }

    private Repository CreateSut()
    {
        return new Repository(null!); /// Hur testar vid den här???
    }
}