using MathGame.CharlieDW.Models;

namespace MathGame.CharlieDW
{
    internal static class Helpers
    {
        internal static List<Game> Games = new()
        {
            /*
            new Game {Date = DateTime.Now.AddDays(1), Type = GameType.Addition, Score = 5 },
            new Game {Date = DateTime.Now.AddDays(2), Type = GameType.Multiplication, Score = 3 },
            new Game {Date = DateTime.Now.AddDays(3), Type = GameType.Division, Score = 6 },
            new Game {Date = DateTime.Now.AddDays(4), Type = GameType.Substraction, Score = 8 },
            new Game {Date = DateTime.Now.AddDays(5), Type = GameType.Addition, Score = 3 },
            new Game {Date = DateTime.Now.AddDays(6), Type = GameType.Multiplication, Score = 5 },
            new Game {Date = DateTime.Now.AddDays(7), Type = GameType.Division, Score = 12 },
            new Game {Date = DateTime.Now.AddDays(8), Type = GameType.Substraction, Score = 9 },
            new Game {Date = DateTime.Now.AddDays(9), Type = GameType.Addition, Score = 2 },
            new Game {Date = DateTime.Now.AddDays(10), Type = GameType.Multiplication, Score = 16 },
            */
        };
        internal static void GetGames()
        {
            // var gamesToPrint = games.Where(x => x.Type == GameType.Addition).OrderByDescending(x => x.Score);
            
            Console.Clear();
            Console.WriteLine("***** GAMES HISTORY *****\n");

            foreach (Game game in Games)
            {
                Console.WriteLine($"{game.Date} - {game.Type} - {game.Score}pts.");
            }

            Console.WriteLine("*******************\n");
            Console.WriteLine("Press any key to return to the main menu.");
        }

        internal static void AddToHistory(int score, GameType gameType)
        {
            Games.Add(new Game
            {
                Date = DateTime.Now,
                Score = score,
                Type = gameType
            });
        }

        internal static int[] GetDivisionNumbers()
        {
            var random = new Random();
            int firstNumber = random.Next(0, 99);
            int secondNumber = random.Next(0, 99);

            var result = new int[2];

            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(1, 99);
                secondNumber = random.Next(1, 99);
            }

            result[0] = firstNumber;
            result[1] = secondNumber;

            return result;
        }

        public static string? ValidateResult(string? result)
        {
            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _)) 
            {
                Console.WriteLine("Please provide a numeric input.");
                result = Console.ReadLine();
            }

            return result;
        }
        
        internal static string GetName()
        {
            string name = "";

            while (name == "")
            {
                Console.WriteLine("Please write your name:");
                name = Console.ReadLine();
            }
    
            return name;
        }
    }
}
