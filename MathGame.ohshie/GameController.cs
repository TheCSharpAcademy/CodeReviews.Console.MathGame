using System.Diagnostics;
using NCalc;

public class GameController
{
    // those variables are used in both gamemodes to make them work
    public int Score;
    public int GamesPlayed;
    public int MaxNumber; // used to store maximum value for each operands
    public int AmountOfVariables; // used to store how many operands are available
    public string Equation = ""; // used to store equation
    public List<string> OperatorsInPlay = new List<string>(); // stores current available operators
    public List<string> AllPossibleOperators = new List<string>() // default operators list
    {
        "+",
        "-",
        "*",
        "/"
    };
    private Stopwatch _stopwatch = new Stopwatch();
    private TimeSpan _elapsed = new TimeSpan();
    private static Random _random = new Random();

    // method control operates game logic
    public void GameLogic(bool careerGameMode, GameRecordsKeeper scoreTracker, GameController currentGame)
    {
        _stopwatch.Reset();
        int correctAnswer = ProblemGenerator();
        int playerAnswer = PlayerSolution(careerGameMode);
        WinCondition(playerAnswer,correctAnswer, careerGameMode);
        scoreTracker.CurrentScoreTracker(playerAnswer,correctAnswer, currentGame);
    }

    // checks is player answer is correct
    private void WinCondition(int playerAnswer, int correctAnswer, bool careerGameMode)
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
    public int ContinueCheck(int cont, bool careerGameMode)
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
    public int ProblemGenerator()
    {
        int correctAnswer;
        double correctAnswerUncheked;
        
        bool equationIsFloat;
        do 
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
            
            correctAnswerUncheked = ProblemSolver();
            equationIsFloat = !int.TryParse(correctAnswerUncheked.ToString(), out correctAnswer);
        } while (equationIsFloat);
        return correctAnswer;
    }
    
    // solves generated equation using NCalc to parse a sting 
    private double ProblemSolver()
    {
        Expression expression = new Expression(Equation);
        double correctAnswer = Convert.ToSingle(expression.Evaluate());
        return correctAnswer;
    }
    
    // outputs equation in console and waits for player to solve it
    private int PlayerSolution(bool careerGameMode)
    {
        int playerAnswer;
        _stopwatch.Start();
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
                
            if (int.TryParse(Console.ReadLine(),out playerAnswer))
                break;
            Console.WriteLine("Looks like you entered something that is not a number.\n" +
                              "Try again!");
        }
        _stopwatch.Stop();
        return playerAnswer;
    }

    // method used to output readable timer in string format.
    public string Timer()
    {
        _elapsed = _stopwatch.Elapsed;
        string timer = string.Format("{0:0},{1}", _elapsed.Seconds,_elapsed.Milliseconds);
        Console.WriteLine($"It took you {timer} seconds to solve");
        return timer;
    }
}