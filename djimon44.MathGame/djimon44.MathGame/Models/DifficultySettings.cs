namespace MathGame.Models;

public class DifficultySettings
{
    public int MaxValue { get; }
    public int TimeLimitSeconds { get; }

    public DifficultySettings(int maxValue, int timeLimitSeconds)
    {
        MaxValue = maxValue;
        TimeLimitSeconds = timeLimitSeconds;
    }
}
