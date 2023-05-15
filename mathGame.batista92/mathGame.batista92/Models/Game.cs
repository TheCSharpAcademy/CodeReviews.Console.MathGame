namespace mathGame.batista92.Models;

internal class Game
{
    public DateTime Date { get; set; }

    public int Score { get; set; }

    public GameType Type { get; set; }

    public int NumberOfQuestions { get; set; }

}

internal enum GameType
{
    Addition,
    Subtraction,
    Multuplication,
    Division,
    Random
}