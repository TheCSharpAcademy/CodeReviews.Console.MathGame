namespace OhshieMathGame;

public class GameRecordsKeeper
{
    public static List<string> OverallScore = new List<string>();
    private static List<string> TempOverallScore = new List<string>();
    public static int careerPlayedCounter;
    public static int infinitePlayedCounter;
    
    public static void OverallScoreTracker(bool careerGameMode)
    {
        string gamemodeIndicator = "";

        if (careerGameMode)
        {
            gamemodeIndicator = $"{careerPlayedCounter} attempt at Career Gamemode";
            TempOverallScore.Insert(0,gamemodeIndicator);
        }
        else
        {
            gamemodeIndicator = $"{infinitePlayedCounter} attempt at Infinite Gamemode";
            TempOverallScore.Insert(0,gamemodeIndicator);
        }
        
        OverallScore.AddRange(TempOverallScore);
        TempOverallScore.Clear();
    }

    // writes game score/stats into a sting and add it to a list of played games
    public static void CurrentScoreTracker(float playerAnswer, float correctAnswer)
    {
        string gameScoreWritedown = "";
        bool wincheck = playerAnswer == correctAnswer;
        string result;
        float effectiveness;
        
        if (wincheck)
        {
            result = "Your answer was correct!";
            effectiveness = (float)Math.Round(Convert.ToSingle(GameController.Score / GameController.GamesPlayed),2)*100;
        }
        else
        {
            result = "Your answer was incorrect!";
            effectiveness = (float)Math.Round(GameController.Score / GameController.GamesPlayed,2)*100;
        }

        gameScoreWritedown += ($"Round {GameController.GamesPlayed}. {GameController.Equation}={playerAnswer}. It took you {GameController.Timer()} seconds to solve. {result} Accuracy: {effectiveness}%");
        GameController.PrevGames.Add(gameScoreWritedown);
        TempOverallScore.Add(gameScoreWritedown);
    }
    
    // prints out user previous games
    public static void CurrentScorePrinter()
    {
        Console.WriteLine("You did well! Here's a list of rounds played");
            foreach (var record in GameController.PrevGames)
        {
            Console.WriteLine(record);
        }

        Console.WriteLine("Press enter to go back");
        Console.ReadLine();
    }
    public static void OverallScorePrinter()
    {
        Console.Clear();
        Console.WriteLine("Here's all your attempts on in all gamemodes");
        
        foreach (var record in OverallScore)
        {
            Console.WriteLine(record);
        }

        Console.WriteLine("Press enter to go back");
        Console.ReadLine();
    }
}