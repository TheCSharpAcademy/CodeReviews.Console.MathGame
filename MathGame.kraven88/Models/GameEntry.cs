namespace MathGame.Models;

internal class GameEntry
{
    required internal string GameType { get; set; }
    required internal int NumberOfRounds { get; set; }
    required internal Difficulty Difficulty { get; set; }
    internal int Score { get; set; } = 0;
    internal TimeSpan CompletionTime { get; set; }
}

internal enum Difficulty
{
    NotSelected = 0,
    Easy = 1,
    Medium = 2,
    Hard = 3,
}