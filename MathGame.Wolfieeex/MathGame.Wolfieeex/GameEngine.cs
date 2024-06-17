using MathGame.Wolfieeex.Models;

namespace MathGame.Wolfieeex;

internal class GameEngine
{
    // Value ranges for all difficulties and game modes, public field for timer event:
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
    private int time;

    private string Name;
    private GameModes Mode;
    private GameDifficulty Difficulty;
    private int QuestionsCount;

    public GameEngine(string name, GameModes mode, GameDifficulty difficulty, int questionsCount)
    {
        Name = name;
        Mode = mode;
        Difficulty = difficulty;
        QuestionsCount = questionsCount;
    }

    public void RunGame()
    {
        // Prompt for user before the game starts:
        Console.Clear();
        Console.WriteLine($"You are playing {Mode.ToString().ToLower()} game. You will be challanged with {QuestionsCount} {Difficulty.ToString().ToLower()} questions.");
        Console.Write("\n\n\nPress Enter whenever you are ready to start: ");
        Console.ReadLine();
        Console.Clear();

        // Initiate Timer:
        System.Timers.Timer gameTime = new System.Timers.Timer(1000);
        gameTime.Elapsed += GameTime_Elapsed;
        gameTime.Enabled = true;
        gameTime.AutoReset = true;

        // Initiate other variables:
        int score = 0;

        // Start the game:
        for (int i = QuestionsCount; i > 0; i--)
        {
            // Display a question that will prompt user to give an answer, also display a game timers:
            Console.Write($"Question {QuestionsCount - i + 1} of {QuestionsCount}:");
            Console.SetCursorPosition(40, 0);
            Console.WriteLine($"Time elapsed: {time.ToString()} seconds");
            Console.WriteLine($"{new string('-', Console.BufferWidth)}");

            // If random mode slected, decide how to calculate the numbers:
            GameModes currentMode = Mode;
            if (Mode == GameModes.Random)
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
                numbers = SelectDivisionRange(currentMode, Difficulty);
            else
                numbers = SelectRange(currentMode, Difficulty);

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
                    new string[] { "e" }, new int[] { -1000000, 1000000 },
                    notInRangeFailMessage: $"{numbers[0]} {GetSign(currentMode)} {numbers[1]} = "
                );

            // If user pressed "e" to exit the game:
            if (userInput.ToLower() == "e")
            {
                Console.Clear();
                Console.WriteLine("You have exited the game. Come again soon?");
                break;
            }

            // If user inserted a correct answer, compare it to result and display one of the messages. After that, the loop repeats:
            int intInput = int.Parse(userInput);
            if (intInput == result)
            {
                score++;
                Console.WriteLine($"\nYour answer is correct! Current score: {score} out of {QuestionsCount} questions.");
                Console.WriteLine($"\n\n\r{new string(' ', Console.BufferWidth)}");
                Console.Write($"\rPress Enter to continue: ");
            }
            else
            {
                Console.WriteLine($"\nThat's incorrect... The {GetProductType(currentMode)} of {numbers[0]} and {numbers[1]} is {result}.");
                Console.WriteLine($"Current score: {score} out of {QuestionsCount} questions.");
                Console.WriteLine($"\n\r{new string(' ', Console.BufferWidth)}");
                Console.Write($"\rPress Enter to continue: ");
            }
            Console.ReadLine();
            Console.Clear();
        }
        // After the loop is exited or ends by itself, on game finish, show user their results and log the game:
        gameTime.Enabled = false;
        LogGame(Name, DateTime.Now, Mode, Difficulty, QuestionsCount, score, time);
        Console.WriteLine($"Your final score is {score} out of {QuestionsCount} questions!");
        Console.WriteLine($"You finished the game in {time} seconds.");
        Console.Write("\n\n\nPress Enter to return to the main menu: ");
        Console.ReadLine();
    }

    // Timer displaying gameplay time:
    private void GameTime_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
    {
        time++;
        int cursorX = Console.CursorLeft;
        int cursorY = Console.CursorTop;
        Console.SetCursorPosition(40, 0);
        Console.Write($"Time elapsed: {time.ToString()} seconds");
        Console.SetCursorPosition(cursorX, cursorY);
    }

    // Save game details to public field. This list can be then displayed from the main menu:
    private void LogGame(string name, DateTime date, GameModes mode, GameDifficulty difficulty, int questionsCount, int score, int time)
    {
        Helpers.GameInstances.Add(new GameInstance
        {
            Name = name,
            Date = date,
            Score = score,
            Type = mode,
            Difficulty = difficulty,
            QuestionsCount = questionsCount,
            Time = time
        });
    }

    // Returns +, -, *, or / depending on current game mode:
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

    // Returns "sum", "subtraction", "product", or "quotient" based on current game mode:
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

    // Depending on game mode, return the product of 2 numbers:
    private int CalculateResult(GameModes mode, int[] numbers)
    {
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

    // Return 2 numbers for the next round randomised between minimal and maximal range returned from the Dictionary field "numberRanges",
    // based on game mode and difficulty chosen. Range for division must return divisible numbers, so additional checks are added to
    // a method below:
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
