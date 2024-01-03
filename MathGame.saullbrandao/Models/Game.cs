namespace MathGame.saullbrandao;

internal class Game
{
    public int Score { get; set; }
    public GameType Type { get; set; }
    public DateTime Date { get; set; }
    public GameDifficulty Difficulty { get; set; }
}

enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}

enum GameDifficulty
{
    Easy = 10,
    Normal = 100,
    Hard = 1000
}