namespace MyFirstProgram
{
    internal class Menu
    {

        GameEngine gameEngine = new GameEngine();

        internal void ShowMenu(string name, DateTime date)
        {
            Console.WriteLine("---------------------------------------");

            var welcomeMessage = string.Format("Hello {0}. It's {1}. This is your math game. It's great that you're working on improving yourself.\n", name, date.DayOfWeek);

            Console.WriteLine(welcomeMessage);

            Console.WriteLine("Enter any key to show menu.");
            Console.ReadLine();

            bool gameOn = true;

            do
            {
                Console.Clear();

                Console.WriteLine(@$"What game would you like to play today? Choose from the options below:
        
                V - Get game history
                A - Addition
                S - Subtraction
                M - Multiplication
                D - Division
                R - Random
                Q - Quit the program
                ");

                var userChoice = Console.ReadLine().ToLower().Trim();

                switch (userChoice)
                {
                    case "v":
                        Helpers.GetGames();
                        break;
                    case "a":
                        gameEngine.AdditionGame(Helpers.GetDifficulty());
                        break;
                    case "s":
                        gameEngine.SubtractionGame(Helpers.GetDifficulty());
                        break;
                    case "m":
                        gameEngine.MultiplicationGame(Helpers.GetDifficulty());
                        break;
                    case "d":
                        gameEngine.DivisionGame(Helpers.GetDifficulty());
                        break;
                    case "r":
                        gameEngine.RandomGame(Helpers.GetDifficulty());
                        break;
                    case "q":
                        gameOn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input.");
                        break;

                }

            } while (gameOn);

            Console.WriteLine("Goodbye.");

        }

    }
}
