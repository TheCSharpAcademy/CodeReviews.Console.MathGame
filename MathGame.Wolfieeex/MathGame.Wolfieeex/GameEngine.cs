using MathGame.Wolfieeex.Models;

namespace MathGame.Wolfieeex;

internal class GameEngine
{
    // Value ranges for all difficulties and game modes:
    private Dictionary<Tuple<GameModes, GameDifficulty>, int[]> numberRanges = new Dictionary<Tuple<GameModes, GameDifficulty>, int[]>
    {
        // Easy numbers
        { Tuple.Create(GameModes.Addition, GameDifficulty.Easy), new int[] {1, 100 } },
        { Tuple.Create(GameModes.Subtraction, GameDifficulty.Easy), new int[] {1, 101 } },
        { Tuple.Create(GameModes.Multiplication, GameDifficulty.Easy), new int[] {1, 11 } },
        { Tuple.Create(GameModes.Division, GameDifficulty.Easy), new int[] {1, 101 } },

        // Moderate numbers
        { Tuple.Create(GameModes.Addition, GameDifficulty.Moderate), new int[] {50, 251 } },
        { Tuple.Create(GameModes.Subtraction, GameDifficulty.Moderate), new int[] {10, 301 } },
        { Tuple.Create(GameModes.Multiplication, GameDifficulty.Moderate), new int[] {1, 21} },
        { Tuple.Create(GameModes.Division, GameDifficulty.Moderate), new int[] {3, 201 } },

        // Hard numbers
        { Tuple.Create(GameModes.Addition, GameDifficulty.Hard), new int[] {100, 901 } },
        { Tuple.Create(GameModes.Subtraction, GameDifficulty.Hard), new int[] {100, 501 } },
        { Tuple.Create(GameModes.Multiplication, GameDifficulty.Hard), new int[] {5, 51 } },
        { Tuple.Create(GameModes.Division, GameDifficulty.Hard), new int[] {5, 501 } },
    };

    public GameEngine(GameModes mode, GameDifficulty difficulty, int questionsCount, DateTime date)
    {
        // Prompt for user before the game starts:
        Console.Clear();
        Console.WriteLine($"You are playing {mode.ToString().ToLower()} game. You will be challanged with {questionsCount} {difficulty.ToString().ToLower()} questions.");
        Console.Write("\n\n\nPress Enter whenever you are ready to start: ");
        Console.ReadLine();
        Console.Clear();

        // Initiate variables:
        int score = 0;
        int time = 0;
        bool gameUnfinished = false;

        // Start the game:
        for (int i = questionsCount; i > 0; i--)
        {
            // Display a question that will prompt user to give an answer:
            Console.WriteLine($"Question {questionsCount - i + 1} of {questionsCount}:");
            Console.WriteLine($"{new string('-', Console.BufferWidth)}");

            // If random mode slected, decide how to calculate the numbers:
            GameModes currentMode = mode;
            if (mode == GameModes.Random)
            {
                Random generator = new Random();
                int randomResult = generator.Next(0, 4);
                switch (randomResult)
                {
                    case 0:
                        currentMode = GameModes.Addition;
                        break;
                    case 1:
                        currentMode = GameModes.Subtraction;
                        break;
                    case 2:
                        currentMode = GameModes.Multiplication;
                        break;
                    case 3:
                        currentMode = GameModes.Division;
                        break;
                }
            }

            // Get numbers for calculation:
            int[] numbers;
            if (currentMode == GameModes.Division)
                numbers = SelectDivisionRange(currentMode, difficulty);
            else
                numbers = SelectRange(currentMode, difficulty);
         
            // Resolve result:
            int result = CalculateResult(currentMode, numbers);

            // Display the calculation and read user's input (input cannot be a sting other than "e" (that prompts
            // the application to exit) and cannot have extremely low or high value):
            Console.WriteLine($"What is the {GetProductType(currentMode)} of {numbers[0]} and {numbers[1]}?");
            Console.Write($"{numbers[0]} {GetSign(currentMode)} {numbers[1]} = ");
            Helpers.PrintExitPrompt($"Press \"E\" to quit the game and return to the main menu.");

            // Read input
            string? userInput = "";
            Helpers.ReadInput
                (
                    ref userInput, 
                    $"{numbers[0]} {GetSign(currentMode)} {numbers[1]} = (Please put a valid guess): ", 
                    new string[] {"e"}, new int[] {-1000000, 1000000}, 
                    notInRangeFailMessage: $"{numbers[0]} {GetSign(currentMode)} {numbers[1]} = "
                );

            // If user pressed "e" to exit the game:
            if (userInput.ToLower() == "e")
            {
                gameUnfinished = true; 
                Console.Clear();
                Console.WriteLine("You have exited the game. Come again soon?");
                break;
            }

            // If user inserted a correct answer, compare it to result and display one of the messages. After that, the loop repeats:
            int intInput = int.Parse(userInput);
            if (intInput == result)
            {
                score++;
                Console.WriteLine($"\nYour answer is correct! Current score: {score} out of {questionsCount} questions.");
                Console.WriteLine($"\n\n\r{new string(' ', Console.BufferWidth)}");
                Console.Write($"\rPress Enter to continue: ");
            }
            else
            {
                Console.WriteLine($"\nThat's incorrect... The {GetProductType(currentMode)} of {numbers[0]} and {numbers[1]} is {result}.");
                Console.WriteLine($"Current score: {score} out of {questionsCount} questions.");
                Console.WriteLine($"\n\r{new string(' ', Console.BufferWidth)}");
                Console.Write($"\rPress Enter to continue: ");
            }
            Console.ReadLine();
            Console.Clear();
        }
        // After the loop is exited or ends by itself, on game finish, show user their results and log the game:
        LogGame(date, mode, difficulty, questionsCount, score, time, !gameUnfinished);
        Console.WriteLine($"Your final score is {score} out of {questionsCount} questions!");
        Console.Write("\n\n\nPress Enter to return to the main menu: ");
        Console.ReadLine();
    }

