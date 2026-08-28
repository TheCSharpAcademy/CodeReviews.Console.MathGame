namespace MathGame.DzemalKurtic
{
    internal class Menu
    {
        GameEngine gameEngine = new();
        internal void ShowMenu(string? name, DateTime date)
        {
            Console.Clear();
            Console.WriteLine($"Hello {name}. It's {date}. This is your math's game. That's great that you're working on improving yourself");
            Console.WriteLine("Press any key to show menu");
            Console.ReadLine();
            Console.WriteLine("\n");

            bool isGameOn = true;

            do
            {
                Console.Clear();
                Console.WriteLine($@"What game would you like to play? Choose from options below:
                        V - View Previous Games
                        A - Addition
                        S - Subtraction
                        M - Multiplication
                        D - Division
                        Q - Quit the program");

                Console.WriteLine();

                var gameSelected = Console.ReadLine()?.Trim().ToLower();

                switch (gameSelected)
                {
                    case "v":
                        Helpers.PrintGames();
                        break;
                    case "a":
                        gameEngine.AdditionGame("Addition game");
                        break;
                    case "s":
                        gameEngine.SubtractionGame("Subtraction game");
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
                        Console.WriteLine("Invalid input");
                        break;
                }
            } while (isGameOn);
        }

    }
}
