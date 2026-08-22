using System.Diagnostics;

public class GameTimer: IGameTimer
{
    private long _startingTimestamp;

    public void Start()
    {
        _startingTimestamp = Stopwatch.GetTimestamp();
    }

    public TimeSpan Stop()
    {
        return Stopwatch.GetElapsedTime(_startingTimestamp);
    }
}