namespace MathGame.CharlieDW
{
    internal class UserMenu
    {
        GameEngine gameEngine = new GameEngine();

        // Menu method:
        internal void ShowMenu(string name, DateTime date)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Hello {name}, It's {date.Date.ToString("MMM dd, yyyy")}. This is your math's game. \nIt's great that you are working on improving yourself\n");
            Console.WriteLine("\n");

            bool isGameOn = true;

            do
            {
                Console.WriteLine(@$"What game would you like to play today? Choose from the options below:
A - Addition
S - Substraction
M - Multiplication
D - Division 
V - Get previous scores
Q - Quit the program");
                Console.WriteLine("----------------------------------");

                string userChoice = Console.ReadLine().ToUpper().Trim();

                switch (userChoice)
                {
                    case "V":
                        Helpers.GetGames();
                        break;
                    case "A":
                        gameEngine.Add("Addition game");
                        break;
                    case "S":
                        gameEngine.Substract("Substraction game");
                        break;
                    case "M":
                        gameEngine.Multiply("Multiplication game");
                        break;
                    case "D":
                        gameEngine.Divide("Division game");
                        break;
                    case "Q":
                        gameEngine.ExitGame("Quitting game. BYEEEE");
                        isGameOn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }
            } while (isGameOn);
        }
    }
}
