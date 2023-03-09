
namespace MathGame.chad1082;

internal class Menu
{

    internal void ShowMainMenu(string name, DateTime date)
    {
        Console.WriteLine("-----------------------------------");
        Console.WriteLine($"Hello {name}, Welcome to the Math's game, it is now {date}\n");
        
        bool gameRunning = true;

        do
        {
            MainMenu();
            //Console.Clear();
        } while (gameRunning);

    }

    private void MainMenu()
    {
        GameEngine gameEngine = new();

        Console.WriteLine(@"What game would you like to play? Select an option from below:
            A - Addition
            S - Subtraction
            M - Multiplication
            D - Division
            V - View previous scores
            Q - Quit the game :(");
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("\n");

        string menuOption = Console.ReadLine();
        
        switch (menuOption.Trim().ToUpper())
        {
            case "A":
                //gameEngine.AdditionGame("Addition Game\n");
                gameEngine.StartGame(GameType.Addition);
                Console.Clear();
                break;
            case "S":
                gameEngine.StartGame(GameType.Subtraction);
                Console.Clear();
                break;
            case "M":
                gameEngine.StartGame(GameType.Multiplication);
                Console.Clear();
                break;
            case "D":
                gameEngine.StartGame(GameType.Division);
                Console.Clear();
                break;
            case "V":
                Helpers.ShowScores();
                Console.Clear();
                break;
            case "Q":
                Console.WriteLine("Goodbye!");
                Environment.Exit(0);
                break;
            default:
                Console.Clear();
                Console.WriteLine("Unrecognised input, Please select an option from the menu. ");
                break;
        }
    }
}
