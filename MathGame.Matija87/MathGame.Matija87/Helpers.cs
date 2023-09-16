using MathGame.Matija87.Models;
using static MathGame.Matija87.Models.Game;

namespace MathGame.Matija87
{
    internal static class Helpers
    {
        internal static List<Game> games = new();
        internal static string GetName()
        {
            Console.Write("Enter your name: ");
            string? name = Console.ReadLine();
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be empty!");
                Console.WriteLine("Enter your name: ");
                name = Console.ReadLine();
            }
            return name;
        }

        internal static int[] GetDivisionNumbers()
        {
            Random random = new();
            int firstNumber = random.Next(0, 99);
            int secondNumber = random.Next(1, 99); //Prevents dividing by 0

            int[] result = new int[2];

            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(0, 99);
                secondNumber = random.Next(1, 99);
            }

            result[0] = firstNumber;
            result[1] = secondNumber;

            return result;
        }
              
        internal static void GetGames()
        {
            Console.Clear();
            Console.WriteLine("Games History:");
            Console.WriteLine("---------------------------");
            
            foreach (Game game in games) 
            {
                Console.WriteLine($"{game.DateTime} - {game.Type}: {game.Score} pts");
            }

            Console.WriteLine("---------------------------");
            Console.WriteLine("Press any key to return to Main Menu");
            Console.ReadKey();
            Console.Clear();
        }

        internal static void AddToHistory(int gameScore, GameType gameType)
        {
            games.Add(new Game
            {
                DateTime = DateTime.Now,
                Score = gameScore,
                Type = gameType
            });
        }
    }
}