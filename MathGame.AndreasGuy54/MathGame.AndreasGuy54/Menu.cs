namespace MathGame.AndreasGuy54
{
    internal class Menu
    {
        GameEngine engine = new();
        internal void ShowMenu(string? name, DateTime date)
        {
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine($"Hello {name.ToUpper()}. It's {date.DayOfWeek}. This is your math's game\n");

            bool isGameOn = true;

            do
            {
                Console.WriteLine($@"What game would you like to play today? Chooose from the options below:

                        V - View History
                        A - Addition
                        S - Subtraction
                        M - Multiplication
                        D - Division
                        Q - Quit Game");
                Console.WriteLine("\n---------------------------------------------------");

                string gameSelected = Console.ReadLine().Trim().ToLower();

                switch (gameSelected)
                {
                    case "v":
                        Helpers.GetGames();
                        Console.Clear();
                        break;
                    case "a":
                        engine.AdditionGame("Addition Game");
                        Console.Clear();
                        break;
                    case "s":
                        engine.SubtractionGame("Subtraction Game");
                        Console.Clear();
                        break;
                    case "m":
                        engine.MultiplicationGame("Multiplication Game");
                        Console.Clear();
                        break;
                    case "d":
                        engine.DivisionGame("Division Game");
                        Console.Clear();
                        break;
                    case "q":
                        Console.WriteLine("Goodbye!");
                        isGameOn = false;
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            } while (isGameOn);
        }
    }
}
