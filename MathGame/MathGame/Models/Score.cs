namespace MathGame.Models;

internal class Score()
{
    public GameType Type { get; set; }
    public int Points { get; set; }
    public DateTime Date { get; set; }
}

internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
}