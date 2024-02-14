namespace mathGame.kriegerKeira.Models;
public class Game
{
    public DateTime Date { get; set; }
    public int Score { get; set; }
    public GameType Type { get; set; }
}

public enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}