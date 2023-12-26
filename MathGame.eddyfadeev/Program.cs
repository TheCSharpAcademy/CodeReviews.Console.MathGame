namespace MathGame.eddyfadeev;

class Program
{
    private static int _rounds = 5;
    private static int _minRange = 1;
    private static int _maxRange = 20;
    static void Main(string[] args)
    {
        // Welcome message.
        ShowWelcomeMessage();

        // Main menu.
        while (true)
        {
            ShowMainMenu(_rounds, _minRange, _maxRange);
            // Get input from the user.
            char input = GameUtils.GetInput(GameUtils.AvailableHotKeys);

            if (GameUtils.AvailableHotKeys.Contains(input))
            {
                SelectGameMode(input);
            }
            else
            {
                ChangeOptions(input);
            }
            Console.Clear();
        }
    }

    /**
     * <summary>
     * Prints welcome message and waits for user to press any key.
     * </summary>
     */
    private static void ShowWelcomeMessage()
    {
        Console.WriteLine("Welcome to the Math Game!");
        Console.WriteLine("To select an option, enter the letter and press Enter.");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }

    private static void ShowMainMenu(int rounds, int minRange, int maxRange)
    {
        Console.WriteLine("-----------------------------------------------------------");
        Console.WriteLine($"Total Score: {GameUtils.TotalScore}");
        Console.WriteLine("V - View Previous Games");
        Console.WriteLine("-----------------------------------------------------------");
        Console.WriteLine("What game would you like to play?");
        GameUtils.DisplayGameOptions(GameUtils.AvailableOptions);
        Console.WriteLine("-----------------------------------------------------------");
        Console.WriteLine("Settings");
        Console.WriteLine($"G - Rounds: {rounds}, L - Lower Range: {minRange}, U - Upper Range: {maxRange}");
        Console.WriteLine("-----------------------------------------------------------");
        Console.WriteLine("Q - Quit the program");
    }

    private static void ChangeOptions(char userInput)
    {
        switch (userInput)
        {
            case 'G':
                Console.WriteLine("How many rounds would you like to play?");
                Console.Write("Enter number from 1 to 20: ");
                _rounds = GameUtils.GetInput(1, 20);
                break;
            case 'L':
                Console.WriteLine("Please enter the number we should count from.");
                Console.Write("Enter number from 1 to 999: ");
                _minRange = GameUtils.GetInput(1, 999);
                _maxRange = _minRange > _maxRange ? _minRange + 1 : _maxRange;
                break;
            case 'U':
                Console.WriteLine("Please enter the  number we should count to.");
                Console.Write($"Enter number from {_minRange} to 1000: ");
                _maxRange = GameUtils.GetInput(_minRange, 1000);
                break;
            case 'V':
                GameUtils.DisplayGameHistory();
                break;
            case 'Q':
                Environment.Exit(0);
                break;
        }
    } // end of ChangeOptions method.

    private static void SelectGameMode(char userInput)
    {
        switch (userInput)
        {
            case 'A':
                new MathGame(GameOptions.Addition, _rounds, _minRange, _maxRange).Start();
                break;
            case 'S':
                new MathGame(GameOptions.Subtraction, _rounds, _minRange, _maxRange).Start();
                break;
            case 'M':
                new MathGame(GameOptions.Multiplication, _rounds, _minRange, _maxRange).Start();
                break;
            case 'D':
                new MathGame(GameOptions.Division, _rounds, _minRange, _maxRange).Start();
                break;
            case 'R':
                new MathGame(GameOptions.Random, _rounds, _minRange, _maxRange).Start();
                break;
        }
    } // end of SelectGameMode method.
} // end of Program class.