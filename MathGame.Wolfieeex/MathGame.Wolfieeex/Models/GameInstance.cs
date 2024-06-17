namespace MathGame.Wolfieeex.Models;

internal class GameInstance
{
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public int Score { get; set; }
    public GameModes Type { get; set; }
    public GameDifficulty Difficulty { get; set; }
    public int QuestionsCount { get; set; }
    public int Time { get; set;}
}
