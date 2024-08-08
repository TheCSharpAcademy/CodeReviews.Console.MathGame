namespace MathGame
{
    internal class Menu
    {

        internal void ShowMenu(string name, DateTime date)
        {

            GameHistory gameHistory = new GameHistory();
            GameEngine gameEngine = new GameEngine(gameHistory);

            string menuSelection = "";
            bool isGameAlive = true;

            Console.WriteLine($"Hello {name.ToUpper()}, its {date.DayOfWeek}");

            do
            {
                Console.WriteLine(@$"What game would you like to play today? Choose from the options below:
                            V - View Previous Games      
                            A - Addition
                            S - Subtraction
                            M - Multiplication
                            D - Division
                            Q - Quite program");

                Console.WriteLine("\t\t\t------------------------");

                string? readResult = Console.ReadLine();
                while (String.IsNullOrWhiteSpace(readResult))
                {
                    Console.WriteLine("Please make a selection");
                    readResult = Console.ReadLine();
                }
                menuSelection = readResult.ToLower().Trim();

                switch (menuSelection)
                {
                    case "v":
                        Console.WriteLine("View previous games");
                        gameHistory.PrintGames();
                        break;
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
                        Console.WriteLine("Quitting game");
                        isGameAlive = false;
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Quitting game.");
                        isGameAlive = false;
                        Console.Clear();
                        break;
                }
            } while (isGameAlive);
        }
    }
}