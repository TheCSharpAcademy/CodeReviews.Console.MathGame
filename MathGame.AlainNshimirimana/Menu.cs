namespace MathGame.AlainNshimirimana
{
    internal class Menu
    {
        GameEngine engine = new();
        internal void ShowMenu(string name, DateTime date)
        {
            Console.Clear();
            Console.WriteLine($"Hello {name.ToUpper()}. It's {date.DayOfWeek}. This is your math's game. That's great that you're working on improving yourself");
            Console.WriteLine("Press any key to show Menu");
            Console.ReadLine();
            Console.WriteLine("\n");

            var isGameOn = true;

            do
            {
                Console.Clear();
                Console.WriteLine($@"What game would you like to play today? Choose from the options below:
         A - Addition 
         S - Subtraction
         M - Multiplication
         D - Division
         V - Game History
         Q - Quit the program");
                Console.WriteLine("-----------------------------");

                var gameSelected = Console.ReadLine();

                switch (gameSelected.Trim().ToLower())
                {
                    case "v":
                        Helpers.PrintGames();
                        break;
                    case "a":
                        Helpers.GetDifficulty();
                        engine.AdditionGame("Addition game");
                        break;
                    case "s":
                        Helpers.GetDifficulty();
                        engine.SubtractionGame("Subtraction game");
                        break;
                    case "m":
                        Helpers.GetDifficulty();
                        engine.MultiplicationGame("Multiplication game");
                        break;
                    case "d":
                        Helpers.GetDifficulty();
                        engine.DivisionGame("Division game");
                        break;
                    case "q":
                        Console.WriteLine("Goodbye!");
                        isGameOn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            } while (isGameOn);
        }
    }
}
