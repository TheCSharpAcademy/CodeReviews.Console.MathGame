namespace MathApp
{
    internal class Menu
    {
        DateTime date = DateTime.UtcNow;
        GameEngine gameEngine = new GameEngine();
        internal void ShowMenu(string? name)
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine($"Hello {name}. It's {date}. This is your math's game. That's great that you're working on improving yourself\n");
            Console.WriteLine("\n");

            bool isGameOn = true;

            do
            {
                Console.Clear();
                Console.WriteLine($@"
What game would you like to play today? Choose from the options below:
V - View Previous Games
A - Addition
S - Subtraction
M - Multiplication
D - Division
Q - Quit the program");
                Console.WriteLine("------------------------------------------------");

                var gameSelected = Console.ReadLine().Trim().ToLower();

                switch (gameSelected)
                {
                    case "v":
                        Helpers.GetGames();
                        break;
                    case "a":
                        gameEngine.AdditionGame("Addition game");
                        break;
                    case "s":
                        gameEngine.SubstractionGame("Subtraction game");
                        break;
                    case "m":
                        gameEngine.MultiplicationGame("Multiplication game");
                        break;
                    case "d":
                        gameEngine.DivisionGame("Division game");
                        break;
                    case "q":
                        Console.WriteLine("Goodbye");
                        isGameOn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }
            } while (isGameOn);
        }
    }
}
