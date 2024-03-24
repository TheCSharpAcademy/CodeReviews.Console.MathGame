namespace MathGame.basemkasem.Modles;

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
    Easy,
    Medium,
    Hard
}