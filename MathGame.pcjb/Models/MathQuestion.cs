namespace MathGame.pcjb.Models;

internal abstract class MathQuestion
{
    internal int maxNumber;
    public GameType Type { get; }
    public string? Text { get; internal set; }
    public string? ExpectedAnswer { get; internal set; }
    public string? ActualAnswer { get; set; }

    public MathQuestion(GameType type, GameDifficulty difficulty)
    {
        Type = type;
        maxNumber = difficulty switch {
            GameDifficulty.Easy => 9,
            GameDifficulty.Normal => 99,
            GameDifficulty.Hard => 999,
            _ => throw new NotImplementedException(),
        };
    }

    public bool HasCorrrectAnswer()
    {
        return ActualAnswer != null && ActualAnswer.Equals(ExpectedAnswer);
    }
}