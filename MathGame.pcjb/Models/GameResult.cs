namespace MathGame.pcjb.Models;

internal class GameResult
{
    public GameResult(GameType type, int score)
    {
        Type = type;
        Score = score;
    }

    internal GameType Type { get; set; }
    internal int Score { get; set; }
}