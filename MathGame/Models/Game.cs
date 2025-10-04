namespace MathGame.Models;

internal class Game
{
    //private int _score;
    //public int Score
    //{
    //    get { return _score; } 
    //    set { _score = value; }
    //} Same down below
    public int Score { get; set; }

    public DateTime Date { get; set; }
    public GameType Type { get; set; }
    
    public DifficultyOptions Difficulty { get; set; }
    public TimeSpan Duration { get; set; }
}

internal enum GameType
{
    Addition,
    Substraction,
    Multiplication,
    Division
}

internal enum DifficultyOptions
{
    Easy,
    Normal,
    Hard,
    None
}