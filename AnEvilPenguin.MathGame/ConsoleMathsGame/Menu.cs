using ConsoleMathsGame.Models;

namespace ConsoleMathsGame
{ 
    internal class Menu
    {
        const string lineBreaker = "--------------------------------------------------------";

        const string optionsMenu = @"What game would you like to play today? Choose from the options below:
V - View Previous Games
A - Addition
S - Subtraction
M - Multiplication
D - Division
Q - Quit the program";

        const string difficultyMenu = @"What difficulty would you like to play on today? Choose from the options below:
B - Beginner
I - Intermediate
M - Master
";

        GameEngine engine = new();

        internal Menu (){}
        internal void ShowMainMenu(string name, DateTime date)
        {
            Console.WriteLine(lineBreaker);
            Console.WriteLine($"Hello {name}. It's {date.DayOfWeek}. This is your maths game. It's great that you're working on improving yourself!\n");

            var difficulty = GetDifficulty();

            var isGameOn = true;

            do
            {
                Console.WriteLine(optionsMenu);
                Console.WriteLine(lineBreaker);

                string? gameSelected = Console.ReadLine()
                                              .Trim()
                                              .ToLower();

                switch (gameSelected)
                {
                    case "v":
                        Helpers.PrintGames();
                        break;

                    case "a":
                        engine.AdditionGame("Addition game selected", difficulty);
                        break;

                    case "s":
                        engine.SubtractionGame("Subtraction game selected", difficulty);
                        break;

                    case "m":
                        engine.MultiplicationGame("Multiplication game selected", difficulty);
                        break;

                    case "d":
                        engine.DivisionGame("Division game selected", difficulty);
                        break;

                    case "q":
                        Console.WriteLine("Goodbye!");
                        isGameOn = false;
                        break;

                    default:
                        Console.WriteLine("Invalid Input\n");
                        break;
                }
            } while (isGameOn);
        }

        internal GameDifficulty GetDifficulty()
        {
            Console.WriteLine();

            GameDifficulty? difficulty = null;

            do
            {
                Console.WriteLine(difficultyMenu);
                Console.WriteLine(lineBreaker);

                string? difficultySelected = Console.ReadLine()
                              .Trim()
                              .ToLower();

                switch (difficultySelected)
                {
                    case "b":
                        difficulty = GameDifficulty.Beginner;
                        break;

                    case "i":
                        difficulty = GameDifficulty.Intermediate;
                        break;

                    case "m":
                        difficulty = GameDifficulty.Master;
                        break;

                    default:
                        Console.WriteLine("Invalid Input\n");
                        break;
                }

            } while (difficulty == null);

            return (GameDifficulty)difficulty;
        }
    }
}
