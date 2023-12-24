namespace SimpleMathGame.Models;
internal class Game
    {
        public int Score { get; set; }
        public DateTime Date { get; set; }
        public GameType Type { get; set; }
        public int AmountOfQuestions { get; set; }
    }

internal enum GameType
{
    Addition, 
    Subtraction, 
    Multiplication, 
    Division
}
