namespace MathGame.Models;

internal class Game
{
    public Game(DateTime startTime, IOperation operation)
    {
        StartTime = startTime;
        Operation = operation;
    }

    public DateTime StartTime { get; }
    public IOperation Operation { get; }
    public IList<Round> Rounds { get; } = new List<Round>();
}
