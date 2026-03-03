using MathGame.Enums;

namespace MathGame.Models;

public class GameSession
{
    // Fields:
    public DateTime PlayedOn { get; }
    public GameType Game { get; }
    public int Score { get; }
    public int TotalQuestions { get; }
    public TimeSpan Duration { get; } 
    public Difficulty Difficulty { get; }

    // Constructor
    public GameSession(GameType game, int score, int  totalQuestions, TimeSpan duration, Difficulty difficulty)
    {
        PlayedOn = DateTime.Now;
        Game = game;
        Score = score;
        TotalQuestions = totalQuestions;
        Duration = duration;
        Difficulty = difficulty;
    }
}
