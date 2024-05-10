namespace MathGame.Kriz_J;

public record ScoreRecord
{
    public string Game { get; set; }
    public int Score { get; set; }
    public int NumberOfQuestions { get; set; }
    public TimeSpan Time { get; set; }
}