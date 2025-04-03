namespace UtbildningTDD;

public class GameSimulator
{
    private int rolls;
    
    public int Score()
    {
        return rolls;
    }

    public void Roll(int roll)
    {
        rolls += roll;
    }
}