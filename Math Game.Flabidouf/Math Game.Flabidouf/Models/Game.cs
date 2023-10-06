namespace Math_Game_v2.Models;

public class Game
{
    public DateTime Date { get; set; }
    
    public int Score { get; set; }
    
    internal GameType Type { get; set; }
}

internal enum GameType // To create a more readable code.
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
}