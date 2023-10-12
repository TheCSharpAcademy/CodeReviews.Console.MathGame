namespace MathGame_CSA;

public class GameResult
{
    public int CorrectAnswers { get; }
    public int Questions { get; }
    public DateTime End { get; }
    public TimeSpan GameTime { get; }
    public GameResult(int correctAnswers, int questions, DateTime end, TimeSpan gameTime)
    {
        CorrectAnswers = correctAnswers;
        Questions = questions;
        End = end;
        GameTime = gameTime;
    }

    public override string ToString() =>
        $"Date: {End} Correct answers: {CorrectAnswers} Total questions: {Questions} End: {End} GameTime: {GameTime.TotalSeconds:0.00}s";
}
