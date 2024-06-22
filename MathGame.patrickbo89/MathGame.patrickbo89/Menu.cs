namespace MathGame.patrickbo89;

internal class Menu
{
    internal void Show(string name, DateTime date)
    {
        GameEngine _gameEngine = new();

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
                    int numberOfQuestions = Helpers.GetNumberOfQuestions(GameType.Addition);
                    Helpers.DrawLine();

                    Difficulty difficulty = Helpers.GetDifficulty(GameType.Addition);
                    Helpers.DrawLine();

                    _gameEngine.StartGame(GameType.Addition, numberOfQuestions, difficulty);
                    break;
                case "s":
                    numberOfQuestions = Helpers.GetNumberOfQuestions(GameType.Subtraction);
                    Helpers.DrawLine();

                    difficulty = Helpers.GetDifficulty(GameType.Subtraction);
                    Helpers.DrawLine();

                    _gameEngine.StartGame(GameType.Subtraction, numberOfQuestions, difficulty);
                    break;
                case "m":
                    numberOfQuestions = Helpers.GetNumberOfQuestions(GameType.Multiplication);
                    Helpers.DrawLine();

                    difficulty = Helpers.GetDifficulty(GameType.Multiplication);
                    Helpers.DrawLine();

                    _gameEngine.StartGame(GameType.Multiplication, numberOfQuestions, difficulty);
                    break;
                case "d":
                    numberOfQuestions = Helpers.GetNumberOfQuestions(GameType.Division);
                    Helpers.DrawLine();

                    difficulty = Helpers.GetDifficulty(GameType.Division);
                    Helpers.DrawLine();

                    _gameEngine.StartGame(GameType.Division, numberOfQuestions, difficulty);
                    break;
                case "r":
                    numberOfQuestions = Helpers.GetNumberOfQuestions(GameType.Random);
                    Helpers.DrawLine();

                    difficulty = Helpers.GetDifficulty(GameType.Random);
                    Helpers.DrawLine();

                    _gameEngine.StartGame(GameType.Random, numberOfQuestions, difficulty);
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
}