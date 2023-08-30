using Math_Game.Models;

namespace Math_Game
{
    internal class Helpers
    {
        internal static void AddToHistory(int gameScore, GameType gameType)
        {
            games.Add(new Game
            {
                Date = DateTime.Now,
                Score = gameScore,
                Type = gameType
            });
        }

        internal static List<Game> games = new();
        internal static void PrintGames()
        {
            // var gamesToPrint = games.Where(x => x.Type == GameType.Division);

            Console.Clear();
            Console.WriteLine("Games History");
            Console.WriteLine("--------------------");
            foreach (var game in games)
            {

                Console.WriteLine($"{game.Date} - {game.Type}: {game.Score} points");
            }
            Console.WriteLine("--------------------\n");
            Console.WriteLine("Press any key to return to main menu");
            Console.ReadLine();
        }
        internal static int[] GetDivisionNumbers()
        {
            var random = new Random();
            var firstNumber = random.Next(1, 99);
            var secondNumber = random.Next(1, 99);
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

        internal static string? ValidateResult(string result)
        {
            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
            {
                Console.WriteLine("Your answer need to be an integer. Type any key for the next question");
                result = Console.ReadLine();
            }
            return result;
        }

        internal static string GetName()
        {
            Console.WriteLine("Please enter your name");

            var name = Console.ReadLine();

            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name can't be empty. Please enter your name");
                name = Console.ReadLine();
            }

            return name;
        }
    }
}
