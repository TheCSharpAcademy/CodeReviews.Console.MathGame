namespace Game.Models;

internal class GameList
{
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