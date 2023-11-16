namespace MathGame.nwdorian
{
    internal class Menu
    {
        GameEngine gameEngine = new GameEngine();
        internal void ShowMenu(string name, DateTime date)
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"Hello {name}! It's {date.DayOfWeek}. This is your Math Game!");
            Console.WriteLine("Press any key to show menu");
            Console.ReadKey();

            bool isGameOn = true;

            do
            {
                Console.Clear();
                Console.WriteLine(@$"Choose what game you would like to play from the options below:
V - View previous games
A - Addition
S - Subtraction
M - Multiplication
D - Division
Q - Quit the game");
                Console.WriteLine("-----------------------------------------");
                Console.Write("Enter selection: ");
                string? gameSelected = Console.ReadLine();

                switch (gameSelected.ToUpper().Trim())
                {
                    case "V":
                        Helpers.PrintGames();
                        break;
                    case "A":
                        gameEngine.AdditionGame("Addition game");
                        break;
                    case "S":
                        gameEngine.SubtractionGame("Subtraction game");
                        break;
                    case "M":
                        gameEngine.MultiplicationGame("Multiplication game");
                        break;
                    case "D":
                        gameEngine.DivisionGame("Division game");
                        break;
                    case "Q":
                        Console.WriteLine("Goodbye!");
                        isGameOn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }
            } while (isGameOn);
        }
    }
}
