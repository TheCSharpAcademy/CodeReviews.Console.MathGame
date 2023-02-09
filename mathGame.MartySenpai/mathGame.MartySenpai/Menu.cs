namespace MathGame;

internal class Menu
{
    GameEngine gameEngine = new GameEngine();
    internal void ShowMenu(string name, DateTime date)
    {
        Console.Clear();
        Console.WriteLine($"Hello {name}. It's {date.DayOfWeek}. This is your math's game. That's great that you're working on improving yourself\n");
        Console.WriteLine("Press any key to show menu");
        Console.ReadLine();
        Console.WriteLine("\n");

        bool isGameOn = true;

        do
        {
            Console.Clear();
            Console.WriteLine(@$"
What game would you like to play today? Choose from the options below:
H - History
A - Addition
S - Subtraction
M - Multiplication
D - Division
R - Randomized
Q - Quit the program");
            Console.WriteLine("-----------------------------------------------------------------------");

            string gameSelected = Console.ReadLine();

            switch (gameSelected.Trim().ToLower())
            {
                case "h":
                    Helpers.PrintGames();
                    break;
                case "a":
                    gameEngine.AdditionGame("Addition game", '+');
                    break;
                case "s":
                    gameEngine.SubtractionGame("Subtraction game", '-');
                    break;
                case "m":
                    gameEngine.MultiplicationGame("Multiplication game", '*');
                    break;
                case "d":
                    gameEngine.DivisionGame("Division game");
                    break;
                case "r":
                    gameEngine.RandomGame("Randomized game");
                    break;
                case "q":
                    Console.Clear();
                    Console.WriteLine("Goodbye!");
                    isGameOn = false;
                    break;
                default:
                    Console.WriteLine("Invalid input, press enter to continue and enter a valid key.");
                    Console.ReadLine();
                    break;
            }
        } while (isGameOn);
    }
    internal static string ShowDifficultyMenu()
    {
        bool selectingDifficulty = true;

        string difficulty = "";

        do
        {
            Console.Clear();
            Console.WriteLine(@$"
Please choose a difficulty option:
1 - Easy
2 - Normal
3 - Hard");

            string input = Console.ReadLine();

            switch (input.Trim().ToLower())
            {
                case "1":
                    difficulty = "Easy";
                    selectingDifficulty = false;
                    break;
                case "2":
                    difficulty = "Normal";
                    selectingDifficulty = false;
                    break;
                case "3":
                    difficulty = "Hard";
                    selectingDifficulty = false;
                    break;
                default:
                    Console.WriteLine("Invalid input, press enter to continue and enter a valid key.");
                    Console.ReadLine();
                    break;
            }

        } while (selectingDifficulty);

        return difficulty;
    }
}
