public class GameResult
{
    public readonly int _score;
    public readonly string _operation;
    public readonly DifficultyLevel _difficultyLevel;
    public readonly TimeSpan _duration;
    public GameResult(int score, string mode, DifficultyLevel difficultyLevel, TimeSpan duration)
    {
        _score = score;
        _operation = mode;
        _difficultyLevel = difficultyLevel;
        _duration = duration;
    }
}