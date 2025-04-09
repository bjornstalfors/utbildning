namespace UtbildningTDD;

public class Game
{
    private readonly Frame[] frames = new Frame[10];
    private bool frameComplete;

    public Game()
    {
        CurrentFrame = 0;
        for (var i = 0; i < 10; i++)
        {
            frames[i] = new Frame(i);
        }
        
        for (var i = 0; i < 9; i++)
        {
            frames[i].NextFrame = frames[i + 1];
        }
    }
    
    public int CurrentFrame { get; private set; }

    public int Score()
    {
        return frames.Sum(x => x.Score());
    }

    public void Roll(int roll)
    {
        frameComplete = frames[CurrentFrame].Roll(roll);
        if (frameComplete)
        {
            CurrentFrame++;
        }
    }
}

internal class Frame(int index)
{
    private readonly List<int> rolls = [];
    
    public Frame? NextFrame { get; set; }

    public bool Roll(int roll)
    {
        rolls.Add(roll);
        return IsStrike || rolls.Count == 2;
    }
    
    private bool IsSpare => rolls.Count == 2 && rolls.Sum() == 10;
    
    private bool IsStrike => rolls.Count == 1 && rolls.Sum() == 10;
    
    private int Bonus1 => NextFrame.rolls[0];
    
    private int Bonus2 => NextFrame.rolls[1];
    
    
    private bool HasRolls => rolls.Count > 0;

    public int Score()
    {
        if (IsSpare && NextFrame is not null && NextFrame.HasRolls)
        {
            return 10 + NextFrame.rolls[0];
        }
        
        if (IsStrike && NextFrame is not null && NextFrame.rolls.Count == 2)
        {
            return 10 + NextFrame.rolls[0] + NextFrame.rolls[1];
        }    

        return IsSpare || IsStrike ? 0 : rolls.Sum();
    }
}