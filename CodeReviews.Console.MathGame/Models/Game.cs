
namespace MyFirstProgram.Models;

    internal class Game
    {

    public int Score { get; set; }
    public GameType Type { get; set; }
    public DateTime Date { get; set; }

    

}

internal enum GameType 
{
    Addition,
    Substraction,
    Multiplication,
    Division
}
