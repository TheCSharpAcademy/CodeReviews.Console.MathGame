namespace PabloMath.Models;

internal class Game
{
    private int _score;

    internal DateTime Date {  get; set; }
    internal int Score { get; set; }
    internal GameType Type { get; set; }
}
internal enum GameType
{
    Addition,
    Subtraction,
    Mulitplication,
    Division
}