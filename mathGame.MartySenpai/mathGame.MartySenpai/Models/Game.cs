namespace MathGame.Models;
internal class Game
{
    public DateTime Date { get; set; }
    public int Score { get; set; }
    public GameType Type { get; set; }
    public string Difficulty { get; set; }
    public TimeSpan GameTime { get; set; }
    public int NQuestions { get; set; }
}

internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
    Random
}
