using MathGame.Models;

namespace MathGame;

internal static class GameEngine
{
    private static DateTime start_time;
    
    // Starting logic of the game
    internal static void GameProcess(GameMode mode, GameDifficulty difficulty)
    {
        int numberOfProblems = 10;      // Number of problems given to the user, change for testing
        int currentScore = 0;
        int time = 0;

        Console.Clear();

        // Timer for the game
        SetTimer();

        // Gives math problems and updates the score of the user
        for (int i = numberOfProblems; i > 0; i--)
        {
            Console.WriteLine($"Problems left: {i} | Elapsed Time: {Time_Elapsed()} seconds");      // Update remaining problems and time elapsed

            (GameMode newMode, int firstNumber, int secondNumber) = GenerateNumbers(mode, difficulty);

            int answer = GiveProblem(newMode, firstNumber, secondNumber);

            if (CheckAnswer(answer, firstNumber, secondNumber, newMode))
            {
                currentScore++;
            }
            Console.Clear();
        }

        time = Time_Elapsed();  // Final time after completing all problems

        // Adds final score to user's game history
        ScoreHistory.AddToHistory(mode, currentScore, numberOfProblems, difficulty, time);

        // Display score to user
        Console.WriteLine($"You got {currentScore} out of {numberOfProblems}");
        Console.WriteLine($"You took {time} seconds");
        Console.WriteLine("Press enter to go back to the main menu");
        Console.ReadLine();
    }

    // Generates random numbers for the math problem
    internal static (GameMode, int, int) GenerateNumbers(GameMode mode, GameDifficulty difficulty)
    {
        const int BASE_NUM_GENERATOR = 10; // Base number for generating random numbers
        Random random = new Random();

        // Generate upper and lower bound for random numbers
        int lowerBound = (int)Math.Pow(BASE_NUM_GENERATOR, (int)difficulty);
        int upperBound = (int)Math.Pow(BASE_NUM_GENERATOR, (int)(difficulty + 1));

        // Generates random numbers for the math problem
        int firstNumber = random.Next(lowerBound, upperBound);
        int secondNumber = random.Next(lowerBound, upperBound);

        GameMode newMode = mode;

        // Randomly select an operation
        if (mode == GameMode.Random)
        {
            newMode = (GameMode)random.Next(0, 4);
        }

        // For division problems, make sure the first number is divisible by the second number
        if (newMode == GameMode.Division)
        {
            firstNumber = firstNumber * secondNumber;
        }

        return (newMode, firstNumber, secondNumber);
    }

    // Display math problem and get a valid answer from user
    internal static int GiveProblem(GameMode mode, int firstNumber, int secondNumber)
    {
        string[] operations = ["+", "-", "*", "/"];
        bool validInput = false;
        int answer = 0;
        string? readResult;

        // Display math problem and get valid user input
        do
        {
            Console.WriteLine($"{firstNumber:N0} {operations[(int)mode]} {secondNumber:N0} ?");
            readResult = Console.ReadLine();

            // Checks if user input is an integer
            if (readResult != null)
            {
                validInput = int.TryParse(readResult, out answer);
            }

            if (!validInput)
            {
                Console.WriteLine("Did not enter an intenger, please try again.\n");
            }
        } while (validInput == false);

        return answer;
    }

    // Checks if the answer to a math problem is correct for add, sub, mult, div
    internal static bool CheckAnswer(int answer, int firstNumber, int secondNumber, GameMode mode)
    {
        bool correctAnswer = false;

        switch (mode)
        {
            case GameMode.Addition:
                correctAnswer = ((firstNumber + secondNumber) == answer);
                break;
            case GameMode.Subtraction:
                correctAnswer = ((firstNumber - secondNumber) == answer);
                break;
            case GameMode.Multiplication:
                correctAnswer = ((firstNumber * secondNumber) == answer);
                break;
            case GameMode.Division:
                correctAnswer = ((firstNumber / secondNumber) == answer);
                break;
        }

        return correctAnswer;
    }

    // Sets current time
    private static void SetTimer()
    {
        start_time = DateTime.Now;
    }

    // Timer for the game
    private static int Time_Elapsed()
    {
        TimeSpan elapsed = DateTime.Now - start_time;

        return (int) elapsed.TotalSeconds;
    }
}
