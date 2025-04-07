using Xunit;
namespace UtbildningTDD.Tests;

public class GameSimulatorTests
{
    [Fact]
    public void NoRollsZeroPoints()
    {
        var sut = new GameSimulator();
        
        var result = sut.Score();
        
        Assert.Equal(0, result);
    }

    [Fact]
    public void Roll1Score1()
    {
        var sut = new GameSimulator();
        
        sut.Roll(1);
        var result = sut.Score();
        
        Assert.Equal(1, result);
    }

    [Fact]
    public void TwoRolls1Score2()
    {
        var sut = new GameSimulator();
        
        sut.Roll(1);
        sut.Roll(1);
        var result = sut.Score();
        
        Assert.Equal(2, result);
    }
    
    [Fact]
    public void SpareReturnsNoScore()
    {
        var sut = new GameSimulator();
        
        sut.Roll(1);
        sut.Roll(9);
        var result = sut.Score();
        
        Assert.Equal(0, result);
    }

    
}