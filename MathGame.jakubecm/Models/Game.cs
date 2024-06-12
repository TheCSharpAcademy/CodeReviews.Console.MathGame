using System.Diagnostics;

namespace MathGame.jakubecm.Models;

internal class Game
{
    public DateTime Date { get; set; }
    public int Score { get; set; }
    public int MaxScore { get; set; }
    public GameType Type { get; set; }
    public TimeSpan Time { get; set; }
}

internal enum GameType
{
    Addition,
    Subtraction,
    Division,
    Multiplication,
    Random
}
