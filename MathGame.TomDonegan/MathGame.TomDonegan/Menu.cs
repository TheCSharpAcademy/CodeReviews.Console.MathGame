namespace MathGameConsole
{
    internal class Menu
    {
        // Makes the games from within GameEngine accessable.
        GameEngine engine = new();
        internal void ShowMenu(string name, DateTime date)
        {
            Console.Clear();

            bool isGameOn = true;

            do
            {
                Console.Clear();
                Console.WriteLine("----------------------------------");
                Console.WriteLine($@"Hey {name}, What game would you like to play today? Choose from the options below:

    A - Addition
    S - Subtraction
    M - Multiplication
    D - Division
    R - Random
    V - Show Game History
    Q - Quit the program");
                Console.WriteLine("----------------------------------");

                string? gameSelection = Console.ReadLine();
                var adjustSelection = gameSelection.Trim().ToLower();

                Console.Clear();

                switch (adjustSelection)
                {
                    case "a":
                        engine.PlayGame(1);
                        break;
                    case "s":
                        engine.PlayGame(2);
                        break;
                    case "m":
                        engine.PlayGame(4);
                        break;
                    case "d":
                        engine.PlayGame(3);
                        break;
                    case "r":
                        engine.PlayGame(5);
                        break;
                    case "q":
                        Console.WriteLine("Goodbye");
                        isGameOn = false;
                        Environment.Exit(1);
                        break;
                    case "v":
                        Helpers.PrintGames();
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            } while (isGameOn);
        }

    }
}
