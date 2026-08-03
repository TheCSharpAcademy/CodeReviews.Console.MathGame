namespace PRagudo.MathGame;

public record Question
{
    public string Content { get; set; } = string.Empty;
    public int Answer { get; set; }
}
