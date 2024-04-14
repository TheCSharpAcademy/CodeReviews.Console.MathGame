namespace MathGame.lilWe3zy;

public class History(int difficulty, int operation, int score, int length, TimeSpan timespan)
{
    public readonly DateTime Id = DateTime.Now;
    public readonly int Difficulty = difficulty;
    public readonly int Operation = operation;
    public readonly int Score = score;
    public readonly int QuestionLength = length;
    public readonly TimeSpan TimeElapsed = timespan;
}