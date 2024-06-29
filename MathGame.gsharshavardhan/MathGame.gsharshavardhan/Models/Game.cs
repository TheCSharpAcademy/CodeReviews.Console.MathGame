namespace MathGame.gsharshavardhan.Models;

internal class Game
{
    public int Score { get; set; }
    public DateTime DatePlayed { get; set; }
    public GameType GameType { get; set; }
}

internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}

internal enum GameMode
{
    Easy,
    Medium,
    Hard
}
