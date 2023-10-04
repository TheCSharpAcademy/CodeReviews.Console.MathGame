namespace MathGame.wkktoria.Models;

internal class Game
{
    public DateTime Date { get; init; }
    public int Score { get; init; }
    public GameType Type { get; init; }
    public DifficultyLevel Difficulty { get; init; }
    public double Time { get; init; }
}

internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}

internal enum DifficultyLevel
{
    Easy,
    Medium,
    Hard
}