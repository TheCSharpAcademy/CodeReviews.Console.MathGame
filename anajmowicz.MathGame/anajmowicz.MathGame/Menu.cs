using anajmowicz.MathGame.Models;

namespace anajmowicz.MathGame
{
    internal class Menu
    {
        GameEngine engine = new GameEngine();
        internal void ShowMenu(string name, DateTime date)
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine($"Hello {name}! It's {date.DayOfWeek}. Are you ready to play a game?");
            Console.WriteLine("\n");

            bool isGameOn = true;

            do
            {
                Console.Clear();
                Console.WriteLine(@"What game would you like to play today? Please select from the options below:
    A - Addition
    S - Subtraction
    M - Multiplication
    D - Division

    V - View previous games
    Q - Quit the game
");
                Console.Write("> ");

                string gameSelected = Console.ReadLine();

                switch (gameSelected.Trim().ToLower())
                {
                    case "a":
                        engine.AdditionGame(GameType.Addition);
                        break;
                    case "s":
                        engine.SubtractionGame(GameType.Subtraction);
                        break;
                    case "m":
                        engine.MultiplicationGame(GameType.Multiplication);
                        break;
                    case "d":
                        engine.DivisionGame(GameType.Division);
                        break;
                    case "v":
                        Helpers.PrintGames();
                        break;
                    case "q":
                        Console.WriteLine("Goodbye!");
                        isGameOn = false;
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        Environment.Exit(1);
                        break;
                }
            } while (isGameOn);

        }
    }
}
