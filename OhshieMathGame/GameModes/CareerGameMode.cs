using NCalc;

namespace OhshieMathGame.GameModes;

public class CareerGameMode
{
    // required variables to make this mode work
    public static int Lives;
    private static int _difficultyLevel;

    private static Random _random = new Random();

    private static void AdjustOperatorsInPlay()
    {
        int operatorChooser = _random.Next(0, GameController.AllPossibleOperators.Count-1);
        GameController.OperatorsInPlay.Add(GameController.AllPossibleOperators[operatorChooser]);
        GameController.AllPossibleOperators.Remove(GameController.AllPossibleOperators[operatorChooser]);
    }
    private static void DifficultySettings()
    {
        switch (GameController.GamesPlayed)
        {
            case (<=1):
            {
                AdjustOperatorsInPlay();
                GameController.AmountOfVariables = 2;
                _difficultyLevel = 1;
                break;
            }
            case (6):
            {
                AdjustOperatorsInPlay();
                GameController.AmountOfVariables = 3;
                _difficultyLevel = 2;
                break;
            }
            case (11):
            {
                AdjustOperatorsInPlay();
                GameController.AmountOfVariables = 4;
                _difficultyLevel = 3;
                break;
            }
            case (16):
            {
                AdjustOperatorsInPlay();
                GameController.AmountOfVariables = 5;
                _difficultyLevel = 4;
                break;
            }
            case (21):
            {
                _difficultyLevel = 5;
                break;
            }
        }
    }
    public static void GameplayLoop()
    {
        GameController.LoadDefaults();
        Lives = 4;
        
        int cont = 1;
        while (cont == 1 && Lives > 0) 
        {
            GameController.GamesPlayed++;
            
            DifficultySettings();
            
            ProblemGenerator(GameController.AmountOfVariables);
            float correctAnswer = GameController.ProblemSolver();
            float playerAnswer = PlayerSolution();

            GameController.WinCondition(playerAnswer,correctAnswer, true);
            GameController.ScoreTracker(playerAnswer,correctAnswer);
            
            cont = GameController.ContinueCheck(cont, true);
            
        }
        GameFinished();
    }
    private static void GameFinished()
    {
        Console.Clear();
        if (Lives < 1)
        {
            Console.WriteLine("Dang! You run out of lives.\n" +
                              $"You've solved {GameController.Score} equations our of possible 25");
            GameController.ScorePrinter();
            
            Console.WriteLine("Press enter to go back to menu");
            
            Console.ReadLine();
        }
        else if (Lives > 0 && GameController.GamesPlayed == 26)
        {
            Console.WriteLine("You WON\n" +
                              $"You've solved {GameController.Score} equations our of possible 25\n" +
                              $"You still have {Lives} lives left");
            GameController.ScorePrinter();
            
            Console.WriteLine("Press enter to go back to menu");
            
            Console.ReadLine();
        }
    }
    private static void ProblemGenerator(int amountOfVariables)
    {
        // getting maximum amount of variables possible from settings
        
        double[] variables = new double[amountOfVariables];
        
        // Creating random numbers for equation
        
        for (int i = 0; i < variables.Length; i++)
        {
            variables[i] = _random.Next(1, 10);
        }
        
        // getting random operators for that equation
        
        string[] operatorsInEquation = new string[variables.Length - 1];
        
        for (int i = 0; i < operatorsInEquation.Length; i++)
        {
            operatorsInEquation[i] = GameController.OperatorsInPlay[_random.Next(0,GameController.OperatorsInPlay.Count)];
        }
        
        // filling a sting
        
        GameController.Equation = "";
        
        for (int i = 0; i < variables.Length; i++)
        {
            GameController.Equation += variables[i];
            if (i<operatorsInEquation.Length)
            {
                GameController.Equation += operatorsInEquation[i];
            }
        }

    }
    private static float PlayerSolution()
    {
        float playerAnswer;
        // while loop for safety check
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Correct answers {GameController.Score}. {Lives} lives left\n" +
                              $"Problem: {GameController.GamesPlayed}. Difficulty level: {_difficultyLevel}");
            Console.WriteLine("Solve this:");
            Console.Write(GameController.Equation+"=");
                
            if (Single.TryParse(Console.ReadLine(),out playerAnswer))
                break;
            Console.WriteLine("Looks like you entered something that is not a number.\n" +
                              "Try again!");
        }
        return playerAnswer;
    }
    
   
    

 

}