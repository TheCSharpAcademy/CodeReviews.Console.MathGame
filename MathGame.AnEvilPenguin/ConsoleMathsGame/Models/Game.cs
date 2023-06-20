namespace ConsoleMathsGame.Models;

internal class Game
{
    private int _score;
    private DateTime _date;

    public int Score
    { 
        get { return _score; }
        set { _score = value; }
    }

    public DateTime Date
    {
        get { return _date; }
        set { _date = value; }
    }

    public GameType Type { get; set; }
    public GameDifficulty Difficulty { get; set; }

}

internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}

internal enum GameDifficulty
{
    Beginner,
    Intermediate,
    Master
}