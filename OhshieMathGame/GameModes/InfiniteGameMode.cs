using System.Diagnostics;
using NCalc;

namespace OhshieMathGame.GameModes;

public class InfiniteGameMode
{
    // to make everything work
    static Random _random = new Random();
    private static Stopwatch _stopwatch = new Stopwatch();
    private static TimeSpan _elapsed;


    // main gameplay loop happens here
    public static void GameplayLoop()
    {
        if (GameController.GamesPlayed==0)
        {
            InfiniteSettings.SettingsMenu();
        }
        
        int cont = 1;
        while (cont == 1)
        {
            GameController.GamesPlayed++;
            _stopwatch.Reset();

            // Generating equation and finding correct answer
            ProblemGenerator(GameController.AmountOfVariables);
            float correctAnswer = GameController.ProblemSolver();
            
            // Printing problem to solve and reading player answer
            float playerAnswer = PlayerSolution();
            
            // checking if answer is correct
            Timer();
            GameController.WinCondition(playerAnswer,correctAnswer, false);
            
            // checking if player wants to continue 
            GameController.ScoreTracker(playerAnswer,correctAnswer);
            cont = GameController.ContinueCheck(cont, false);
            
        }
        
        GameController.ScorePrinter();
        Console.WriteLine("Press enter to go back.");
        Console.ReadLine();
        Console.Clear();
    }
    // found out about NCalc lib that allows to parse a string into a readable expression for program to use. Lets try it
    private static void ProblemGenerator(int amountOfVariables)
    {
        // getting maximum amount of variables possible from settings
        
        double[] variables = new double[amountOfVariables];
        
        // Creating random numbers for equation
        
        for (int i = 0; i < variables.Length; i++)
        {
            variables[i] = _random.Next(1, GameController.MaxNumber);
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
    
    // outputs equation in console and waits for player to solve it
    private static float PlayerSolution()
    {
        float playerAnswer;
        // while loop for safety check
        _stopwatch.Start();
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Correct answers {GameController.Score}");
            Console.WriteLine("Solve this:");
            Console.Write(GameController.Equation+"=");
                
            if (Single.TryParse(Console.ReadLine(),out playerAnswer))
                break;
            Console.WriteLine("Looks like you entered something that is not a number.\n" +
                              "Try again!");
        }
        _stopwatch.Stop();

        return playerAnswer;
    }
    // method used to output readable timer in string format.
    private static string Timer()
    {
        _elapsed = _stopwatch.Elapsed;
        string timer = string.Format("{0:0},{1}", _elapsed.Seconds,_elapsed.Milliseconds);
        Console.WriteLine($"It took you {timer} seconds to solve");
        return timer;
    }
    
}