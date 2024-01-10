namespace MathGame.frockett.Models;

internal class Game
{
    public DateTime Date { get; set; }
    public int Score { get; set; }
    public string? Type { get; set; }
    public Difficulty Difficulty { get; set; }
    public double Time { get; set; }
}

// This struct matches difficulty variables, idk if there's a better way to accomplish this
internal struct Level
{
    public int Maximum { get; set; }
    public Difficulty Difficulty { get; set; }
}

internal enum Difficulty
{
    Easy,
    Medium,
    Hard,
    Insane,
}
