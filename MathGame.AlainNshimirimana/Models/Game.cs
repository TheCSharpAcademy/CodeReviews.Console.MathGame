namespace MathGame.AlainNshimirimana.Models;

internal class Game
{
    //private int _score;
    //public int Score
    //{
    //    get { return _score; }
    //    set { _score = value; }
    //}
    public DateTime Date { get; set; }
    public int Score { get; set; } 
    public GameType Type { get; set; }
    internal Difficulty Level { get; set; }
}

internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}

internal enum Difficulty
{
    Easy = 1,
    Medium,
    Hard
}
