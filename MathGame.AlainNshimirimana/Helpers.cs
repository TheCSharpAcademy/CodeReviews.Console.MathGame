using MathGame.AlainNshimirimana.Models;

namespace MathGame.AlainNshimirimana
{
    internal class Helpers
    {
        static List<Game> games = new List<Game>();
        internal static void GetGames()
        {
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

        internal static void AddToHistory(int gameScore, string gameType)
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
    }
}
