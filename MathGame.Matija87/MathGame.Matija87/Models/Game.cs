namespace MathGame.Matija87.Models;
internal class Game
{
    public int Score { get; set; }
    public GameType Type { get; set; }
    public DateTime DateTime { get; set; }
    public double Time { get; set; }
    public DifficultyLevel Difficulty { get; set; }

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
}
