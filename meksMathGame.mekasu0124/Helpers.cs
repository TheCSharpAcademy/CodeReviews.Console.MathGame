using MeksMathGameRewrite.Models;
using System.Linq;

namespace MeksMathGameRewrite
{
    internal class Helpers
    {
        internal static List<Game> games = new List<Game>();

        internal static int[] GetDivisionNumbers()
        {
            var random = new Random();
            var num1 = random.Next(1, 99);
            var num2 = random.Next(1, 99);

            var result = new int[2];

            while (num1 % num2 != 0)
            {
                num1 = random.Next(1, 99);
                num2 = random.Next(1, 99);
            }

            result[0] = num1;
            result[1] = num2;

            return result;
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
        internal static void PrintGames()
        {
            // var gamesToPrint = games.Where(x => x.Date > new DateTime(2022,08,09)).OrderByDescending(x => x.Score);

            Console.Clear();
            Console.WriteLine("Games History");
            Console.WriteLine("-------------");

            // foreach (var game in gamesToPrint)
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date} - {game.Type}: {game.Score}pts");
            }
            Console.WriteLine("---------------------------");
            Console.WriteLine("Press Any Key To Go Back To The Main Menu");
            Console.ReadLine();
        }

        internal static string? ValidateResult(string result)
        {
            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
            {
                Console.WriteLine("Your answer needs to be an integer. Try Again.");
                result = Console.ReadLine();
            }

            return result;
        }
        internal static string GetName()
        {
            Console.WriteLine("Please Enter Your Name:");

            var name = Console.ReadLine();

            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name can't be empty. Try Again");
                name = Console.ReadLine();
            }
            return name;
        }
        internal static string? GetGame(string gameSelected)
        {
            while (string.IsNullOrEmpty(gameSelected))
            {
                Console.WriteLine("Game type can't be empty. Try Again");
                gameSelected = Console.ReadLine();
            }
            return gameSelected;
        }
    }
}
