namespace MathGame
{
    internal class Menu
    {
        GameEngine engine = new();
        internal void ShowMenu(string? name, DateTime date)
        {
            Console.Clear();
            Console.WriteLine($"Hello {name.ToUpper()}. It's {date.DayOfWeek}. Welcome to the Math Game!! \n");
            Console.WriteLine("Press any key to show the game menu");
            Console.ReadLine();
            Console.WriteLine("\n");

            bool isGameOn = true;

            do

            {
                Console.Clear();
                Console.WriteLine($@"
Which game would you like to play today? Choose from the options below:
A - Addition
S - Subtraction
M - Miultiplication
D - Division
R - Random
V - View Games
Q - Quit");
                Console.WriteLine("--------------------------");

                var gameSelected = Console.ReadLine().Trim().ToLower();

                switch (gameSelected)
                {
                    
                    case "a":
                        engine.AdditionGame("Addition Game");
                        break;
                    case "s":
                        engine.SubtractionGame("Subtraction Game");
                        break;
                    case "m":
                        engine.MultiplicationGame("Multiplication Game");
                        break;
                    case "d":
                        engine.DivisionGame("Division Game");
                        break;
                    case "r":
                        engine.RandomGame("Random Game");
                        break;
                    case "v":
                        Helpers.PrintGames();
                        break;
                    case "q":
                        Console.WriteLine("Goodbye");
                        Environment.Exit(1);
                        isGameOn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        Environment.Exit(1);
                        isGameOn = false;
                        break;
                }
            } while (isGameOn);
        }
    }
}
