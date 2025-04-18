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
        var sut = CreateSut(1);
        
        var result = sut.Score();
        
        Assert.Equal(1, result);
    }

    [Fact]
    public void TwoRolls1Score2()
    {
        var sut = CreateSut(1, 1);
        
        var result = sut.Score();
        
        Assert.Equal(2, result);
    }
    
    [Fact]
    public void ThreeSingleRollsIsThree() 
    {
        var sut = CreateSut(1, 1, 1);
        
        var result = sut.Score();
        
        Assert.Equal(3, result);
    }

    [Fact]
    public void ThreeSingleRollsAdvancesFrame()   // Här föds iden om frames
    {
        var sut = CreateSut(1, 1, 1);
        
        Assert.Equal(1, sut.CurrentFrame);
    }
    
    [Fact]
    public void SpareReturnsNoScore()
    {
        var sut = CreateSut(1, 9);
        
        var result = sut.Score();
        
        Assert.Equal(0, result);
    }

    [Fact]
    public void SparePlusNextRollReturnsScore()
    {
        var sut = CreateSut(1, 9, 1);
        
        var result = sut.Score();
        
        Assert.Equal(12, result);
    }

    [Fact]
    public void OneStrikePlusTwoOnesIs14()
    {
        var sut = CreateSut(10, 1, 1);
        
        var result = sut.Score();
        
        Assert.Equal(14, result);
    }
    
    [Fact]
    public void OneStrikePlusOnesIs0()  // Aha! Det är ju faktiskt 1? Min förståelse för spelet har ökat...
    {
        var sut = CreateSut(10, 1);
        
        var result = sut.Score();
        
        Assert.Equal(1, result);    
    }
        
    [Fact]
    public void TenStrikesIs300()  // Lämna alltid ett rött test innan man går för dagen
    {
        var sut = CreateSut(10, 10, 10, 10, 10, 10, 10, 10, 10, 10);
        
        var result = sut.Score();
        
        Assert.Equal(300, result);    
    }    
    
    private Game CreateSut(params int[] rolls)
    {
        var game = new Game();
        foreach (var roll in rolls)
        {
            game.Roll(roll);
        }
        return game;
    }
}