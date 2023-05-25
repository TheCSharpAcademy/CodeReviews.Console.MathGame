using System;

namespace Math_Game;

internal class Timer
{
    private DateTime m_startTime = DateTime.Now;
    private DateTime m_endTime = DateTime.Now;

    public void StartTimer()
    {
        m_startTime = DateTime.Now;
    }
    
    public void StopTimer() 
    {
        m_endTime = DateTime.Now;
    }
    
    public void PrintTimeElapsed()
    {
        double seconds = (m_endTime - m_startTime).TotalSeconds;
        Console.WriteLine($"You finished in {seconds,1:N} seconds.");
    }
}

