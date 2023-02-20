using NCalc;

namespace OhshieMathGame.GameModes;

public class CareerGameMode
{
    // required variables to make this mode work
    private static int lives;
    private static int difficultyLevel;

    private static List<string> operatorsInPlay = new List<string>();
    private static int amountOfVariables;
        
    private static void DifficultySettings()
    {
        switch (GameController.gamesPlayed)
        {
            case (1):
            {
                int operatorChooser = GameController.random.Next(0, GameController.possibleOperators.Count-1);
                operatorsInPlay.Add(GameController.possibleOperators[operatorChooser]);
                GameController.possibleOperators.Remove(GameController.possibleOperators[operatorChooser]);
                amountOfVariables = 2;
                difficultyLevel = 1;
                break;
            }
            case (5):
            {
                int operatorChooser = GameController.random.Next(0, GameController.possibleOperators.Count-1);
                operatorsInPlay.Add(GameController.possibleOperators[operatorChooser]);
                GameController.possibleOperators.Remove(GameController.possibleOperators[operatorChooser]);
                amountOfVariables = 3;
                difficultyLevel = 2;
                break;
            }
            case (10):
            {
                int operatorChooser = GameController.random.Next(0, GameController.possibleOperators.Count-1);
                operatorsInPlay.Add(GameController.possibleOperators[operatorChooser]);
                GameController.possibleOperators.Remove(GameController.possibleOperators[operatorChooser]);
                amountOfVariables = 4;
                difficultyLevel = 3;
                break;
            }
            case (15):
            {
                int operatorChooser = GameController.random.Next(0, GameController.possibleOperators.Count-1);
                operatorsInPlay.Add(GameController.possibleOperators[operatorChooser]);
                GameController.possibleOperators.Remove(GameController.possibleOperators[operatorChooser]);
                amountOfVariables = 5;
                difficultyLevel = 4;
                break;
            }
            case (20):
            {
                difficultyLevel = 5;
                break;
            }
        }
    }
    public static void GameplayLoop()
    {
        GameController.gamesPlayed = 1;
        lives = 4;
        
        int cont = 1;
        while (cont == 1 && lives > 0) 
        {
            DifficultySettings();
            
            ProblemGenerator();
            double correctAnswer = ProblemSolver();
            double playerAnswer = PlayerSolution();

            WinCondition(playerAnswer, correctAnswer);
            ScoreTracker(playerAnswer,correctAnswer);
            
            cont = ContinueCheck(cont);
            GameController.gamesPlayed++;
        }
        GameFinished();
    }

    private static void GameFinished()
    {
        Console.Clear();
        if (lives < 1)
        {
            Console.WriteLine("Dang! You run out of lives.\n" +
                              $"You've solved {GameController.score} equations our of possible 25");
            ScorePrinter();
            
            Console.WriteLine("Press enter to go back to menu");
            
            Console.ReadLine();
        }
        else if (lives > 0 && GameController.gamesPlayed == 26)
        {
            Console.WriteLine("You WON\n" +
                              $"You've solved {GameController.score} equations our of possible 25\n" +
                              $"You still have {lives} lives left");
            ScorePrinter();
            
            Console.WriteLine("Press enter to go back to menu");
            
            Console.ReadLine();
        }
    }
    private static int ContinueCheck(int cont)
    {
        if (lives < 1)
        {
            Console.WriteLine("No more lives. Press enter to exit this session");
            Console.ReadLine();
            cont++;
        }
        else if (lives > 0 && GameController.gamesPlayed == 26)
        {
            Console.WriteLine("Whew, that was the final question! Press enter to finish this session");
            Console.ReadLine();
            cont++;
        }
        else
        {
            while (true)
            {
                Console.WriteLine("Advance to the next round?\n" +
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

        return cont;
    }
    private static void ProblemGenerator()
    {
        // getting maximum amount of variables possible from settings
        
        double[] variables = new double[amountOfVariables];
        
        // Creating random numbers for equation
        
        for (int i = 0; i < variables.Length; i++)
        {
            variables[i] = GameController.random.Next(1, 10);
        }
        
        // getting random operators for that equation
        
        string[] operatorsInEquasion = new string[variables.Length - 1];

        int maxActiveOperatorsForRandom = operatorsInPlay.Count;
        
        for (int i = 0; i < operatorsInEquasion.Length; i++)
        {
            operatorsInEquasion[i] = operatorsInPlay[GameController.random.Next(0,maxActiveOperatorsForRandom)];
        }
        
        // filling a sting
        
        GameController.equation = "";
        
        for (int i = 0; i < variables.Length; i++)
        {
            GameController.equation += variables[i];
            if (i<operatorsInEquasion.Length)
            {
                GameController.equation += operatorsInEquasion[i];
            }
        }

    }
    private static double ProblemSolver()
    {
        Expression expression = new Expression(GameController.equation);
        double correctAnswer = Convert.ToDouble(expression.Evaluate());

        // doing this so it is actually possible to answer division questions
        correctAnswer = Math.Round(correctAnswer, 2);

        return correctAnswer;
    }
    private static double PlayerSolution()
    {
        double playerAnswer;
        // while loop for safety check
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Correct answers {GameController.score}. {lives} lives left\n" +
                              $"Problem: {GameController.gamesPlayed}. Difficulty level: {difficultyLevel}");
            Console.WriteLine("Solve this:");
            Console.Write(GameController.equation+"=");
                
            if (Double.TryParse(Console.ReadLine(),out playerAnswer))
                break;
            Console.WriteLine("Looks like you entered something that is not a number.\n" +
                              "Try again!");
        }
        return playerAnswer;
    }
    private static void WinCondition(double playerAnswer, double correctAnswer)
    {
        bool winCheck = playerAnswer == correctAnswer;
        if (winCheck)
        {
            GameController.score++;
            Console.WriteLine($"Correct!");
        }
        else
        {
            lives--;
            Console.WriteLine($"Wrong! Correct answer is: {correctAnswer}.");
        }
            
    }
    
    private static void ScoreTracker(double playerAnswer, double correctAnswer)
    {
        string gameScoreWritedown;
        bool wincheck = playerAnswer == correctAnswer;
        string result;
        double effectiveness;
        if (wincheck)
        {
            result = "Your answer was correct!";
            effectiveness = Math.Round(Convert.ToDouble(GameController.score / GameController.gamesPlayed),2);
        }
        else
        {
            result = "Your answer was incorrect!";
            effectiveness = Math.Round(GameController.score / GameController.gamesPlayed,2)*100;
        }
        
        gameScoreWritedown = ($"Round {GameController.gamesPlayed}. {GameController.equation}={playerAnswer}. {result} Accuracy: {effectiveness}%");
        GameController.prevGames.Add(gameScoreWritedown);
    }
    
    static void ScorePrinter()
    {
        foreach (var record in GameController.prevGames)
        {
            Console.WriteLine(record);
        }
    }

 

}