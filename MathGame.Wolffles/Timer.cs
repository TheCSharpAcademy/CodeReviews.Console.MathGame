using System;

namespace Math_Game;

internal class Timer
{
    private DateTime m_startTime = DateTime.Now;
    private DateTime m_endTime = DateTime.Now;

    public void startTimer()
    {
        m_startTime = DateTime.Now;
    }
    
    public void stopTimer() 
    {
        m_endTime = DateTime.Now;
    }
    
    public void printTimeElapsed()
    {
        double seconds = (m_endTime - m_startTime).TotalSeconds;
        Console.WriteLine($"You finished in {seconds,1:N} seconds.");
    }
}

