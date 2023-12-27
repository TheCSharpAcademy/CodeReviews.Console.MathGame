using MathGame.stevietv.Models;

namespace MathGame.stevietv
{
    internal class Helpers
    {
        internal static List<Game> games = new List<Game>
        {
            //new Game { Date = DateTime.Now.AddDays(1), Type = GameType.Addition, Score = 5 },
            //new Game { Date = DateTime.Now.AddDays(2), Type = GameType.Multiplication, Score = 4 },
            //new Game { Date = DateTime.Now.AddDays(3), Type = GameType.Division, Score = 4 },
            //new Game { Date = DateTime.Now.AddDays(4), Type = GameType.Subtraction, Score = 3 },
            //new Game { Date = DateTime.Now.AddDays(5), Type = GameType.Addition, Score = 1 },
            //new Game { Date = DateTime.Now.AddDays(6), Type = GameType.Multiplication, Score = 2 },
            //new Game { Date = DateTime.Now.AddDays(7), Type = GameType.Division, Score = 3 },
            //new Game { Date = DateTime.Now.AddDays(8), Type = GameType.Subtraction, Score = 4 },
            //new Game { Date = DateTime.Now.AddDays(9), Type = GameType.Addition, Score = 4 },
            //new Game { Date = DateTime.Now.AddDays(10), Type = GameType.Multiplication, Score = 1 },
            //new Game { Date = DateTime.Now.AddDays(11), Type = GameType.Subtraction, Score = 0 },
            //new Game { Date = DateTime.Now.AddDays(12), Type = GameType.Division, Score = 2 },
            //new Game { Date = DateTime.Now.AddDays(13), Type = GameType.Subtraction, Score = 5 },
        };

        internal static void PrintGames()
        {

            //var gamesToPrint = games.Where(x => x.Date > new DateTime(2024, 01, 01)).OrderByDescending(x => x.Score);

            Console.Clear();
            Console.WriteLine("Games History");
            Console.WriteLine("---------------------------------------");
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date} - {game.Type} ({game.Difficulty}): {game.Score} pts");
            }
            Console.WriteLine("---------------------------------------\n");
            Console.WriteLine("Press any key to return to the menu");
            Console.ReadLine();
        }

        internal static void AddToHistory(int gameScore, GameType gameType, Difficulty difficulty)
        {
            games.Add(new Game
            {
                Date = DateTime.Now,
                Score = gameScore,
                Type = gameType,
                Difficulty = difficulty,
            });
        }

        internal static int[] GetDivisionNumbers(Difficulty difficulty)
        {
            var random = new Random();
            var firstNumber = 1;
            var secondNumber = 2;

            while (firstNumber % secondNumber != 0)
            {
                switch (difficulty)
                {
                    case Difficulty.Easy:
                        firstNumber = random.Next(1, 99);
                        secondNumber = random.Next(1, 99);
                        break;
                    case Difficulty.Medium:
                        firstNumber = random.Next(1, 499);
                        secondNumber = random.Next(1, 499);
                        break;
                    case Difficulty.Hard:
                        firstNumber = random.Next(1, 999);
                        secondNumber = random.Next(1, 999);
                        break;
                    default:
                        firstNumber = random.Next(1, 99);
                        secondNumber = random.Next(1, 99);
                        break;
                }
            }

            var result = new int[2];

            result[0] = firstNumber;
            result[1] = secondNumber;

            return result;
        }

        internal static string? ValidateResult(string result)
        {
            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
            {
                Console.WriteLine("Your answer needs to be an integer. Try Again");
                result = Console.ReadLine();
            }
            return result;
        }

        internal static string GetName()
        {
            Console.WriteLine("Please type your name");
            var name = Console.ReadLine();

            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name can't be empty");
                name = Console.ReadLine();
            }

            return name;
        }

        internal static int GetNumber(Difficulty difficulty)
        {
            var random = new Random();
            switch (difficulty)
            {
                case Difficulty.Easy:
                    return random.Next(1, 9);
                case Difficulty.Medium:
                    return random.Next(1, 49);
                case Difficulty.Hard:
                    return random.Next(1, 99);
                default:
                    return random.Next(1, 9);
            }
        }

        internal static Difficulty GetDifficulty()
        {
            Console.WriteLine("Please choose your difficulty (Easy, Medium, Hard):");
            bool isValidDifficulty = false;
            var difficultyChosen = Console.ReadLine();
            Difficulty difficulty = Difficulty.Easy; ;

            do
            {
                switch (difficultyChosen.Trim().ToLower())
                {
                    case "easy":
                        difficulty = Difficulty.Easy;
                        isValidDifficulty = true;
                        break;
                    case "medium":
                        difficulty = Difficulty.Medium;
                        isValidDifficulty = true;
                        break;
                    case "hard":
                        difficulty = Difficulty.Hard;
                        isValidDifficulty = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Difficulty, please choose again");
                        difficultyChosen = Console.ReadLine();
                        break;
                }
            } while (!isValidDifficulty);

            return difficulty;
        }
    }
}