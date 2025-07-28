namespace MathGame.Models;
internal class Game
{
    private int _score;

    public int Score
    {
        get { return _score; }
        set { _score = value; }
    }

    public GameType Type { get; set; }

    public DateTime Date { get; set; }
}

internal enum GameType
{
    Default,
    Addition,
    Subtraction,
    Multiplication,
    Division
}