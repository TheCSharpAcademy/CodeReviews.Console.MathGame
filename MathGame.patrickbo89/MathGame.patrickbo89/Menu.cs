namespace MathGame.patrickbo89;

internal class Menu
{
    private readonly GameEngine _gameEngine = new();

    internal void DisplayMenu(string name, DateTime date)
    {
        bool isGameRunning = true;

        Console.Clear();
        Console.WriteLine($"Hello, {name}. It's {date}. Welcome to the Math Game. Be ready to be challenged!");
        Console.WriteLine("\nPress any key to show the menu.");
        Console.ReadKey();

        do
        {
            Console.Clear();
            Helpers.DrawLine();
            Console.WriteLine($@"What type of game would you like to play this time? Choose an option:

V - View Game History
A - Addition
S - Subtraction
M - Multiplication
D - Division
R - Random
Q - Quit");

            Helpers.DrawLine();

            var selectedOption = Console.ReadLine();

            switch (selectedOption?.Trim().ToLower())
            {
                case "v":
                    Helpers.DisplayHistory();
                    break;
                case "a":
                    Game game = CreateGame(GameType.Addition);
                    _gameEngine.StartGame(game);
                    break;
                case "s":
                    game = CreateGame(GameType.Subtraction);
                    _gameEngine.StartGame(game);
                    break;
                case "m":
                    game = CreateGame(GameType.Multiplication);
                    _gameEngine.StartGame(game);
                    break;
                case "d":
                    game = CreateGame(GameType.Division);
                    _gameEngine.StartGame(game);
                    break;
                case "r":
                    game = CreateGame(GameType.Random);
                    _gameEngine.StartGame(game);
                    break;
                case "q":
                    Console.WriteLine("\nHope you had fun playing the game. Bye!");
                    Console.ReadKey();

                    isGameRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice...");
                    Console.WriteLine("Press any key to go back to the main menu.");
                    Console.ReadKey();
                    break;
            }
        } while (isGameRunning);
    }

    private Game CreateGame(GameType gameType)
    {
        int numberOfQuestions = Helpers.GetNumberOfQuestions(gameType);
        Helpers.DrawLine();

        Difficulty difficulty = Helpers.GetDifficulty(gameType);
        Helpers.DrawLine();

        return _gameEngine.SetupGame(gameType, numberOfQuestions, difficulty);
    }
}