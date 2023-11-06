namespace MathGame;

internal class Menu
{
    GameEngine GameEngine = new GameEngine();
    int limit = 3;
    string difficulty = "Medium";

    internal void ShowMenu(DateTime date)
    {
        Console.WriteLine("-------------------------------------------");
        Console.WriteLine($"Hello, it's {date.ToString("yyyy-MM-dd")}, {date.DayOfWeek}. This is your math's game. That's great that you're working on improving yourself.");
        Console.WriteLine("-------------------------------------------");

        while (1 == 1)
        {
            Console.Clear();
            Console.WriteLine($@"What game would you like to play today? Choose from the options below:
-------------------------------------------
V - View Previous Games
A - Addition
S - Substraction
M - Multiplication
D - Division
R - Random
-------------------------------------------
N - Change number of games, currently - {limit}
L - Change the difficulty - currently - {difficulty}
Q - Quit the program");
            Console.WriteLine("-------------------------------------------");

            string gameSelected = Console.ReadLine();

            switch (gameSelected.Trim().ToLower())
            {
                case "v":
                    Helpers.GetGames();
                    break;

                case "a":
                    GameEngine.AdditionGame("Addition game", limit, false, difficulty);
                    break;

                case "s":
                    GameEngine.SubtractionGame("Substraction game", limit, false, difficulty);
                    break;

                case "m":
                    GameEngine.MultiplicationGame("Multiplication game", limit, false, difficulty);
                    break;

                case "d":
                    GameEngine.DivisionGame("Division game", limit, false, difficulty);
                    break;

                case "r":
                    GameEngine.RandomGame("Random game", limit, difficulty);
                    break;

                case "n":
                    limit = Helpers.SetLimit();
                    Console.Clear();
                    ShowMenu(date);
                    break;

                case "l":
                    difficulty = Helpers.SetDifficulty();
                    break;

                case "q":
                    Console.WriteLine("Goodbye");
                    Environment.Exit(1);
                    break;

                default:
                    Console.WriteLine("Invalid input. Type any key to restart.");
                    Console.ReadKey();
                    Console.Clear();
                    ShowMenu(date);
                    break;
            }
        }

    }
}
