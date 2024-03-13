namespace MathGame.Antonderegt;

public class Result
{
    public string? Question { get; set; }
    public bool Correct { get; set; }

    public Result(string q, bool c)
    {
        Question = q;
        Correct = c;
    }
}