using MathGameLibrary.Logic;

namespace MathGameLibrary.Player;
public class Player
{
    public string PlayerName { get; set; } = string.Empty;
    public List<Game> GameHistory { get; set; } = new List<Game>();
    public double Score
    {
        get
        {
            double total = 0;
            foreach (Game game in GameHistory)
            {
                total += game.Score;
            }
            return total / GameHistory.Count;
        }
    }
}
