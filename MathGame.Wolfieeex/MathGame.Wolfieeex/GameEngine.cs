namespace MathGame.Wolfieeex;

internal class GameEngine
{
    // Value ranges for all difficulties and game modes:
    private Dictionary<Tuple<MainMenu.GameModes, MainMenu.GameDifficulty>, int[]> numberRanges = new Dictionary<Tuple<MainMenu.GameModes, MainMenu.GameDifficulty>, int[]>
    {
        // Easy numbers
        { Tuple.Create(MainMenu.GameModes.Addition, MainMenu.GameDifficulty.Easy), new int[] {1, 100 } },
        { Tuple.Create(MainMenu.GameModes.Subtraction, MainMenu.GameDifficulty.Easy), new int[] {1, 101 } },
        { Tuple.Create(MainMenu.GameModes.Multiplication, MainMenu.GameDifficulty.Easy), new int[] {1, 11 } },
        { Tuple.Create(MainMenu.GameModes.Division, MainMenu.GameDifficulty.Easy), new int[] {1, 101 } },

        // Moderate numbers
        { Tuple.Create(MainMenu.GameModes.Addition, MainMenu.GameDifficulty.Moderate), new int[] {50, 251 } },
        { Tuple.Create(MainMenu.GameModes.Subtraction, MainMenu.GameDifficulty.Moderate), new int[] {10, 301 } },
        { Tuple.Create(MainMenu.GameModes.Multiplication, MainMenu.GameDifficulty.Moderate), new int[] {1, 21} },
        { Tuple.Create(MainMenu.GameModes.Division, MainMenu.GameDifficulty.Moderate), new int[] {3, 201 } },

        // Hard numbers
        { Tuple.Create(MainMenu.GameModes.Addition, MainMenu.GameDifficulty.Hard), new int[] {100, 901 } },
        { Tuple.Create(MainMenu.GameModes.Subtraction, MainMenu.GameDifficulty.Hard), new int[] {100, 501 } },
        { Tuple.Create(MainMenu.GameModes.Multiplication, MainMenu.GameDifficulty.Hard), new int[] {5, 51 } },
        { Tuple.Create(MainMenu.GameModes.Division, MainMenu.GameDifficulty.Hard), new int[] {3, 501 } },
    };

    public GameEngine(MainMenu.GameModes mode, MainMenu.GameDifficulty difficulty, int questionsCount)
    {
        // Prompt for user before the game starts:
        Console.Clear();
        Console.WriteLine($"You are playing {mode} game. You will be challanged with {questionsCount} {difficulty.ToString().ToLower()} questions.");
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
            MainMenu.GameModes currentMode = mode;
            if (mode == MainMenu.GameModes.Random)
            {
                Random generator = new Random();
                int randomResult = generator.Next(0, 4);
                switch (randomResult)
                {
                    case 0:
                        currentMode = MainMenu.GameModes.Addition;
                        break;
                    case 1:
                        currentMode = MainMenu.GameModes.Subtraction;
                        break;
                    case 2:
                        currentMode = MainMenu.GameModes.Multiplication;
                        break;
                    case 3:
                        currentMode = MainMenu.GameModes.Division;
                        break;
                }
            }

            // Get numbers for calculation:
            int[] numbers;
            if (currentMode == MainMenu.GameModes.Division)
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
                    $"{numbers[0]} {GetSign(currentMode)} {numbers[1]} = (Please insert a valid guess): ", 
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
        // After the loop is exited or ends by itself, on game finish, show user their results:
        Console.WriteLine($"Your final score is {score} out of {questionsCount} questions!");
        Console.Write("\n\n\nPress Enter to return to the main menu: ");
        Console.ReadLine();
    }

    private string GetSign(MainMenu.GameModes mode)
    {
        switch (mode)
        {
            case MainMenu.GameModes.Addition:
                return "+";
            case MainMenu.GameModes.Subtraction:
                return "-";
            case MainMenu.GameModes.Multiplication:
                return "*";
            case MainMenu.GameModes.Division:
                return "/";
        }
        return "";
    }
    private string GetProductType(MainMenu.GameModes mode)
    {
        switch (mode)
        {
            case MainMenu.GameModes.Addition:
                return "sum";
                case MainMenu.GameModes.Subtraction:
                return "difference";
            case MainMenu.GameModes.Multiplication:
                return "product";
            case MainMenu.GameModes.Division:
                return "quotient";
        }
        return "";
    }
    private int CalculateResult(MainMenu.GameModes mode, int[] numbers)
    {;
        int result = 0;

        // Calculate based on game mode:
        switch (mode)
        {
            case MainMenu.GameModes.Addition:
                return numbers[0] + numbers[1];
            case MainMenu.GameModes.Subtraction:
                return numbers[0] - numbers[1];
            case MainMenu.GameModes.Multiplication:
                return numbers[0] * numbers[1];
            case MainMenu.GameModes.Division:
                return numbers[0] / numbers[1];
        }
        return result;
    }

    private int[] SelectRange(MainMenu.GameModes mode, MainMenu.GameDifficulty difficulty)
    {
        int[] numbers = new int[2];
        int[] range = numberRanges[Tuple.Create(mode, difficulty)];
        Random generator = new Random();
        numbers[0] = generator.Next(range[0], range[1]);
        numbers[1] = generator.Next(range[0], range[1]);
        return numbers;
    }

    private int[] SelectDivisionRange(MainMenu.GameModes mode, MainMenu.GameDifficulty difficulty)
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

            // Check if 2 numbers generated result in integer:
            if (numbersTocheck[0] % numbersTocheck[1] == 0)
            {
                runTillNumbersCorrect = false;
            }
        }
        return numbersTocheck;
    }
}
