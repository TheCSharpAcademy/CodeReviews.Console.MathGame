using System.Diagnostics;
using NCalc;
using OhshieMathGame;
using OhshieMathGame.GameModes;

public class GameController
{
    // those variables are used in both gamemodes to make them work
    public static float Score;
    public static float GamesPlayed;
    public static int MaxNumber; // used to store maximum value for each operands
    public static int AmountOfVariables; // used to store how many operands are available
    public static string Equation = ""; // used to store equation
    public static List<string> OperatorsInPlay = new List<string>(); // stores current available operators
    public static List<string> AllPossibleOperators = new List<string>() // default operators list
    {
        "+",
        "-",
        "*",
        "/"
    };
    public static List<string> PrevGames = new List<string>(); // stores rounds that were played
    public static Stopwatch Stopwatch = new Stopwatch();
    public static TimeSpan Elapsed = new TimeSpan();
    private static Random _random = new Random();

    // main game selector menu
    public void GameModeSelector()
    {
        while (true)
        {
            Console.Clear();
            LoadDefaults();
            Console.WriteLine("Select game mode\n" +
                              "1. Career\n" +
                              "2. Infinite\n" +
                              "3. Display previously played games\n" +
                              "4. Go back to main menu");
            Program.MenuOperator = Console.ReadKey().Key;
            switch (Program.MenuOperator)
            {
                case (ConsoleKey.D1):
                {
                    CareerGameMode.GameplayLoop();
                    GameRecordsKeeper.OverallScoreTracker(true);
                    continue;
                }
                case (ConsoleKey.D2):
                {
                    InfiniteGameMode.GameplayLoop();
                    GameRecordsKeeper.OverallScoreTracker(false);
                    continue;
                }
                case (ConsoleKey.D3):
                {
                    GameRecordsKeeper.OverallScorePrinter();
                    continue;
                }
                case (ConsoleKey.D4):
                {
                    break;
                }
                default:
                {
                    continue;
                }
            }
            break;
        }
    }
    
    // method control operates game logic
    public static void GameLogic(bool careerGameMode)
    {
        Stopwatch.Reset();
        ProblemGenerator();
        float correctAnswer = ProblemSolver();
        float playerAnswer = PlayerSolution(careerGameMode);
        WinCondition(playerAnswer,correctAnswer, careerGameMode);
        GameRecordsKeeper.CurrentScoreTracker(playerAnswer,correctAnswer);
    }

    // checks is player answer is correct
    public static void WinCondition(float playerAnswer, float correctAnswer, bool careerGameMode)
    {
        bool winCheck = playerAnswer == correctAnswer;
        if (winCheck)
        {
            Score++;
            Console.WriteLine($"Correct!");
        }
        else
        {
            if (careerGameMode)
            {
                CareerGameMode.Lives--;
            }
            Console.WriteLine($"Wrong! Correct answer is: {correctAnswer}.");
        }
    }
    
    // checks if player wants to continue. Displays endgame message if career mode is activated
    public static int ContinueCheck(int cont, bool careerGameMode)
    {
        if (careerGameMode)
        {
            if (CareerGameMode.Lives < 1)
            {
                Console.WriteLine("No more lives. Press enter to exit this session");
                Console.ReadLine();
                cont++;
                return cont;
            }
            if (CareerGameMode.Lives > 0 && GamesPlayed == 26)
            {
                Console.WriteLine("Whew, that was the final question! Press enter to finish this session");
                Console.ReadLine();
                cont++;
                return cont;
            }
        }
        while (true)
        {
            Console.WriteLine("Advance to the next round?\n" +
                              "1. Yes 2. No");
            Program.MenuOperator = Console.ReadKey().Key;
            switch (Program.MenuOperator)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    return cont;
                case ConsoleKey.D2:
                    cont++;
                    return cont;
                default:
                    continue;
            }
        }
    }
    
    // found out about NCalc lib that allows to parse a string into a readable expression for program to use. Lets try it
    public static void ProblemGenerator()
    {
        // getting maximum amount of variables possible from settings
        double[] variables = new double[AmountOfVariables];
        
        // Creating random numbers for equation
        for (int i = 0; i < variables.Length; i++)
        {
            variables[i] = _random.Next(1, MaxNumber);
        }
        
        // getting random operators for that equation
        string[] operatorsInEquation = new string[variables.Length - 1];
        
        for (int i = 0; i < operatorsInEquation.Length; i++)
        {
            operatorsInEquation[i] = OperatorsInPlay[_random.Next(0,OperatorsInPlay.Count)];
        }
        
        // filling a sting
        Equation = "";
        for (int i = 0; i < variables.Length; i++)
        {
            Equation += variables[i];
            if (i<operatorsInEquation.Length)
            {
                Equation += operatorsInEquation[i];
            }
        }
    }
    
    // solves generated equation using NCalc to parse a sting 
    public static float ProblemSolver()
    {
        Expression expression = new Expression(Equation);
        float correctAnswer = Convert.ToSingle(expression.Evaluate());

        // doing this so it is actually possible to answer division questions
        correctAnswer = (float)Math.Round(correctAnswer, 2);

        return correctAnswer;
    }
    
    // outputs equation in console and waits for player to solve it
    public static float PlayerSolution(bool careerGameMode)
    {
        float playerAnswer;
        Stopwatch.Start();
        while (true)
        {
            Console.Clear();
            Console.Write($"Correct answers {Score}.");
            if (careerGameMode)
            {
                Console.Write($" You have {CareerGameMode.Lives} lives left.\n" +
                              $"Currently on difficulty level {CareerGameMode.DifficultyLevel}\n");
            }
            Console.WriteLine("Solve this:");
            Console.Write(Equation+"=");
                
            if (Single.TryParse(Console.ReadLine(),out playerAnswer))
                break;
            Console.WriteLine("Looks like you entered something that is not a number.\n" +
                              "Try again!");
        }
        Stopwatch.Stop();
        return playerAnswer;
    }

    // method used to output readable timer in string format.
    public static string Timer()
    {
        Elapsed = Stopwatch.Elapsed;
        string timer = string.Format("{0:0},{1}", Elapsed.Seconds,Elapsed.Milliseconds);
        Console.WriteLine($"It took you {timer} seconds to solve");
        return timer;
    }
    
    // method stores defaul values and load them when invoked
    public static void LoadDefaults()
    {
        GamesPlayed = 0;
        Score = 0;
        MaxNumber = 11;
        AmountOfVariables = 2;
        PrevGames.Clear();
        CareerGameMode.Lives = 4;
        OperatorsInPlay = new List<string>();
        AllPossibleOperators = new List<string>()
        {
            "+",
            "-",
            "*",
            "/"
        };
    }
}