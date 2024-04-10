namespace MathGame.Models;

internal class MiniGame
{
    public DateTime Date { get; set; }
    public int Score { get; set; }
    public GameType GameType { get; set; }
    public QuestionType QuestionType { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; }
}