namespace mathGame.mtmattei.Models;

internal class Game
{
    public DateTime Date { get; set; }

    public int Score { get; set; }

    public GameType Type { get; set; }

}

internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Divsion
}






/*private int _score;

public int Score
{
    get { return _score; }
    set { _score = value; }
}*/
