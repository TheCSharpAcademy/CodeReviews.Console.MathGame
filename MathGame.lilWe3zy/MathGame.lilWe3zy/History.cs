namespace MathGame.lilWe3zy;

public class History(int difficulty, int operation, int score, int length)
{
    public DateTime Id = DateTime.Now;
    public int Difficulty = difficulty;
    public int Operation = operation;
    public int Score = score;
    public int QuestionLength = length;
}