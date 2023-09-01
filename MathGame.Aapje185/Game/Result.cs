namespace C_Sharp_Academy.Game;

using Enums;

public class Result
{
    internal DateTimeOffset Date { get; }
    internal Type Type { get; }
    internal int Score { get; }

    public Result(Type type, int score)
    {
        Date = DateTimeOffset.UtcNow;
        Type = type;
        Score = score;
    }
}