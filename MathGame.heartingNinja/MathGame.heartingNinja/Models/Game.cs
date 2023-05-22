namespace MathProject.Models;

internal class Game
{
    public DateTime Date { get; set; }

    public int Score { get; set; }

    public GameType Type { get; set; }

    public GameDifficulty Difficulty { get; set; }
}

internal enum GameDifficulty
{
    Easy,
    Medium,
    Hard,
}

internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
}
