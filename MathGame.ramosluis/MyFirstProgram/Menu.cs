namespace MyFirstProgram
{
    internal class Menu
    {
        GameEngine gameEngine = new();
        internal void ShowMenu(string name, DateTime date)
        {
            Console.Clear();
            Console.WriteLine($"Hello {name.ToUpper()}. it's {date.DayOfWeek}. This is your math game. That's great that you're working on improving yourself\n");
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();

            var isGameOn = true;

            do
            {
                Console.Clear();
                Console.WriteLine($@"What game would you like to play today? Choose from the options below:
A - Addition
S - Subtraction
M - Multiplication
D - Division
V - View previous games
Q - Quit the program");
                Console.WriteLine("-----------------------------------------");

                var gameSelected = Console.ReadLine().Trim().ToLower();

                Console.WriteLine("\n");

                switch (gameSelected)
                {
                    case "a":
                        gameEngine.AdditionGame("Addition Game");
                        break;
                    case "s":
                        gameEngine.SubtractionGame("Subtraction Game");
                        break;
                    case "m":
                        gameEngine.MultiplicationGame("Multiplication Game");
                        break;
                    case "d":
                        gameEngine.DivisionGame("Division Game");
                        break;
                    case "v":
                        Helpers.PrintGames();
                        break;
                    case "q":
                        Console.WriteLine("Quitting the game, buh bye!");
                        isGameOn = false;
                        break;
                    default:
                        Console.WriteLine("Command unknown, please select a valid option from the list.\nPress enter to continue.");
                        Console.ReadLine();
                        break;
                }

            } while (isGameOn);
        }
    }
}
