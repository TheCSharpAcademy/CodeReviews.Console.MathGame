namespace MathGameLibrary.Models;

public class Game
{
    public DateTime Date { get; set; }
    public int Score { get; set; }
    public GameType GameType { get; set; }
    public Difficulty Difficulty { get; set; }
}
