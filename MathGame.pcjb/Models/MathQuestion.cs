namespace MathGame.pcjb.Models;

internal abstract class MathQuestion
{
    internal int maxNumber = 99;
    public GameType Type { get; }
    public string? Text { get; internal set; }
    public string? ExpectedAnswer { get; internal set; }
    public string? ActualAnswer { get; set; }

    public MathQuestion(GameType type)
    {
        Type = type;
    }

    public bool HasCorrrectAnswer()
    {
        return ActualAnswer != null && ActualAnswer.Equals(ExpectedAnswer);
    }
}