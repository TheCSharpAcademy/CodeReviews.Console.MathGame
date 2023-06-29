namespace MyFirstProgram.Models;

internal class Game
{
    public int Score { get; set; }
    public DateTime Date { get; set; }
    public GameType Type { get; set; }
    public string Difficulty { get; set; }
    public int Time { get; set; }
}

internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
    Random
}
