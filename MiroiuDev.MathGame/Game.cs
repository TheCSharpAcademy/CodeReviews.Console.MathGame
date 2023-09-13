namespace MiroiuDev.MathGame;

enum GameType
{
    Addition,
    Substraction,
    Multiplication,
    Division,
    Random
}

internal class Game
{
    public int Score { get; set; }
    public DateTime Date { get; set; }
    public GameType Type { get; set; }
}
