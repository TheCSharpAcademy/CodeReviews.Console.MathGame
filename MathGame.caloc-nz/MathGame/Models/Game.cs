namespace MathGame.Models;

internal class Game
{
    internal DateTime Date { get; set; }

    internal int Score { get; set; }

    internal GameType Type { get; set; }
}

internal enum GameType
{
    Addition,
    Division,
    Multiplication,
    Subtraction
}