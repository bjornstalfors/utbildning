using Xunit;
namespace UtbildningTDD.Tests;

public class GameTests
{
    [Fact]
    public void NoRollsZeroPoints()
    {
        var sut = new Game();
        
        var result = sut.Score();
        
        Assert.Equal(0, result);
    }

    [Fact]
    public void Roll1Score1()
    {
        var sut = new Game();
        
        sut.Roll(1);
        var result = sut.Score();
        
        Assert.Equal(1, result);
    }

    [Fact]
    public void TwoRolls1Score2()
    {
        var sut = new Game();
        
        sut.Roll(1);
        sut.Roll(1);
        
        var result = sut.Score();
        
        Assert.Equal(2, result);
    }
    
    [Fact]
    public void ThreeSingleRollsIsThree()
    {
        var sut = new Game();
        
        sut.Roll(1);
        sut.Roll(1);
        sut.Roll(1);
        var result = sut.Score();
        
        Assert.Equal(3, result);
    }

    [Fact]
    public void ThreeSingleRollsAdvancesFrame()
    {
        var sut = new Game();
        
        sut.Roll(1);
        sut.Roll(1);
        sut.Roll(1);
        
        Assert.Equal(1, sut.CurrentFrame);
    }
    
    [Fact]
    public void SpareReturnsNoScore()
    {
        var sut = new Game();
        
        sut.Roll(1);
        sut.Roll(9);
        var result = sut.Score();
        
        Assert.Equal(0, result);
    }

    [Fact]
    public void SparePlusNextRollReturnsScore()
    {
        var sut = new Game();
        
        sut.Roll(1);
        sut.Roll(9);
        sut.Roll(1);
        var result = sut.Score();
        
        Assert.Equal(12, result);
    }

    [Fact]
    public void OneStrikePlusTwoOnesIs14()
    {
        var sut = new Game();
        sut.Roll(10);
        sut.Roll(1);
        sut.Roll(1);
        var result = sut.Score();
        
        Assert.Equal(14, result);
    }
    
    [Fact]
    public void OneStrikePlusOnesIs0()
    {
        var sut = new Game();
        sut.Roll(10);
        sut.Roll(1);
        var result = sut.Score();
        
        Assert.Equal(0, result);
    }    
}