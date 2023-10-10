namespace MathGame.anplv
{
    internal class Menu
    {
        GameEngine gameEngine = new();
       
        internal void ShowMenu(string name, DateTime date)
        {
            Console.Clear();
            Console.WriteLine($"Hello {name.ToUpper()}. It's {date}.This is your math's game. That's great that you're working on improving yourself.\nPress any key to start the game");
            Console.ReadLine();

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
                          R - Random game
                          Q - Quit the program");
                Console.WriteLine("-------------------------------------------------");

                var gameSelected = Console.ReadLine();

                switch (gameSelected.Trim().ToUpper())
                {
                    case "V":
                        Helpers.PrintGames();
                        break;
                    case "A":
                        gameEngine.AdditionGame("Addiction game", Helpers.GetDate());
                        break;
                    case "S":
                        gameEngine.SubtractionGame("Subtraction game", Helpers.GetDate());
                        break;
                    case "M":
                        gameEngine.MultiplicationGame("Multiplication game", Helpers.GetDate());
                        break;
                    case "D":
                        gameEngine.DivisionGame("Division game", Helpers.GetDate());
                        break;
                    case "R":
                        gameEngine.RandomGame();
                        break;
                    case "Q":
                        Console.WriteLine("Goodbye");
                        isGameOn = false;
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
