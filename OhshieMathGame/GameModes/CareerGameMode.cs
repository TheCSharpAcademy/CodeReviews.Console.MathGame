namespace OhshieMathGame.GameModes;

public class CareerGameMode
{
    // required variables to make this mode work
    public static int Lives;
    public static int DifficultyLevel;
    private static Random _random = new Random();
    private static List<string> _defaultOperators = new List<string>()
    {
        "+",
        "-",
        "*",
        "/"
    };
    
    public static void GameplayLoop()
    {
        GameController.LoadDefaults();
        GameRecordsKeeper.careerPlayedCounter++;
        
        int cont = 1;
        while (cont == 1 && Lives > 0) 
        {
            GameController.GamesPlayed++;
            
            DifficultySettings();
            
            GameController.GameLogic(true);
            
            cont = GameController.ContinueCheck(cont, true);
        }
        WhenGameFinished();
    }
    
    // method is used as an easy way to adjust difficulty for career game mode
    private static void DifficultySettings()
    {
        switch (GameController.GamesPlayed)
        {
            case (1):
            {
                AdjustOperatorsInPlay();
                GameController.AmountOfVariables = 2;
                DifficultyLevel = 1;
                break;
            }
            case (6):
            {
                AdjustOperatorsInPlay();
                GameController.AmountOfVariables = 3;
                DifficultyLevel = 2;
                break;
            }
            case (11):
            {
                AdjustOperatorsInPlay();
                GameController.AmountOfVariables = 4;
                DifficultyLevel = 3;
                break;
            }
            case (16):
            {
                AdjustOperatorsInPlay();
                GameController.AmountOfVariables = 5;
                DifficultyLevel = 4;
                break;
            }
            case (21):
            {
                GameController.MaxNumber = 20;
                DifficultyLevel = 5;
                break;
            }
        }
    }
    
    // helper method for difficulty settings
    private static void AdjustOperatorsInPlay()
    {
        int operatorChooser = _random.Next(0, GameController.AllPossibleOperators.Count-1);
        GameController.OperatorsInPlay.Add(GameController.AllPossibleOperators[operatorChooser]);
        GameController.AllPossibleOperators.Remove(GameController.AllPossibleOperators[operatorChooser]);
    }
    
    private static void WhenGameFinished()
    {
        Console.Clear();
        if (Lives < 1)
        {
            Console.WriteLine("Dang! You run out of lives.\n" +
                              $"You've solved {GameController.Score} equations our of possible 25");
            GameRecordsKeeper.CurrentScorePrinter();
            return;
        }
        
        if (GameController.GamesPlayed==26)
        {
            Console.WriteLine("You WON");
        }
        else
        {
            Console.WriteLine("You decided to stop.");
        }
        Console.WriteLine($"You still had {Lives} lives left\n" +
                          $"You've solved {GameController.Score} equations our of possible 25");
        GameRecordsKeeper.CurrentScorePrinter();
    }
}