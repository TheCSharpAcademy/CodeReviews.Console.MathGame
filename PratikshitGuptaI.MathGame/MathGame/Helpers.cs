using MathGame.Models;
namespace MathGame
{
    internal class Helpers
    {
        static List<Game> games=new();
        internal static void GetGames()
        {
            Console.Clear();
            Console.WriteLine("Game History");
            Console.WriteLine("---------------");
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date}-{game.Type}:{game.Score}pts out of ");
            }
            Console.WriteLine("---------------");
            Console.WriteLine("Press ANy key to go to main menu");
            Console.ReadLine();
        }
        internal static void AddToHistory(int gameScore,GameType gameType,int total)
        {
            games.Add(new Game
            {
                Date=DateTime.Now,
                Score = gameScore,
                Total=total,
                Type = gameType,
            });
        }
        internal static int[] GetDivisionNumbers()
        {
            var random = new Random();
            var result = new int[2];
            var firstnumber = random.Next(1, 99);
            var secondnumber = random.Next(1, 99);
            while (firstnumber % secondnumber != 0)
            {
                firstnumber = random.Next(1, 99);
                secondnumber = random.Next(1, 99);
            }
            result[0] = firstnumber;
            result[1] = secondnumber;
            return result;
        }
        internal static string? ValidateResult(string result)
        {
            while (string.IsNullOrEmpty(result))
            {
                Console.WriteLine("Your answer need to be an Integer.Try Again!");
                result = Console.ReadLine();
            }
            return result;
        }
    }
}
