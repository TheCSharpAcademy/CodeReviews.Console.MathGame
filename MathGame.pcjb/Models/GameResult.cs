namespace MathGame.pcjb.Models;

internal class GameResult
{
    public GameResult(GameType type, GameDifficulty difficulty, int score)
    {
        Type = type;
        Difficulty = difficulty;
        Score = score;
    }

    internal GameType Type { get; set; }
    internal GameDifficulty Difficulty { get; set; }
    internal int Score { get; set; }
}