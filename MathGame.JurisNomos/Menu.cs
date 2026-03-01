namespace Game
{
    internal class Menu
    {
        internal static void ShowMenu(string name, DateTime date)
        {
            Console.Clear();
            Console.WriteLine("---");
            Console.WriteLine($"Hello {name}. It's {date}. This is your math's game. That's great that you're working on improving yourself\n");
            Console.WriteLine("Press any key to show menu");
            Console.ReadLine();
            Console.WriteLine("\n");

            var isGameOn = true;

            do
            {
                Console.Clear();
                Console.WriteLine(@$"What game would you like to play today? Choose from the options below: 
V - View Previous Games
A - Addition
S - Subtraction
M - Multiplication
D - Division
Q - Quit the program");
                Console.WriteLine("---");

                var gameSelected = Console.ReadLine();

                gameSelected = Helpers.ValidateGameSelected(gameSelected);

                switch (gameSelected.Trim().ToLower())
                {
                    case "v":
                        Helpers.PrintGames();
                        break;
                    case "a":
                        GameEngine.AdditionGame("Addition game");
                        break;
                    case "s":
                        GameEngine.SubtractionGame("Subtraction game");
                        break;
                    case "m":
                        GameEngine.MultiplicationGame("Multiplication game");
                        break;
                    case "d":
                        GameEngine.DivisionGame("Division game");
                        break;
                    case "q":
                        Console.WriteLine("Goodbye");
                        isGameOn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input, please selected word on the menu. Try again.\n");
                        Console.WriteLine("Type any key for the main menu");
                        Console.ReadLine();
                        break;
                }
            }
            while (isGameOn);

        }
    }
}