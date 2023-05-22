namespace mathGame.batista92.Models;

internal class Game
{
    public DateTime Date { get; set; }

    public int Score { get; set; }

    public GameType Type { get; set; }

    public int NumberOfQuestions { get; set; }

    public DifficultyLevel Difficulty { get; set; }
    
    public TimeSpan TimeTaken { get; set; }

}

internal enum GameType
{
    Addition,
    Subtraction,
    Multuplication,
    Division,
    Random
}

internal enum DifficultyLevel : int
{
    Easy = 1,
    Medium = 2,
    Hard = 3
}