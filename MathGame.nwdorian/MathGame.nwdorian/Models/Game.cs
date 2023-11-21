namespace MathGame.nwdorian.Models;

internal class Game
{
    public int Score { get; set; }
    public DateTime Date { get; set; }
    public GameType Type { get; set; }
    public GameDifficulty Difficulty { get; set; }
}

internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}

internal enum GameDifficulty
{
    Easy,
    Normal,
    Hard
}