using MathGame.AlainNshimirimana.Models;

namespace MathGame.AlainNshimirimana
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
            //var gamesToPrint = games.Where(x => x.Date > new DateTime(2023, 05, 28)).OrderBy(x => x.Date);

            Console.Clear();
            Console.WriteLine("Games History");
            Console.WriteLine("------------------------");
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date} - {game.Type}: {game.Score}");
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
                Type = gameType
            });
        }

        internal static int[] GetDivisionNumbers()
        {
            var max = 1;

            switch (GetDifficulty().Trim().ToLower())
            {
                case "medium":
                    max = 999;
                    break;

                case "hard":
                    max = 9999;
                    break;

                default:
                    max = 99;
                    break;
            }
            var random = new Random();
            var firstNumber = random.Next(1, max);
            var secondNumber = random.Next(1, max);

            var result = new int[2];

            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(1, max);
                secondNumber = random.Next(1, max);
            }
            result[0] = firstNumber;
            result[1] = secondNumber;

            return result;
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

        internal static string GetDifficulty()
        {
            bool isValidInput = false;

            do
            {
                Console.Clear();
                Console.WriteLine($@"Please Choose difficulty level below:
         E - Easy 
         M - Medium
         H - Hard");
                Console.WriteLine("-----------------------------");

                var difficultySelected = Console.ReadLine();

                switch (difficultySelected.Trim().ToLower())
                {
                    case "e":
                        isValidInput = true;
                        return "easy";
                    case "m":
                        isValidInput = true;
                        return "medium";
                    case "h":
                        isValidInput = true;
                        return "hard";
                    default:
                        return "Invalid Input";
                }
            } while (isValidInput != false);
        }
    }
}
