namespace MathGamer.Models;

internal class Game
{
    public int Score { get; set; }
    public DateTime Date { get; set; }
    public GameType Type { get; set; }


    public override string ToString()
    {
        return $"{Date} - {Type}: {Score} pts";
    }

    public enum GameType
    {
        Addition,
        Subtraction,
        Multiplication,
        Division,
    }
}
