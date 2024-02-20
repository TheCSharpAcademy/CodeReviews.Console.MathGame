namespace Masherishere.MathGame
{
    internal class Menu
    {
        GameEngine gameEngine = new();

        internal void ShowMenu(string name, DateTime date)
        {
            Console.Clear();
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Hello {name}, It's {date}. This is your math's game. That's greate that you're working on improving yourself");
            Console.WriteLine("\n");
            var isGameOn = true;
            do
            {
                Console.WriteLine(@$"What game would you like to play today? Choose from the options below:
V - Get Histories
A - Addition
S - Substraction
M - Multiplication
D - Division
Q - Quit the program");
                Console.WriteLine("------------------------------");

                var gameSelected = Console.ReadLine();

                switch (gameSelected?.Trim().ToLower())
                {
                    case "v":
                        Helpers.PrintGames();
                        break;
                    case "a":
                        gameEngine.AdditionGame("Addition Game Selected");
                        break;
                    case "s":
                        gameEngine.SubtractionGame("Subtraction Game Selected");
                        break;
                    case "m":
                        gameEngine.MultiplicationGame("Multiplication Game Selected");
                        break;
                    case "d":
                        gameEngine.DivisionGame("Division Game Selected");
                        break;
                    case "q":
                        Console.WriteLine("Exit Program");
                        isGameOn = false;
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            } while (isGameOn);

        }

    }
}
