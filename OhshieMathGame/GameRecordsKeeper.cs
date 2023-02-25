public class GameRecordsKeeper
{
    private static List<string> _overallScore = new List<string>();
    private static List<string> _tempOverallScore = new List<string>();
    public static int CareerPlayedCounter;
    public static int InfinitePlayedCounter;
    
    public void OverallScoreTracker(bool careerGameMode)
    {
        string gamemodeIndicator;

        if (careerGameMode)
        {
            gamemodeIndicator = $"{CareerPlayedCounter} attempt at Career Gamemode";
            _tempOverallScore.Insert(0,gamemodeIndicator);
        }
        else
        {
            gamemodeIndicator = $"{InfinitePlayedCounter} attempt at Infinite Gamemode";
            _tempOverallScore.Insert(0,gamemodeIndicator);
        }
        
        _overallScore.AddRange(_tempOverallScore);
        _tempOverallScore.Clear();
    }

    // writes game score/stats into a sting and add it to a list of played games
    public void CurrentScoreTracker(int playerAnswer, int correctAnswer, GameController currentGame)
    {
        string gameScoreWritedown = "";
        bool winCheck = playerAnswer == correctAnswer;
        string result;
        string effectiveness;
        
        if (winCheck)
        {
            result = "Your answer was correct!";
            effectiveness = $"{currentGame.Score / currentGame.GamesPlayed:0.0%}";
        }
        else
        {
            result = "Your answer was incorrect!";
            effectiveness = $"{currentGame.Score / currentGame.GamesPlayed:0.0%}";
        }

        gameScoreWritedown += ($"Round {currentGame.GamesPlayed}. {currentGame.Equation}={playerAnswer}. It took you {currentGame.Timer()} seconds to solve. {result} Accuracy: {effectiveness}%");
        _tempOverallScore.Add(gameScoreWritedown);
    }

    public void CurrentScorePrinter()
    {
        Console.Clear();
        Console.WriteLine("Well done! Here's a summary of how you did on your most recent run.:");
        foreach (var record in _tempOverallScore)
        {
            Console.WriteLine(record);
        }

        Console.WriteLine("Press any key to go proceed");
        Console.ReadLine();
    }
    
    public void OverallScorePrinter()
    {
        Console.Clear();
        Console.WriteLine("Here's all your attempts on in all gamemodes");
        
        foreach (var record in _overallScore)
        {
            Console.WriteLine(record);
        }

        Console.WriteLine("Press enter to go back");
        Console.ReadLine();
    }
}