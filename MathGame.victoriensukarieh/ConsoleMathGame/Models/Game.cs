namespace ConsoleMathGame.Models;
internal class Game
{
    public GameType Type { get; set; }
    public string Player { get; set; }
    public int Score { get; set; }
    public DateTime Date { get; set; }
    public string Level { get; set; }
    public int NumberOfQuestion { get; set; }
    public int Time { get; set; }


    internal enum GameType
    {
        Addition,
        Subtraction,
        Multiplication,
        Division,
        Frenzy
    }


}
