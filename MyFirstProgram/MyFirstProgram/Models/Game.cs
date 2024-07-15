namespace MyFirstProgram.Models;

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
    
    internal GameType Type { get; set; }
}

internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
}
