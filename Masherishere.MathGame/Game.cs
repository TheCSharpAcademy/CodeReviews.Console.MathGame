namespace Masherishere.MathGame
{
    internal class Game
    {
        public Game(DateTime Date, int Score, GameType Type)
        {
            this.Date = Date;
            this.Score = Score;
            this.Type = Type;
        }

        internal DateTime Date { get; set; }
        internal int Score { get; set; }
        internal GameType Type { get; set; }
    }

    internal enum GameType
    {
        Addition,
        Substraction,
        Multiplication,
        Division
    }
}
