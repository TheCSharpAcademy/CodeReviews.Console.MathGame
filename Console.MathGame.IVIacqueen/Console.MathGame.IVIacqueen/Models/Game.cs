namespace MathGame.Models;

internal class Game
{
    public GameMode Mode { get; set; }

    public int Score { get; set; }

    public int NumberOfProblems { get; set; }

    public int Time { get; set; }

    public GameDifficulty Difficulty { get; set; }
}

internal enum GameMode
{
    Addition,           // 0
    Subtraction,        // 1
    Multiplication,     // 2
    Division,           // 3
    Random              // 4
}

internal enum GameDifficulty
{
    Easy,       // 0
    Medium,     // 1
    Hard        // 2
}
