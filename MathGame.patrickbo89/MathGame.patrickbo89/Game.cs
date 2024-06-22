namespace MathGame.patrickbo89;

internal class Game
{
    public DateTime StartTime { get; set; }
    public GameType Type { get; set; }
    public Difficulty Difficulty { get; set; }

    public int Score { get; set; }
    public int NumberOfQuestions { get; set; }

    public string? ElapsedSeconds { get; set; }
}

internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
    Random
}

internal enum Difficulty
{
    Easy,
    Medium,
    Hard
}