    private void LogGame(DateTime date, GameModes mode, GameDifficulty difficulty, int questionsCount, int score, int time, bool gameFinished)
    {
        Helpers.GameInstances.Add(new GameInstance
        {
            Date = date,
            Score = score,
            Type = Enum.GetName(mode),
            Difficulty = Enum.GetName(difficulty),
            QuestionsCount = questionsCount,
            Time = time
        });
    }
    private string GetSign(GameModes mode)
    {
        switch (mode)
        {
            case GameModes.Addition:
                return "+";
            case GameModes.Subtraction:
                return "-";
            case GameModes.Multiplication:
                return "*";
            case GameModes.Division:
                return "/";
        }
        return "";
    }
    private string GetProductType(GameModes mode)
    {
        switch (mode)
        {
            case GameModes.Addition:
                return "sum";
                case GameModes.Subtraction:
                return "difference";
            case GameModes.Multiplication:
                return "product";
            case GameModes.Division:
                return "quotient";
        }
        return "";
    }
    private int CalculateResult(GameModes mode, int[] numbers)
    {;
        int result = 0;

        // Calculate based on game mode:
        switch (mode)
        {
            case GameModes.Addition:
                return numbers[0] + numbers[1];
            case GameModes.Subtraction:
                return numbers[0] - numbers[1];
            case GameModes.Multiplication:
                return numbers[0] * numbers[1];
            case GameModes.Division:
                return numbers[0] / numbers[1];
        }
        return result;
    }
    private int[] SelectRange(GameModes mode, GameDifficulty difficulty)
    {
        int[] numbers = new int[2];
        int[] range = numberRanges[Tuple.Create(mode, difficulty)];
        Random generator = new Random();
        numbers[0] = generator.Next(range[0], range[1]);
        numbers[1] = generator.Next(range[0], range[1]);
        return numbers;
    }
    private int[] SelectDivisionRange(GameModes mode, GameDifficulty difficulty)
    {
        bool runTillNumbersCorrect = true;
        int[] numbersTocheck = new int[2];

        // Runs until 2 numbers are divisible:
        while (runTillNumbersCorrect)
        {
            int[] range = numberRanges[Tuple.Create(mode, difficulty)];
            Random generator = new Random();
            numbersTocheck[0] = generator.Next(range[0], range[1]);
            numbersTocheck[1] = generator.Next(range[0], range[1]);

            // Check if 2 numbers generated result in integer. Also, check if the quotient is appropriate to the
            // level of difficulty:
            if (numbersTocheck[0] % numbersTocheck[1] == 0)
            {
                if (numbersTocheck[0] / numbersTocheck[1] >= range[0])
                    runTillNumbersCorrect = false;
            }
        }
        return numbersTocheck;
    }
}
