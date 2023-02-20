using System.Diagnostics;
using NCalc;

namespace OhshieMathGame.GameModes;

public class InfiniteGameMode
{
    // to make everything work
    static Random random = new Random();
    private static Stopwatch _stopwatch = new Stopwatch();
    private static TimeSpan _elapsed;
    private static string _equation = "";
    
    // main gameplay loop happens here
    public static void GameplayLoop()
    {
        int cont = 1;
        while (cont == 1)
        {
            GameController.gamesPlayed++;
            _stopwatch.Reset();

            // Generating equation and finding correct answer
            ProblemGenerator();
            double correctAnswer = ProblemSolver();
            
            // Printing problem to solve and reading player answer
            double playerAnswer = PlayerSolution();
            
            // checking if answer is correct
            WinCondition(playerAnswer,correctAnswer);
            
            // checking if player wants to continue 
            ScoreTracker(playerAnswer,correctAnswer);
            cont = ContinueCheck(cont);
            
        }
    }
    // found out about NCalc lib that allows to parse a string into a readable expression for program to use. Lets try it
    private static void ProblemGenerator()
    {
        // getting maximum amount of variables possible from settings
        
        double[] variables = new double[InfiniteSettings.amountOfVariables];
        
        // Creating random numbers for equation
        
        for (int i = 0; i < variables.Length; i++)
        {
            variables[i] = random.Next(1, InfiniteSettings.maxNumber);
        }
        
        // getting random operators for that equation
        
        string[] operatorsInEquasion = new string[variables.Length - 1];

        int maxActiveOperatorsForRandom = GameController.possibleOperators.Count;
        
        for (int i = 0; i < operatorsInEquasion.Length; i++)
        {
            operatorsInEquasion[i] = GameController.possibleOperators[random.Next(0,maxActiveOperatorsForRandom)];
        }
        
        // filling a sting
        
        _equation = "";
        
        for (int i = 0; i < variables.Length; i++)
        {
            _equation += variables[i];
            if (i<operatorsInEquasion.Length)
            {
                _equation += operatorsInEquasion[i];
            }
        }

    }
    // parsing string into math problem and solving it via NCalc lib
    private static double ProblemSolver()
    {
        Expression expression = new Expression(_equation);
        double correctAnswer = Convert.ToDouble(expression.Evaluate());

        // doing this so it is actually possible to answer division questions
        correctAnswer = Math.Round(correctAnswer, 2);

        return correctAnswer;
    }
    // outputs equation in console and waits for player to solve it
    private static double PlayerSolution()
    {
        double playerAnswer;
        // while loop for safety check
        _stopwatch.Start();
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Correct answers {GameController.score}");
            Console.WriteLine("Solve this:");
            Console.Write(_equation+"=");
                
            if (Double.TryParse(Console.ReadLine(),out playerAnswer))
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
        return timer;
    }
    // method accumulated score data and saves it into a list
    private static void ScoreTracker(double playerAnswer, double correctAnswer)
    {
        string gameScoreWritedown;
        bool wincheck = playerAnswer == correctAnswer;
        string result;
        if (wincheck)
        {
            result = "Your answer was correct!";
            GameController.effectiveness = Math.Round(Convert.ToDouble(GameController.score / GameController.gamesPlayed),2);
        }
        else
        {
            result = "Your answer was incorrect!";
            GameController.effectiveness = Math.Round(GameController.score / GameController.gamesPlayed,2)*100;
        }
        
        gameScoreWritedown = ($"Round {GameController.gamesPlayed}. {_equation}={playerAnswer}. {result} Accuracy: {GameController.effectiveness}%");
        GameController.prevGames.Add(gameScoreWritedown);
    }
    // checks if player answer equals to correct answer and increases score. Score rn is based on each equation solved
    // maybe it would be better to base score on amount of variables/operators.
    private static void WinCondition(double playerAnswer, double correctAnswer)
    {
        bool winCheck = playerAnswer == correctAnswer;
        if (winCheck)
        {
            GameController.score++;
            Console.WriteLine($"Correct! It took you {Timer()} seconds to answer");
        }
        else
        {
            Console.WriteLine($"Wrong! Correct answer is: {correctAnswer}. It took you {Timer()} seconds to answer");
        }
            
    }
    // asks user if he wants to continue playing after each round.
    private static int ContinueCheck(int cont)
    {
        while (true)
        {
            Console.WriteLine("Another round?\n" +
                              "1. Yes 2. No");
            Program.menuOperator = Console.ReadKey().Key;
            switch (Program.menuOperator)
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

}