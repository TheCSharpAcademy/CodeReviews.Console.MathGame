using MathGame.Models;

namespace MathGame
{
    internal class Helpers
    {
        internal static List<Game> games = new();
        internal static Random random = new();
        internal static int[] GetDivisionNumbers()
        {
            int[] numbers = new int[2];
            do
            {
                numbers[0] = random.Next(1, 99);
                numbers[1] = random.Next(1, 99);
            } while (numbers[0] % numbers[1] != 0);

            return numbers;
        }
        internal static void GetGameHistory()
        {
            //IEnumerable<Game> gamesToPrint = games.Where(x => x.Date > new DateTime(2025, 10, 23)).OrderByDescending(x => x.Score);
            Console.Clear();
            Console.WriteLine("Games History");
            Console.WriteLine("------------------------------");
            foreach (Game game in games)
            {
                Console.WriteLine($"{game.Date} - {game.Type}: {game.Score} pts");
            }
            Console.WriteLine("------------------------------\n");
            Console.WriteLine("Press any key to go back to main menu.");
            Console.ReadLine();
        }
        internal static void AddHistory(int score, GameType gameType)
        {
            games.Add(new Game
            {
                Date = DateTime.Now,
                Score = score,
                Type = gameType
            });
        }

        internal static string? ValidateAnswer(string answer)
        {
            while (string.IsNullOrEmpty(answer) || !Int32.TryParse(answer, out _)) 
            {
                Console.WriteLine("Your answer needs to be an integer");
                answer = Console.ReadLine();
            }
            return answer;
        }

        internal static string GetName()
        {
            Console.WriteLine("Please type your name: ");
            string name = Console.ReadLine();
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name can't be empty: ");
                name = Console.ReadLine();
            }
            return name;
        }
    }
}
