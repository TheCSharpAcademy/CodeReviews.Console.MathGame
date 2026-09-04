namespace MathGame_v2.Model
{
    internal class Game
    {
        public DateTime Date { get; set; }
        public GameType Type { get; set; }
        public int Score { get; set; }
    }
    internal enum GameType
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }
}
