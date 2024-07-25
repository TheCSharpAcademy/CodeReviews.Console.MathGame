namespace ConsoleApp1.Models;
internal class Game
{
    //private int _score;

    //public int Score {  
    //    get { return _score; } 
    //    set { _score = value; }
    //}

    internal DateTime Date { get; set; }
    internal int Score { get; set; }
    internal int NumOfQ {  get; set; }
    internal GameType Type { get; set; }
    internal GameDifficulty Difficulty { get; set; }
    internal TimeSpan Time { get; set; }

    internal enum GameType
    {
        Addition,
        Substraction,
        Multiplication,
        Division,
        Random
    }

    internal enum GameDifficulty
    {
        Easy,
        Medium,
        Hard
    }
}

