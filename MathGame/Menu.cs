namespace MathGame
{
    internal class Menu
    {
        GameEngine gameEngine = new();
        bool isGameOn = true;

        internal void ShowMenu(string name, DateTime date)
        {
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine($"Hello {name.ToUpper()}. It's {date.DayOfWeek}. This your math game. That's great that you're working on improving yourself!\n");

            do
            {
                Console.WriteLine(@$"What game would you like to play today? Choose from the options below:
V - View Previous Games
A - Addition
S - Subtraction
M - Multiplication
D - Division
Q - Quit the program");
                Console.WriteLine("---------------------------------------------------");

                var gameSelected = Console.ReadLine().ToLower().Trim();

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
                        gameEngine.DivisionGame("Divison game");
                        break;
                    case "q":
                        Console.WriteLine("Goodbye");
                        isGameOn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input. You must choose an option from the list. Press any key to continue.");
                        Console.ReadLine();
                        break;
                }
            } while (isGameOn);
        }
    }
}
