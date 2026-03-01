using Game.Models;

namespace Game
{
    internal class Helpers
    {
        internal static List<GameList> games = [];

        internal static int[] GetDivisionNumbers()
        {
            var random = new Random();
            var firstNumber = random.Next(1, 100);
            var secondNumber = random.Next(1, 100);

            var result = new int[2];

            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(1, 100);
                secondNumber = random.Next(1, 100);
            }

            result[0] = firstNumber;
            result[1] = secondNumber;

            return result;
        }

        internal static void PrintGames()
        {
            Console.Clear();
            Console.WriteLine("Games History");
            Console.WriteLine("---");
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date} - {game.Type}: {game.Score} pts");
            }
            Console.WriteLine("---\n");
            Console.WriteLine("Press any key to return to main menu");
            Console.ReadLine();
        }

        internal static void AddToHistory(int gameScore, GameType gameType)
        {
            games.Add(new GameList
            {
                Date = DateTime.Now,
                Score = gameScore,
                Type = gameType
            });
        }

        internal static string ValidateResult(string? result)
        {
            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
            {
                Console.WriteLine("Your answer needs to be an integer. Try again.");
                result = Console.ReadLine();
            }
            return result!;
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

        internal static string ValidateGameSelected(string? result)
        {
            while (string.IsNullOrEmpty(result))
            {
                Console.WriteLine("Invalid input. Try again.");
                result = Console.ReadLine();
            }
            return result!;
        }
    }
}