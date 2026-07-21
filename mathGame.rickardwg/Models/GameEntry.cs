using MathGame.Enums;

namespace MathGame.Models;

internal class GameEntry
{
    internal int Id { get; set; }
    internal GameMode GameMode { get; set; }
    internal Difficulty Difficulty { get; set; }
    internal int CorrectAnswers { get; set; }
    internal int TotalQuestions { get; set; }
    internal TimeSpan TimeTaken { get; set; }
}
