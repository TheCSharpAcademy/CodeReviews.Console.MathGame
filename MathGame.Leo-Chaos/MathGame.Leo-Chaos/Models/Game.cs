namespace BasicMathsProject.Models;

internal class Game
{
    internal int Score { get; set; }

    internal DateTime Date { get; set; }

    internal GameType Type { get; set; }

    internal Difficulty Level { get; set; }
}

internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}

internal enum Difficulty
{
    Easy = 1,
    Medium,
    Hard
}
