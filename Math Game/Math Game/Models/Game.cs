namespace Math_Game.Models;

internal class Game
{
    private int _score;
    public int Score { get; set; }
    public DateTime Date { get; set; }
    public GameType Type { get; set; }
}

internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}