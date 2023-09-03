using MathGame.AndreasGuy54.Models;

namespace MathGame.AndreasGuy54
{
    internal class Helpers
    {
        static List<Game> games = new();
        internal static void PrintGames()
        {
            Console.Clear();
            Console.WriteLine("Games History\n--------------------------------------------------------------");
            
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date} - {game.Type} : {game.Score}pts");
            }

            Console.WriteLine("--------------------------------------------------------------\n");
            Console.WriteLine("Press any key to return to the Main Menu:");
            Console.ReadLine();
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

        internal static int[] GetDivisionNumbers()
        {
            Random random = new();
            int firstNumber = random.Next(1, 99);
            int secondNumber = random.Next(1, 99);

            int[] result = new int[2];

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
