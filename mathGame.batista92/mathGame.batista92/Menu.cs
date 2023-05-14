namespace mathGame.batista92;

internal class Menu
{
    GameEngine gameEngine = new();
    internal void ShowMenu(string name, DateTime date)
    {
        Console.Clear();
        Console.WriteLine($"Hello {name}. It's {date}. This is your math's game. That's great that you're working on improving yourself");
        Console.WriteLine("Press any key to show menu");
        Console.ReadLine();
        Console.WriteLine();

        bool isGameOn = true;

        do
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine($@"What game would you like to play today? Choose from the options below:
V - View Previous Games
A - Addition
S - Subtraction
M - Multiplication
D - Division
Q - Quit the program");
            Console.WriteLine("---------------------------------------------------");

            string gameSelected = Console.ReadLine();
            switch (gameSelected.Trim().ToLower())
            {
                case "v":
                    Helpers.PrintGames();
                    break;
                case "a":
                    gameEngine.AdditionGame("Addition Game");
                    break;
                case "s":
                    gameEngine.SubtractionGame("Subtraction Game");
                    break;
                case "m":
                    gameEngine.MultiplicationGame("Multiplication Game");
                    break;
                case "d":
                    gameEngine.DivisionGame("Division Game");
                    break;
                case "q":
                    Console.Clear();
                    Console.WriteLine("See you later!");
                    isGameOn = false;
                    break;
                default:
                    Console.WriteLine("Invalid input, Try again...");
                    break;
            }

        } while (isGameOn);
    }
}
