namespace MathGame.K_MYR.Models;

internal class Game
{
    private int _score;

    public int Score { get; set; }

    public DifficultyMode Difficulty { get; set; }

    public DateTime Date { get; set; }

    public GameType Type { get; set; }

    public TimeSpan Duration { get; set; }
}

internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
    Random
}

internal enum DifficultyMode
{
    Hard,
    Medium,
    Easy
}

