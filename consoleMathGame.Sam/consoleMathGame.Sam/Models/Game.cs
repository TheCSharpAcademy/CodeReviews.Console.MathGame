namespace consoleMathGame.Sam.Models;

internal class Game
{
    public string userName { get; set; }
    public DateTime Date { get; set; }
    public int Score { get; set; }

    public GameType Type { get; set; }
}

internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}
