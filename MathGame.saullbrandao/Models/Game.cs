namespace MathGame.saullbrandao;

internal class Game
{
    public int Score { get; set; }
    public GameType Type { get; set; }
    public DateTime Date { get; set; }
}

enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}