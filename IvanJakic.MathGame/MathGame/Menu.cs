
namespace MathGame
{
    internal class Menu
    {
        GameEngine engine = new();
        internal void ShowMenu(string name, DateTime date)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"Hello {name.ToUpper()}. It's {date}. This is your math's game.\n");
            Console.WriteLine("Press any key to show menu");
            Console.ReadLine();
            Console.WriteLine("\n");

            bool isGameOn = true;

            do
            {
                Console.Clear();
                Console.WriteLine(@$"What game would you like to play today? Choose from the options below:
            V - View previous games
            A - Addition
            S - Subtraction
            M - Multiplication
            D - Division
            Q - Quit the program");
                Console.WriteLine("---------------------------------------------");

                var gameSelected = Console.ReadLine();

                switch (gameSelected.Trim().ToLower())
                {
                    case "v":
                        Helpers.PrintGames();
                        break;
                    case "a":
                        engine.AdditionGame("Addition");
                        break;
                    case "s":
                        engine.SubtractionGame("Subtraction");
                        break;
                    case "m":
                        engine.MultiplicationGame("Multiplication");
                        break;
                    case "d":
                        engine.DivisionGame("Division");
                        break;
                    case "q":
                        Console.WriteLine("Goodbye");
                        isGameOn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        Console.ReadKey();
                        break;
                }
            } while (isGameOn);

        }
    }
}
