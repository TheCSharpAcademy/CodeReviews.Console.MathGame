namespace MathGame.Kriz_J;

public record ScoreRecord(int Score)
{
    public DateTime Timestamp { get; } = DateTime.Now;
    public string? Game { get; set; }
    public Mode Mode { get; set; }
    public Difficulty Difficulty { get; set; }
    public int NumberOfQuestions { get; set; }
    public TimeSpan? TimeNeeded { get; set; }
    public double PercentageScore => 100.0 * Score / NumberOfQuestions;
}