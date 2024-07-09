using System.Diagnostics;

namespace MathGame.kwm0304.Models;

public class GameTimer
{
    private readonly Stopwatch _stopwatch;
    public GameTimer()
    {
      _stopwatch = new Stopwatch();
    }
    public void Start()
    {
      _stopwatch.Restart();
      _stopwatch.Start();
    }
    public void Stop()
    {
      _stopwatch.Stop();
    }
    public TimeSpan ElapsedTime => _stopwatch.Elapsed;
}
