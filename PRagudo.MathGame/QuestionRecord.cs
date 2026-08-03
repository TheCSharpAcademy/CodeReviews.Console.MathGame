namespace PRagudo.MathGame;

public record QuestionRecord
{
    public Question Content { get; set; }
    public int PlayerAnswer { get; set; }
    public bool Correct { get; set; }
};