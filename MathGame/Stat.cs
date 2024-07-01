namespace MathGame;

public class Stat
{
    public string GameName { get; set; }
    public int CorrectAnswers { get; set; }
    public int  TotalQuestions { get; set; }
    public int DifficultyLevel { get; set; }
    public TimeSpan GameTime { get; set; }
}