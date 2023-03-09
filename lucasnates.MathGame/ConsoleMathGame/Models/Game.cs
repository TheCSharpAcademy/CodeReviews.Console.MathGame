namespace ConsoleMathGame.Models;

internal class Game
{
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
    public GameType Type { get; set; }
    public GameMode Mode { get; set; }
    public int Score { get; set; }
    public int GamesCount { get; set; }
}

internal enum GameType
{
    Addition,
    Substraction,
    Multiplication,
    Division,
    Randomizer
}

internal enum GameMode
{
    Easy,
    Medium,
    Hard,
    selectedMode2
}
