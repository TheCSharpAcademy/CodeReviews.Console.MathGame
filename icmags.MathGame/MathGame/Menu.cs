namespace MathGame
{
    internal class Menu
    {
        GameEngine engine = new();
        internal void ShowMenu(string name, DateTime date)
        {
            Console.Clear();
            Console.WriteLine($"Hello {name}. It's {date.DayOfWeek}. This is your math's game.");
            Console.WriteLine("Press any key to show menu.");
            Console.ReadLine();
            Console.WriteLine("\n");
            bool isGameOn = true;

            do
            {
                Console.Clear();
                Console.WriteLine(@"What game would you like to play today? Choose from the options below:
V - View Games History
A - Addition
S - Subtraction
M - Multiplication
D - Division
Q - Quit the program");
                Console.WriteLine("-------------------------------");

                string gameSelected = Console.ReadLine();

                switch (gameSelected.Trim().ToLower())
                {
                    case "v":
                        Helpers.GetGameHistory();
                        break;
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
