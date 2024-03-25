namespace MyFirstProject.Models;

internal class Game
{
    public DateTime Date { get; set; } 
    public GameType Type {  get; set; }
    public GameDifficulty Difficulty { get; set; }   
    public int Score { get; set; }
    public int PlayTime { get; set; } 
    public int Questions { get; set; }

    internal enum GameType
    {
        Addition,
        Subtraction,
        Multiplication,
        Division,
        RandomMode
    }
    internal enum GameDifficulty
    {
        Easy,
        Medium,
        Hard
    }
}
