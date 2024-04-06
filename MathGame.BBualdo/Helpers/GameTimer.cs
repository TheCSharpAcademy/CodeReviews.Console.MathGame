using System.Timers;

namespace MathGame.BBualdo.Helpers;

internal class GameTimer
{
  public System.Timers.Timer Timer { get; private set; } = new System.Timers.Timer(1000);
  public int TimeInSeconds { get; private set; }

  public GameTimer()
  {
    Timer.Elapsed += Tick;
  }

  public void EnableTimer()
  {
    Timer.Enabled = true;
  }

  public void DisableTimer()
  {
    Timer.Enabled = false;
  }

  private void Tick(object? sender, ElapsedEventArgs e)
  {
    TimeInSeconds++;
  }
}

