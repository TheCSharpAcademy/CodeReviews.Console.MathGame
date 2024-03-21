
namespace MathGame.Arashi256.Models
{
    internal class Game
    {
        public int Score { get; set; }
        public DateTime Date { get; set; }
        public GameType Type { get; set; }
        public Difficulty Difficulty { get; set; }
        public string Time {  get; set; }
    }
}

internal enum GameType { Addition, Subtraction, Multiplication, Division, Random };
internal enum Difficulty { EASY, MEDIUM, HARD };
