namespace MathGame.Models;

internal class Game
{
    // creates _score and applies set/get
    public int Score { get; set; }

    public DateTime Date { get; set; }

    public GameType Type { get; set; }

    public DifficultyLevel Difficulty { get; set; }

    public int TimeToFinsh{get;set;}

    public int NumberOfQuestions { get; set; }
}

internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
    Random
}

internal enum DifficultyLevel
{
    Easy,
    Medium,
    Hard
}

