namespace MathGame.stevietv.Models;

internal class Game
{
    public DateTime Date { get; set; }
    public int Score { get; set; }
    public GameType Type { get; set; }
    public Difficulty Difficulty { get; set; }
}

internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
}

internal enum Difficulty
{
    Easy,
    Medium,
    Hard,
}
