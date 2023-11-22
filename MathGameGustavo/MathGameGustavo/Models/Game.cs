namespace MathGameGustavo.Models
{
    internal class Game
    {
        public DateTime Date { get; set; }
        public int Score { get; set; }
        public GameType Type { get; set; }
        public int QuestionNumber { get; set; }
        public long TimeElapsed { get; set; }

    }
    internal enum GameType
    {
        Addition,
        Subtraction,
        Multiplication,
        Division,
        Random,
    }
}
