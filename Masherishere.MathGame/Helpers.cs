namespace Masherishere.MathGame
{
    internal class Helpers
    {
        static List<Game> games = new();
        internal static void PrintGames()
        {
            Console.Clear();
            Console.WriteLine("Games History");
            Console.WriteLine("-------------------");
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date} - {game.Type}: {game.Score} pts");
            }
            Console.WriteLine("-------------------");
            Console.WriteLine("Press any key to return to Main Menu");
            Console.ReadLine();
        }

        internal static void AddToHistory(int gameScore, GameType gameType)
        {
            var gameItem = new Game
            (
                Date: DateTime.Now,
                Score: gameScore,
                Type: gameType
            );
            games.Add(gameItem);
        }

        internal static int[] GetDivisionNumbers()
        {
            var random = new Random();

            var result = GetRandomNumbers();

            while (result[0] % result[1] != 0)
            {
                result[0] = random.Next(1, 9);
                result[1] = random.Next(1, 9);
            }

            return result;
        }

        internal static string? ValidateResult(string result)
        {
            while(string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
            {
                Console.WriteLine("Your Input should be an integer");
                result = Console.ReadLine();
            }

            return result;
        }

        internal static int[] GetRandomNumbers()
        {
            var random = new Random();
            var firstNumber = random.Next(1, 9);
            var secondNumber = random.Next(1, 9);

            var result = new int[2];

            result[0] = firstNumber;
            result[1] = secondNumber;

            return result;
        }
    }
}
