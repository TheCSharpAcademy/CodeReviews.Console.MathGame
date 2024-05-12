namespace Visualised.CSharpAcademy.MathGame;

internal class Menu
{
    GameEngine gameEngine = new();
    internal void PrintMenu(string name, DateTime date)
    {
        Console.Clear();
        Console.WriteLine($"Hello {Helpers.UppercaseFirst(name)}. It's {date.DayOfWeek}.\n"
            + "Press any key to continue.");
        Console.ReadLine();

        bool isGameOn = true;
        do
        {
            Console.Clear();
            Console.WriteLine("-------------------------------");
            Console.WriteLine("What game would You like to play?\n"
                + "V - View previous games results\n"
                + "VS - View game results based on conditions\n"
                + "A - Addition\n"
                + "S - Subtraction\n"
                + "M - Multiplication\n"
                + "D - Division\n"
                + "R - Random game \n"
                + "Q - Quit the program");
            Console.WriteLine("-------------------------------");
            Console.Write("Selection: ");
            string gameSelection = Console.ReadLine().ToLower().Trim();

            switch (gameSelection)
            {
                case "v":
                    Console.Clear();
                    gameEngine.PrintGameHistory();
                    break;
                case "vs":
                    Console.Clear();
                    gameEngine.SearchGameHistory();
                    break;
                case "a":
                    Console.Clear();
                    gameEngine.AdditionGame();
                    break;
                case "s":
                    Console.Clear();
                    gameEngine.SubtractionGame();
                    break;
                case "m":
                    Console.Clear();
                    gameEngine.MultiplicationGame();
                    break;
                case "d":
                    Console.Clear();
                    gameEngine.DivisionGame();
                    break;
                case "r":
                    Console.Clear();
                    gameEngine.RandomGame();
                    break;
                case "q":
                    Console.Clear();
                    Console.WriteLine("Goodbye!");
                    isGameOn = false;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid input!");
                    break;
            }

        } while (isGameOn);
    }
}
