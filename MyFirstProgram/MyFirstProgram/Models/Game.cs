
namespace MyFirstProgram.Models;

internal class Game
{

    // public int Score
    // {
    //     get { return score; }
    //     set { score = value; }
    // }

    public int Score { get; set; }
    public DateTime Date { get; set; }
    public GameType Type { get; set; }
    public DifficultyLevel Difficulty { get; set; }
}

internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}

internal enum DifficultyLevel
{
    Easy,
    Medium,
    Hard
}
