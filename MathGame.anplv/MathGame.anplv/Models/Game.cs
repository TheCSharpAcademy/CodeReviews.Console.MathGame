
namespace MathGame.anplv.Models;

internal class Game
{
    public DateTime Date { get; set; }
    public int Score { get; set; }

    public GameType Type { get; set; }

    public string Time { get; set; }
};

    


internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}
