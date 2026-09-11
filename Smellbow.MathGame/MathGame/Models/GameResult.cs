
namespace MathGame.Models;

internal class GameResult
{
    public int Score { get; set; }
    public DateTime PlayedAt { get; set; }
    public string Operation { get; set; } = string.Empty;
    public int QuestionCount { get; set; }
}
