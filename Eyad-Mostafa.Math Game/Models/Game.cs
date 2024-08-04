namespace Math_Game.Models;

internal class Game
{
    public int Score { get; set; }
    public int NumberOfQuestions { get; set; }
    public int Time {  get; set; }
    public GameType Type { get; set; }
    public DateTime DateTime { get; set; }
    public string GameMode { get; set; }
}

internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}
