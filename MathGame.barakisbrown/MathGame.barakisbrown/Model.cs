namespace MathGame.barakisbrown;

internal class Model
{
    public int Score { get; set; }
    public GameType Type { get; set; }
    public DateTime Date { get; set; }
    public Diffuclty_Levels Levels { get; set; }

    public override string ToString()
    {
        return $"Game: {Type,-20} Score: {Score,-10} Date {Date,-15:f} \t Diffculty Level {Levels, -20} ";
    }
}

internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
    RandomOperations
}

internal enum Diffuclty_Levels
{
    Beginnger = 10,
    Moderate = 50,
    Expert = 100
}

internal enum MenuOptions
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
    RandomGame,
    ListGamesPlayed,
    ChangeDifficulty,
    Quit
}