namespace MathGame.rthring
{
    internal class Menu
    {
        GameEngine engine = new();
        internal void ShowMenu(string name, DateTime date)
        {
            Console.Clear();
            Console.WriteLine($"Hello {name.ToUpper()}. It's {date.DayOfWeek}. This is your maths game.\n");
            Console.WriteLine("Press any key to show menu");
            Console.ReadLine();
            Console.WriteLine("\n");

            bool isGameOn = true;

            do
            {
                Console.WriteLine($@"What game would you like to play today? Choose from the options below:
V - View previous games
A - Addition
S - Subtraction
M - Multiplication
D - Divison
Q - Quit the program");
                Console.WriteLine("---------------------------------------");

                var gameSelected = Console.ReadLine();

                switch (gameSelected.Trim().ToLower())
                {
                    case "v":
                        Helpers.PrintGames();
                        break;
                    case "a":
                        engine.AdditionGame("Addition game");
                        break;
                    case "s":
                        engine.SubtractionGame("Subtraction game");
                        break;
                    case "m":
                        engine.MultiplicationGame("Multiplication game");
                        break;
                    case "d":
                        engine.DivisionGame("Division game");
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
