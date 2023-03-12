namespace ConsoleMathGame
{
    internal class Menu
    {
        GameEngine gameEngine = new();
        internal static bool isDivisionOn;
        internal static bool isMultiplicationOn;

        internal void ShowMenu(string name, DateTime date)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Hello {name}. It's {date}.");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Press any key to start.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("---------------------------------");
            bool isGameOn = true;

            do
            {
                Console.WriteLine(@$"What mode would you like to use today? Choose an option:
    A - Addition    
    S - Substraction
    M - Multiplication
    D - Division 
    R - Randomizer!
    V - Show played games
    Q - Quit the program");
                Console.WriteLine("---------------------------------");

                var selectedGame = Console.ReadLine();

                switch (selectedGame.Trim().ToLower())
                {
                    case "v":
                        Helpers.GetGames();
                        break;
                    case "a":
                        gameEngine.AdditionGame("Addition game selected");
                        break;
                    case "s":
                        gameEngine.SubstractionGame("Substraction game selected");
                        break;
                    case "m":
                        isMultiplicationOn = true;
                        gameEngine.MultiplicationGame("Multiplication game selected");
                        break;
                    case "d":
                        isDivisionOn = true;
                        gameEngine.DivisionGame("Division game selected");
                        break;
                    case "r":
                        gameEngine.RandomizerGame("Randomizer game selected");
                        break;
                    case "q":
                        Console.WriteLine("Exiting the program. Goodbye!");
                        isGameOn = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid input");
                        break;
                }
            } while (isGameOn);

        }
    }
}
