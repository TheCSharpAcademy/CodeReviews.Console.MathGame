namespace MathGame.K_MYR
{
    internal class Menu
    {
        GameEngine engine = new();

        internal void ShowMenu(string name, DateTime date)
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"Hello {name.ToUpper()}. It's {date}. This is your math's game. That's great that you're working on imporving yourself\n");
            Console.WriteLine("Press enter to show menu");
            Console.ReadLine();
            bool isGameOn = true;

            do
            {
                Console.Clear();
                Console.WriteLine($@"What   game would you like to play today? Choose from the options below?:\n
                        V - View Previous Games
                        A-Addition
                        S- Subtraction
                        M-Multiplication
                        D-Division
                        Q-Quit the program");
                Console.WriteLine("-------------------------------------");

                var gameSelected = Console.ReadLine();

                switch (gameSelected.Trim().ToLower())
                {
                    case "v":
                        Helpers.PrintGames();
                        break;
                    case "a":
                        engine.AdditionGame();
                        break;
                    case "s":
                        engine.SubtractionGame();
                        break;
                    case "m":
                        engine.MultiplicationGame();
                        break;
                    case "d":
                        engine.DivisionGame();
                        break;
                    case "q":
                        Console.WriteLine("Goodbye!");
                        isGameOn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            } while (isGameOn);
        }
    }
}
