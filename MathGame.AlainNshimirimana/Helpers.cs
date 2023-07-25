using MathGame.AlainNshimirimana.Models;

namespace MathGame.AlainNshimirimana
{
    internal class Helpers
    {
        private static int _difficultyLevel;
        public static int DifficultyLevel { get { return _difficultyLevel; } }
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
            //var gamesToPrint = games.Where(x => x.Date > new DateTime(2023, 05, 28)).OrderBy(x => x.Date);

            Console.Clear();
            Console.WriteLine("Games History");
            Console.WriteLine("------------------------");
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date} - {game.Type} - {game.Level}: {game.Score}");
            }
            Console.WriteLine("------------------------\n");
            Console.WriteLine("Press any key to return to the Main Menu");
            Console.ReadLine();
        }

        internal static void AddToHistory(int gameScore, GameType gameType)
        {
            games.Add(new Game
            {
                Date = DateTime.Now,
                Score = gameScore,
                Type = gameType,
                Level = (Difficulty)DifficultyLevel
            });
        }

        internal static (int, int) GetDivisionNumbers()
        {
            var (firstNumber, secondNumber) = GameNumbers(99, 999, 9999);

            while (firstNumber % secondNumber != 0)
            {
                (firstNumber, secondNumber) = GameNumbers(99, 999, 9999);
            }

            return (firstNumber, secondNumber);
        }

        internal static string? ValidateResult(string result)
        {
            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
            {
                Console.WriteLine("Your answer needs to be an integer. Try again.");
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

        internal static void GetDifficulty()
        {
                Console.Clear();
                Console.WriteLine($@"Please Choose difficulty level below:
         1 - Easy 
         2 - Medium
         3 - Hard");
                Console.WriteLine("-----------------------------");

                var difficultySelected = Console.ReadLine();

                var difficultyCheck = DifficultyValidate(difficultySelected);
                _difficultyLevel = Int32.Parse(difficultyCheck);
        }
        internal static string DifficultyValidate(string result)
        {
                while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _) || Int32.Parse(result) > 3)
                {
                    Console.WriteLine("Pick 1,2 or 3. Try again");
                    result = Console.ReadLine();
                }

                return result;
        }

        internal static (int, int) GameNumbers(
            int easy = 9,
            int medium = 99,
            int hard = 999)
        {
            int firstNumber = 0;
            int secondNumber = 0;

            var random = new Random();

            switch (Helpers.DifficultyLevel)
            {
                case 1:
                    firstNumber = random.Next(1, easy);
                    secondNumber = random.Next(1, easy);
                    break;
                case 2:
                    firstNumber = random.Next(1, medium);
                    secondNumber = random.Next(1, medium);
                    break;
                case 3:
                    firstNumber = random.Next(1, hard);
                    secondNumber = random.Next(1, hard);
                    break;
                default:
                    break;
            }

            return (firstNumber, secondNumber);
        }
    }
}
