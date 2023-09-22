using MyFirstProgram.Models;

namespace MyFirstProgram
{
    internal class Helpers
    {
        internal static List<Game> games = new();
        internal static GameDifficulty difficulty = new();

        internal static int[] GetDivisionNumbers()
        {
            var random = new Random();
            int firstNumber = random.Next(1, GetNumberUpperBound(difficulty));
            int secondNumber = random.Next(1, GetNumberUpperBound(difficulty));

            var result = new int[2];

            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(1, GetNumberUpperBound(difficulty));
                secondNumber = random.Next(1, GetNumberUpperBound(difficulty));
            }

            result[0] = firstNumber;
            result[1] = secondNumber;

            return result;
        }

        internal static void AddToHistory(int gameScore, GameType gameType)
        {
            games.Add(new Game
            {
                Date = DateTime.Now,
                Score = gameScore,
                Type = gameType,
                Difficulty = difficulty
            });
        }

        internal static void PrintGames()
        {
            Console.Clear();
            Console.WriteLine("Games History");
            Console.WriteLine("-----------------------------------------");
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date} - {game.Type} ({game.Difficulty}) : {game.Score}pts");
            }
            Console.WriteLine("-----------------------------------------\n");
            Console.WriteLine("Press any key to go back to the main menu.");
            Console.ReadLine();
        }

        internal static string? ValidateResult(string result)
        {

            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
            {
                Console.WriteLine("Your answer needs to be an integer. Try again");
                result = Console.ReadLine();
            }

            return result;
        }

        internal static string GetName()
        {
            Console.WriteLine("Please type your name:");
            var name = Console.ReadLine();

            while(string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name can't be empty.");
                name = Console.ReadLine();
            }
            return name;
        }

        internal static void SetGameDifficulty() 
            {
            Console.Clear();
            Console.WriteLine(@$"
To set the difficulty, chose from the options below:
E - Easy
M - Moderate
H - Hard");

                    string difficultySelected = Console.ReadLine();

                    switch (difficultySelected.Trim().ToLower())
                    {
                        case "e":
                            difficulty = GameDifficulty.Easy;
                            break;

                        case "m":
                            difficulty = GameDifficulty.Moderate;
                            break;

                        case "h":
                            difficulty = GameDifficulty.Hard;
                            break;

                        default:
                            SetGameDifficulty();
                            break;
                    }

            Console.WriteLine($"Difficulty set to {difficulty}. Press any key to go back to the main menu.");
            Console.ReadLine();
        }

        internal static Int32 GetNumberUpperBound(GameDifficulty gameDifficulty)
        {
            Int32 result = 0;

            switch (gameDifficulty)
            {
                case GameDifficulty.Easy:
                    result = 9; 
                    break;

                case GameDifficulty.Moderate:
                    result = 99;
                    break;

                case GameDifficulty.Hard:
                    result = 999;
                    break;

             default:
                result = 9;
                break;

            }

            return result;
        }
    }
}
