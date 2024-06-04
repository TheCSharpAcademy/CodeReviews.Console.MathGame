namespace MathGame.javedkhan2k2.Models;

internal class Game
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int NumberOfQuestions { get; set; }
    public int Score { get; set; }

    public GameType Type { get; set; }
    public GameDifficulty Difficulty { get; set; }
}

internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
    Random
}

internal enum GameDifficulty
{
    Easy = 9,
    Normal = 99,
    Hard = 999
}
