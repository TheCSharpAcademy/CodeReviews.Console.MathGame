namespace MathGameConsole.Models;

internal class Game
{
    public int Score { get; set; }
    public DateTime Date { get; set; }
    public GameType Type { get; set; }
    public int TotalQuestions { get; set; }
    public string GameTime { get; set; }
}


internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
    Random
}