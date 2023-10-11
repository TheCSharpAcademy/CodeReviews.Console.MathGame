namespace MathGame.pcjb.Models;

internal class GameResult
{
    public GameResult(GameType type, GameDifficulty difficulty, int score, TimeSpan duration)
    {
        Type = type;
        Difficulty = difficulty;
        Score = score;
        Duration = duration;
    }

    internal GameType Type { get; set; }
    internal GameDifficulty Difficulty { get; set; }
    internal int Score { get; set; }
    internal TimeSpan Duration { get; set; }
}