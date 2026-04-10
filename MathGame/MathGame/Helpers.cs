using MathGame.Models;

namespace MathGame
{
    internal class Helpers
    {
        internal static List<Game> gameHistory = new();

        internal static void PrintGameHistory()
        {
            Console.Clear();
            Console.WriteLine("Games History");
            Console.WriteLine("------------------------");
            foreach (var game in gameHistory)
            {
                Console.WriteLine($"{game.Date} - {game.Type}: {game.Score}/{game.QuestionAmount}pts");
            }
            Console.WriteLine("------------------------");
            Console.WriteLine("Press any key to return to the Main Menu");
            Console.ReadLine();
        }

        internal static void AddToHistory(int gameScore, int questionAmount, GameType gameType)
        {
            gameHistory.Insert(0, new Game
            {
                Date = DateTime.Now,
                Score = gameScore,
                Type = gameType,
                QuestionAmount = questionAmount
            });
        }

        internal static string GetName()
        {
            Console.WriteLine("Please type your name");
            string? name = Console.ReadLine();

            while(string.IsNullOrEmpty(name))
            {
                Console.Clear();
                Console.WriteLine("Name can't be empty");
                Console.WriteLine("Please type your name");
                name = Console.ReadLine();
            }
            return name;
        }

    }
}
