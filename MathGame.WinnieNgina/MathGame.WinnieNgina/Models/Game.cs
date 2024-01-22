
namespace MathGame.WinnieNgina.Models;
internal class Game
{
    /* private int _score; //Private field not exposed to other classes is called a backing field
     public int Score
     {
         get { return _score; }
         set { _score = value; }

     }*/
    public int Score { get; set; }
    public DateTime Date { get; set; }
    public GameType Type { get; set; }
    public DifficultLevel Level { get; set; }

}
internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}
internal enum DifficultLevel
{
    Easy,
    Medium,
    Difficult
}

