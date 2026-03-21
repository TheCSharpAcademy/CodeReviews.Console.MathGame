namespace MathGame.Models;

internal class Game
{
    private int _score;

    //public int Score
    //{
    //    get { return _score; }
    //    set { _score = value; }
    //}
    public DateTime Date { get; set; }

    public byte Score { get; set; }
    public GameType Type { get; set; }
    public DifficultyLevel Difficulty { get; set; }
    public TimeSpan TimeTaken { get; set; }
}

internal enum DifficultyLevel
{
    Easy,
    Medium,
    Hard
}

internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
    Random
}