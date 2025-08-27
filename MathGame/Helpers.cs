using MathGame.Models;

namespace MathGame
{
    internal class Helpers
    {
        internal static List<Game> games = new List<Game>
        {
            //    new Game { Date = DateTime.Now.AddDays(1), Type = GameType.Addition, Score = 5 },
            //    new Game { Date = DateTime.Now.AddDays(2), Type = GameType.Multiplication, Score = 4 },
            //    new Game { Date = DateTime.Now.AddDays(3), Type = GameType.Division, Score = 4 },
            //    new Game { Date = DateTime.Now.AddDays(4), Type = GameType.Subtraction, Score = 3 },
            //    new Game { Date = DateTime.Now.AddDays(5), Type = GameType.Addition, Score = 1 },
            //    new Game { Date = DateTime.Now.AddDays(6), Type = GameType.Multiplication, Score = 2 },
            //    new Game { Date = DateTime.Now.AddDays(7), Type = GameType.Division, Score = 3 },
            //    new Game { Date = DateTime.Now.AddDays(8), Type = GameType.Subtraction, Score = 4 },
            //    new Game { Date = DateTime.Now.AddDays(9), Type = GameType.Addition, Score = 4 },
            //    new Game { Date = DateTime.Now.AddDays(10), Type = GameType.Multiplication, Score = 1 },
            //    new Game { Date = DateTime.Now.AddDays(11), Type = GameType.Subtraction, Score = 0 },
            //    new Game { Date = DateTime.Now.AddDays(12), Type = GameType.Division, Score = 2 },
            //    new Game { Date = DateTime.Now.AddDays(13), Type = GameType.Subtraction, Score = 5 },

        };
        internal static int[] GetDivisionNumbers(Difficulty difficulty)
        {
            var random = new Random();
            var firstNumber = 0;
            var secondNumber = 0;

            Helpers.CheckDifficulty(difficulty, random, ref firstNumber, ref secondNumber);

            var results = new int[2];

            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(1, 99);
                secondNumber = random.Next(1, 99);
            }
            results[0] = firstNumber;
            results[1] = secondNumber;

            return results;
        }
        internal static void PrintGames()
        {
            Console.Clear();
            Console.WriteLine("Games History");
            Console.WriteLine("------------------------------------------");
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date} | {game.Type} : {game.Score}pts");
            }
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Press any key to return to main menu");
            Console.ReadLine();
        }
        internal static void AddToHistory(GameType gameType, int gameScore, Difficulty difficulty)
        {
            games.Add(new Game
            {
                Date = DateTime.UtcNow,
                Score = gameScore,
                Type = gameType,
                difficultyType = difficulty
            });
        }

        internal static string ValidateResult(string result)
        {
            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
            {
                Console.WriteLine("your answer needs to be an integer.Try again!");
                result = Console.ReadLine();
            }
            return result;
        }

        internal static string GetName()
        {
            Console.Write("Enter your name : ");
            var name = Console.ReadLine();

            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name can't be empty");
                name = Console.ReadLine();
            }
            return name;

        }
        internal static Difficulty ChooseDifficulty()
        {
            Difficulty difficulty = new Difficulty();
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Choose your difficulty :");
            Console.WriteLine(@"        E - Easy 
        M - Medium 
        H - Hard");
            Console.WriteLine("-----------------------------------------");
            var chosenDifficulty = Console.ReadLine();
            switch (chosenDifficulty.Trim().ToLower())
            {
                case "e":
                    difficulty = Difficulty.Easy;
                    return difficulty;
                case "m":
                    difficulty = Difficulty.Medium;
                    return difficulty;
                case "h":
                    difficulty = Difficulty.Hard;
                    return difficulty;
                default:
                    difficulty = Difficulty.Medium;
                    break;
            }
            return difficulty;
        }
        internal static void CheckDifficulty(Difficulty difficulty, Random random, ref int firstNumber, ref int secondNumber)
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    firstNumber = random.Next(1, 9);
                    secondNumber = random.Next(1, 9);
                    break;
                case Difficulty.Medium:
                    firstNumber = random.Next(11, 99);
                    secondNumber = random.Next(11, 99);
                    break;
                case Difficulty.Hard:
                    firstNumber = random.Next(11, 99);
                    secondNumber = random.Next(100, 1000);
                    break;
            }
        }
    }
}
