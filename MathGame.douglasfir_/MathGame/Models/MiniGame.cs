namespace MathGame.Models;

internal class MiniGame
{
    public DateTime Date { get; set; }
    public int Score { get; set; }
    public GameType gameType { get; set; }
    public QuestionType questionType { get; set; }
    public DifficultyLevel difficultyLevel { get; set; }
}