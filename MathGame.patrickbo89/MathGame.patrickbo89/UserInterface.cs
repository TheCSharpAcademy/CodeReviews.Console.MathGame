namespace MathGame.patrickbo89;

internal class UserInterface
{
    internal static void DisplayHistory(GameEngine gameEngine)
    {
        Console.Clear();

        DrawLine();
        foreach (Game game in gameEngine.History)
        {
            string tabstop = "\t";

            if (game.Type == GameType.Addition || game.Type == GameType.Division || game.Type == GameType.Random)
                tabstop = "\t\t";

            Console.WriteLine($"{game.StartTime} - {game.Type} ({game.Difficulty}){tabstop} - Score: {game.Score}/{game.NumberOfQuestions}\t - Time: {game.ElapsedSeconds}s");
        }
        DrawLine();

        Console.WriteLine("\nPress any key to return to the main menu.");
        Console.ReadKey();
    }

    internal static Difficulty GetDifficulty(GameType gameType)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($@"On what difficulty will you play the {gameType} game?

1 - Easy
2 - Medium
3 - Hard");

            Console.Write("\nPlease enter your choice: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    return Difficulty.Easy;
                case "2":
                    return Difficulty.Medium;
                case "3":
                    return Difficulty.Hard;
                default:
                    Console.WriteLine("\nInvalid choice. Press any key to try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    internal static string GetName()
    {
        Console.Write("Please enter your name: ");

        var name = Console.ReadLine();

        while (string.IsNullOrEmpty(name))
        {
            Console.Write("Name must not be empty. Please try again: ");
            name = Console.ReadLine();
        }

        return name;
    }

    internal static int GetNumberOfQuestions(GameType gameType)
    {
        int numberOfQuestions;

        Console.Clear();
        Console.Write($"How many questions of {gameType} will you play? ");
        var input = Console.ReadLine();

        while (!int.TryParse(input, out numberOfQuestions))
        {
            Console.Write("\nInvalid input. Please enter a whole number: ");
            input = Console.ReadLine();
        }

        return numberOfQuestions;
    }

    private static void DrawLine() => Console.WriteLine("-------------------------------------------------------------------------------");

    internal static void DisplayHeader(Game game, int currentQuestionNumber)
    {
        Console.Clear();
        Console.WriteLine($"{game.Type} Game ({game.Difficulty}) - Question {currentQuestionNumber} of {game.NumberOfQuestions}");
    }

    internal static void DisplayQuestion(int[] numbers, char operatorSymbol)
    {
        Console.Write($"{numbers[0]} {operatorSymbol} {numbers[1]} = ");
    }

    internal static string GetResultInput(int[] numbers, char operatorSymbol)
    {
        var resultInput = Console.ReadLine();
        resultInput = ValidateResultInput(resultInput, numbers, operatorSymbol);

        return resultInput;
    }

    private static string ValidateResultInput(string? resultInput, int[] numbers, char operatorSymbol)
    {
        while (string.IsNullOrEmpty(resultInput) || !int.TryParse(resultInput, out _))
        {
            Console.WriteLine("\nYour answer must be a whole number. Try again.");
            Console.Write($"{numbers[0]} {operatorSymbol} {numbers[1]} = ");
            resultInput = Console.ReadLine();
        }

        return resultInput;
    }

    internal static void DisplayAnswerOutcome(bool isCorrectAnswer)
    {
        if (isCorrectAnswer)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Correct! Press any key to continue.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Incorrect! Press any key to continue.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }
    }
    internal static void DisplayGameResult(Game game)
    {
        Console.WriteLine($"\nThe game is over. You had {game.Score} of {game.NumberOfQuestions} correct answers. You took {game.ElapsedSeconds} seconds. Press any key to return to the main menu.");
        Console.ReadKey();
    }

    internal static void DisplayGreeting(DateTime date, string name)
    {
        Console.Clear();
        Console.WriteLine($"Hello, {name}. It's {date}. Welcome to the Math Game. Be ready to be challenged!");
        Console.WriteLine("\nPress any key to show the menu.");
        Console.ReadKey();
    }

    internal static void DisplayMenuOptions()
    {
        Console.Clear();
        DrawLine();
        Console.WriteLine($@"What type of game would you like to play this time? Choose an option:

V - View Game History
A - Addition
S - Subtraction
M - Multiplication
D - Division
R - Random
Q - Quit");

        DrawLine();
    }

    internal static void DisplayQuitMessage()
    {
        Console.WriteLine("\nHope you had fun playing the game. Bye!");
        Console.ReadKey();
    }

    internal static void DisplayInvalidMenuChoiceMessage()
    {
        Console.WriteLine("\nInvalid choice...");
        Console.WriteLine("Press any key to go back to the main menu.");
        Console.ReadKey();
    }
}