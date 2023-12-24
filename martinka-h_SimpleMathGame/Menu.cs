namespace SimpleMathGame
{
    internal class Menu
    {
        GameEngine engine = new();
        internal void ShowMenu(string name, DateTime date)
        {
            bool isGameOn = true;

            do
            {
                Console.Clear();
                Console.WriteLine("------------------------------------");
                Console.WriteLine($"Hello {name}. It's {date.DayOfWeek}. This is your math game.\n");
                Console.WriteLine(@"What game would you like to play today? Choose from the options below:
                            A - Addition
                            S - Subtraction
                            M - Multiplication
                            D - Division
                            H - View previous games
                            Q - Quit the program
                            ------------------------------------");

                string? gameSelected = Console.ReadLine();

                switch (gameSelected?.Trim().ToLower())
                {
                    case "a":
                        engine.AdditionGame("Addition game.");
                        break;
                    case "s":
                        engine.SubtractionGame("Subtraction game.");
                        break;
                    case "m":
                        engine.MultiplicationGame("Multiplication game.");
                        break;
                    case "d":
                        engine.DivisionGame("Division game.");
                        break;
                    case "h":
                        Helpers.showGameHistory();
                        break;
                    case "q":
                        Console.Clear();
                        Console.WriteLine("Goodbye");
                        isGameOn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        isGameOn = false;
                        break;
                }
            } while (isGameOn);
        }

    }
}
