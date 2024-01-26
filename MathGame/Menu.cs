namespace MathGame;

internal class Menu
{
    GameEngine gameEngine = new();
    internal void ShowMenu(string name, DateTime date) 
    {
        bool gameOn = true;

        Console.WriteLine("----------------------------------");
        Console.WriteLine($"Hello {name}. It's {date}. This is your math game. That's great that your working on improving yourself\n");
        Console.WriteLine("Press any key to show menu");
        Console.ReadLine();

        do
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine(@$"What game would you like to play today? Choose from the options below:
                V - View previous games
                A - Addition
                S - Substraction
                M - Multiplication
                D - Division
                R - Random
                Q - Quit the program");
            Console.WriteLine("----------------------------------");

            string? gameSelected = Console.ReadLine();

            string? diff;

            int times;

            switch (gameSelected.Trim().ToLower())
            {
                case "a":
                    diff = DifficultyMenu();
                    times = AmountOfGames();
                    gameEngine.AdditionGame("Addition game", diff.Trim().ToLower(), times);
                    break;
                case "s":
                    diff = DifficultyMenu();
                    times = AmountOfGames();
                    gameEngine.SubtractionGame("Subtraction game", diff.Trim().ToLower(), times);
                    break;
                case "m":
                    diff = DifficultyMenu();
                    times = AmountOfGames();
                    gameEngine.MultiplicationGame("Multiplication game", diff.Trim().ToLower(), times);
                    break;
                case "d":
                    diff = DifficultyMenu();
                    times = AmountOfGames();
                    gameEngine.DivisionGame("Division game", diff.Trim().ToLower(), times);
                    break;
                case "v":
                    Helpers.GetGames();
                    break;
                case "r":
                    gameEngine.RandomGame();
                    break;
                case "q":
                    Console.WriteLine("Goodbye");
                    gameOn = false;
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    Environment.Exit(1);
                    break;
            }
        } while (gameOn);
    }

    internal static int AmountOfGames()
    {
        Console.WriteLine("How many times do you want to play?");
        string? count = Console.ReadLine();
        int times = 0;
        while (Int32.TryParse(count, out times) != true)
        {
            Console.WriteLine("The input must be a valid number");
            count = Console.ReadLine();
        }
        return times;
    }

    internal static string DifficultyMenu()
    {
        Console.WriteLine("----------------------------------");
        Console.WriteLine(@"Choose your difficulty:
                E - Easy
                R - Regular
                H - Hard");

        string? diff = Helpers.GetDifficulty();
        return diff;
    }
}
