namespace Visualised.CSharpAcademy.MathGame.Models;

internal class Game
{
    public DateTime Date { get; set; }
    public int Score { get; set; }
    public GameType Type { get; set; }
    public GameDifficultyLevels Difficulty { get; set; }
    public TimeSpan ElapsedTime { get; set; }
}

internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
    Random
}

internal enum GameDifficultyLevels
{
    Easy,
    Medium,
    Hard
}