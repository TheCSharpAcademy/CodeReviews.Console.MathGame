namespace MathGame
{
    internal class Game
    {
        internal DateTime Date { get; set; }
        internal int Score { get; set; }

        internal GameType Type { get; set; }

    }

    internal enum GameType
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }
}