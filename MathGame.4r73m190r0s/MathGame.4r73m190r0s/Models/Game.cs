namespace MathGame._4r73m190r0s.Models;

internal class Game
{
    public int Score { get; set; }
    public GameType Type { get; set; }
    public DateTime Date { get; set; }

    public override string ToString()
    {
        return $"Game: {Type,-20} Score: {Score,-10} Date: {Date,-15:f}";
    }
}

internal enum GameType
{
    Addition,
    Subtraction,
    Division,
    Multiplication
}
