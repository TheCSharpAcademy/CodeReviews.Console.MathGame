namespace firstAppCalculator.Models;

internal class Game
{
    public DateTime Date { get; set; }

    public int Score { get; set; }

    public GameType Type { get; set; }

    public int Amount { get; set; }

    public string Difficulty { get; set; }

    public TimeSpan TimeSpanned { get; set; }
}

internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
    Random
}