public class ScoreHistory
{
    public int Score { get; set; }
    public TimeSpan Time { get; set; }

    public string FormatTime()
    {
        return String.Format("{0:00}:{1:00}:{2:00}",
            Time.Hours, Time.Minutes, Time.Seconds);
    }
}