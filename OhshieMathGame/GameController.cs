using NCalc;

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
    
    // main game selector menu
    public static void GameModeSelector()
    {

        while (true)
        {
            LoadDefaults();
            Console.WriteLine("Select game mode\n" +
                              "1. Career\n" +
                              "2. Infinite\n" +
                              "3. Go back to main menu");
            Program.MenuOperator = Console.ReadKey().Key;
            switch (Program.MenuOperator)
            {
                case (ConsoleKey.D1):
                {
                    CareerGameMode.GameplayLoop();
                    continue;
                }
                case (ConsoleKey.D2):
                {
                    InfiniteGameMode.GameplayLoop();
                    continue;
                }
                case (ConsoleKey.D3):
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
    
    // prints out user previous games
    public static void ScorePrinter()
    {
        Console.Clear();
        
        foreach (var record in PrevGames)
        {
            Console.WriteLine(record);
        }
    }
    
    // writes game score/stats into a sting and add it to a list of played games
    public static void ScoreTracker(float playerAnswer, float correctAnswer)
    {
        string gameScoreWritedown;
        bool wincheck = playerAnswer == correctAnswer;
        string result;
        float effectiveness;
        if (wincheck)
        {
            result = "Your answer was correct!";
            effectiveness = (float)Math.Round(Convert.ToSingle(Score / GamesPlayed),2);
        }
        else
        {
            result = "Your answer was incorrect!";
            effectiveness = (float)Math.Round(Score / GamesPlayed,2)*100;
        }
        
        gameScoreWritedown = ($"Round {GamesPlayed}. {Equation}={playerAnswer}. {result} Accuracy: {effectiveness}%");
        PrevGames.Add(gameScoreWritedown);
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
    
    // solves generated equation using NCalc to parse a sting 
    public static float ProblemSolver()
    {
        Expression expression = new Expression(Equation);
        float correctAnswer = Convert.ToSingle(expression.Evaluate());

        // doing this so it is actually possible to answer division questions
        correctAnswer = (float)Math.Round(correctAnswer, 2);

        return correctAnswer;
    }
    
    // method stores defaul values and load them when invoked
    public static void LoadDefaults()
    {
        GamesPlayed = 0;
        Score = 0;
        MaxNumber = 11;
        AmountOfVariables = 2;
        PrevGames.Clear();
    }
    
}
