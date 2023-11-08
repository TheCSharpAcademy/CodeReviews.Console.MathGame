using MathGame.Models;
using System.Linq;

namespace MathGame {
    internal static class Helpers {

        internal static List<Game> games = new() {
            new Game { Date = DateTime.Now.AddDays(1), Type = GameType.Addition, Score = 5 },
            new Game { Date = DateTime.Now.AddDays(2), Type = GameType.Multiplication, Score = 4 },
            new Game { Date = DateTime.Now.AddDays(3), Type = GameType.Division, Score = 4 },
            new Game { Date = DateTime.Now.AddDays(4), Type = GameType.Subtraction, Score = 3 },
            new Game { Date = DateTime.Now.AddDays(5), Type = GameType.Addition, Score = 1 },
            new Game { Date = DateTime.Now.AddDays(6), Type = GameType.Multiplication, Score = 2 },
            new Game { Date = DateTime.Now.AddDays(7), Type = GameType.Division, Score = 3 },
            new Game { Date = DateTime.Now.AddDays(8), Type = GameType.Subtraction, Score = 4 },
            new Game { Date = DateTime.Now.AddDays(9), Type = GameType.Addition, Score = 4 },
            new Game { Date = DateTime.Now.AddDays(10), Type = GameType.Multiplication, Score = 1 },
            new Game { Date = DateTime.Now.AddDays(11), Type = GameType.Subtraction, Score = 0 },
            new Game { Date = DateTime.Now.AddDays(12), Type = GameType.Division, Score = 2 },
            new Game { Date = DateTime.Now.AddDays(13), Type = GameType.Subtraction, Score = 5 },
        };

        internal static void PrintGames() {
            // IEnumerable<Game> gamesToPrint = games.Where(x => x.Type == GameType.Division);
            // IEnumerable<Game> gamesToPrint = games.Where(x => x.Date > new DateTime(2023, 11, 07));
            // IEnumerable<Game> gamesToPrint = games.Where(x => x.Date > new DateTime(2022, 08, 09) && x.Score > 3);
            // IEnumerable<Game> gamesToPrint = games.Where(x => x.Date > new DateTime(2023, 11, 07)).OrderByDescending(x => x.Score);

            Console.Clear();
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Games history:");
            Console.WriteLine("\n");

            foreach (Game game in games) {
                Console.WriteLine($"{game.Date} - {game.Type}: {game.Score}");
            }

            Console.WriteLine("----------------------------------\n");
            Console.WriteLine("Press any key to go back to main menu:");
            Console.ReadLine();
        }

        internal static int GenerateRandomNumber(int min, int limit) {
            Random random = new Random();
            int randomNumber = random.Next(min, limit);

            return randomNumber;
        }

        internal static int[] GetDivisionNumbers() {
            int firstNumber = GenerateRandomNumber(1, 99);
            int secondNumber = GenerateRandomNumber(1, 99);

            int[] result = new int[2];

            while (firstNumber % secondNumber != 0) {
                firstNumber = GenerateRandomNumber(1, 99);
                secondNumber = GenerateRandomNumber(1, 99);
            }

            result[0] = firstNumber;
            result[1] = secondNumber;

            return result;
        }



        internal static void AddToHistory(int gameScore, GameType gameType) {
            games.Add(new Game 
            {
                Date = DateTime.Now,
                Score = gameScore,
                Type = gameType
            });
        }
    }
}
