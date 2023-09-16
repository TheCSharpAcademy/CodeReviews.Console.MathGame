namespace MathGame.Matija87.Models;
internal class Game
{
    public int Score { get; set; }
    public GameType Type { get; set; }
    public DateTime DateTime { get; set; }

    internal enum GameType
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }
}
