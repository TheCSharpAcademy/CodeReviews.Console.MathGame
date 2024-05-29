namespace MathGame.Models;

internal class Game
{
    /*private int _score;

    public int Score
    {
        get { return _score; }
        set { _score = value; }
    }*/

    // Auto property - does the same thing as the code above with the backing field, just with fewer lines of code
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