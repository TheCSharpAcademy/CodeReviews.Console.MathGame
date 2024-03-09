namespace MathGame.axxon9999.Models
{
    internal class Game
    {
        public DateTime Date { get; set; }
        public GameType Type { get; set; }
        public int Level { get; set; }
        public int Questions { get; set; }
        public int Score { get; set; }
        public string? Time { get; set; }
    }

    internal enum GameType
    {
        Initiation,
        Addition,
        Subtraction,
        Multiplication,
        Division,
        Random
    }
}
