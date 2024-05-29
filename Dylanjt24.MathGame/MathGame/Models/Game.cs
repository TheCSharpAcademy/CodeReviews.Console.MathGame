namespace MathGame.Models;

internal class Game
{
    // Auto property - creates backing field behind the scenese
    public int Score { get; set; }
    public DateTime Date { get; set; }
    public GameType Type { get; set; }
    public GameDifficulty Difficulty { get; set; }
    public int SecondsTaken { get; set; }
}

// Create enumeration type to store game type played
internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
    Random
}

// Create difficulty enum to reference it by number
internal enum GameDifficulty
{
    Easy,
    Medium,
    Hard
}