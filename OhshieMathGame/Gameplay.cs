using System.Diagnostics;

namespace OhshieMathGame;

public class Gameplay
{
    // to make everything work
    static Random random = new Random();
    public static double score;
    private static Stopwatch _stopwatch = new Stopwatch();
    private static TimeSpan _elapsed;
    public static double[] variables = new double[Settings.amountOfVariables];
    public static List<string> prevGames = new List<string>();
    public static double effectiveness;
    
    // method accumulated score data and saves it into a list
    public static void ScoreTracker(int randomChooser, double playerAnswer, double correctAnswer)
    {
        string gameScoreWritedown;
        bool wincheck = playerAnswer == correctAnswer;
        string result;
        if (wincheck)
        {
            result = "Your answer was correct!";
            effectiveness = Math.Round(Convert.ToDouble(score / Program.gamesPlayed),2);
        }
        else
        {
            result = "Your answer was incorrect!";
            effectiveness = Math.Round(score / Program.gamesPlayed,2)*100;
        }
        
        gameScoreWritedown = ($"Round {Program.gamesPlayed}. {EquiationToString(randomChooser)}{playerAnswer}. {result} Accuracy: {effectiveness}%");
        prevGames.Add(gameScoreWritedown);
    }
    // method used to output readable timer in string format.
    private static string Timer()
    {
        _elapsed = _stopwatch.Elapsed;
        string timer = string.Format("{0:0},{1}", _elapsed.Seconds,_elapsed.Milliseconds);
        return timer;
    }
    // main gameplay loop happens here
    public static void GameplayLoop()
    {
        
        int cont = 1;
        while (cont == 1)
        {
            Program.gamesPlayed++;
            _stopwatch.Reset();

            // Randomly choosing what player need to solve
            
            int randomChooser = random.Next(1, 5);
            
            // Generating equation and finding correct answer
            
            double correctAnswer = ProblemGenerator(randomChooser);
        
            // Printing problem to solve and reading player answer
            double playerAnswer;
            
            // while loop for safety check
            _stopwatch.Start();
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Correct answers {score}");
                Console.WriteLine("Solve this:");
                Console.Write(EquiationToString(randomChooser));
                
                if (Double.TryParse(Console.ReadLine(),out playerAnswer))
                    break;
                Console.WriteLine("Looks like you entered something that is not a number.\n" +
                                  "Try again!");
            }
            _stopwatch.Stop();
            // checking if answer is correct
            
            winCondition(playerAnswer,correctAnswer);
            
            // checking if player wants to continue 
            ScoreTracker(randomChooser,playerAnswer,correctAnswer);
            cont = ContinueCheck(cont);
            
        }
    }
    
    // method that outputs complete equation to the console
    static string EquiationToString(int randomChooser)
    {
        string operation = "", equation = "";
        
        switch (randomChooser)
        {
            case 1:
                operation = "+";
                break;
            case 2:
                operation = "-";
                break;
            case 3:
                operation = "*";
                break;
            case 4:
                operation = "/";
                break;
        }
        
        for (int i = 0; i < variables.Length; i++)
        {
            equation += variables[i];
            if (i+1<variables.Length)
            {
                equation += operation;
            }
        }

        equation += "=";

        return equation;
    }
    
    // checks if player answer equals to correct answer and increases score. Score rn is based on each equation solved
    // maybe it would be better to base score on amount of variables/operands.
    static void winCondition(double playerAnswer, double correctAnswer)
    {
        bool winCheck = playerAnswer == correctAnswer;
        if (winCheck)
        {
            score++;
            Console.WriteLine($"Correct! It took you {Timer()} seconds to answer");
        }
        else
        {
            Console.WriteLine($"Wrong! Correct answer is: {correctAnswer}. It took you {Timer()} seconds to answer");
        }
            
    }
   
    // asks user if he wants to continue playing after each round.
    static int ContinueCheck(int cont)
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
    
    // method used to generate equation 
    public static double ProblemGenerator(int randomChooser)
    {
        
        variables = new double[Settings.amountOfVariables];
        
        // Creating random numbers for equation
        
        for (int i = 0; i < variables.Length; i++)
        {
            variables[i] = random.Next(1, Settings.maxNumber);
        }
        
        // Finding correct answer
        
        double correctAnswer = variables[0];
        switch (randomChooser)
        {
            case 1:
                for (int i = 1; i < variables.Length; i++)
                {
                    correctAnswer += variables[i];
                }
                break;
            case 2:
                for (int i = 1; i < variables.Length; i++)
                {
                    correctAnswer -= variables[i];
                }
                break;
            case 3:
                for (int i = 1; i < variables.Length; i++)
                {
                    correctAnswer *= variables[i];
                }
                break;
            case 4:
                for (int i = 1; i < variables.Length; i++)
                {
                    correctAnswer /= variables[i];
                    correctAnswer = Math.Round(correctAnswer, 2);
                }
                break;
        }
        
        return correctAnswer;
    }
}