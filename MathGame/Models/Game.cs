namespace MathGame.Models;

internal class Game
{
    public int Score { get; set; }

    public DateTime Date { get; set; }

    public GameType Type { get; set; }

    public DifficultyLevel Difficulty { get; set; }

    public int TotalQuestions { get; set; }

}

internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
}

internal enum DifficultyLevel
{
    Easy,
    Regular,
    Hard,
}
