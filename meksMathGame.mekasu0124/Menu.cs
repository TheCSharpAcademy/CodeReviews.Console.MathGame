namespace MeksMathGameRewrite
{
    internal class Menu
    {
        GameEngine gameEngine = new();
        internal void ShowMenu(string name, DateTime date)
        {
            Console.Clear();
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Hello {name}. It's {date}.\nWelcome To Your Math Game.\n");
            Console.WriteLine("\n");
            Console.WriteLine("Press any key to show the main menu");
            Console.ReadLine();

            bool isGameOn = true;

            do
            {
                Console.Clear();
                Console.WriteLine(@$"
What game would you like to play today? Choose from the options below:
A - Addition
S - Subtraction
M - Multiplication
D - Division
Q - Quit Game
V - Previous Games");
                Console.WriteLine("---------------------------------");
                Console.Write("Your Selection: ");

                var gameSelected = Console.ReadLine();
                gameSelected = Helpers.GetGame(gameSelected);

                switch (gameSelected.Trim().ToLower())
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

                    case "q":
                        Console.WriteLine("Exiting Application");
                        isGameOn = false;
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

        string GetName()
        {
            Console.WriteLine("Enter Your Name");
            var name = Console.ReadLine();
            return name;
        }
    }
}
