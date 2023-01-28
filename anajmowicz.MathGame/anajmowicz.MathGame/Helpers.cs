using anajmowicz.MathGame.Models;

namespace anajmowicz.MathGame
{
    internal class Helpers
    {
        static List<Game> games = new()
        {
        new Game { Date = DateTime.Now.AddDays(-1), Type = GameType.Addition, Score = 5 },
        new Game { Date = DateTime.Now.AddDays(-2), Type = GameType.Multiplication, Score = 4 },
        new Game { Date = DateTime.Now.AddDays(-3), Type = GameType.Division, Score = 4 },
        new Game { Date = DateTime.Now.AddDays(-4), Type = GameType.Subtraction, Score = 3 },
        new Game { Date = DateTime.Now.AddDays(-5), Type = GameType.Addition, Score = 1 },
        new Game { Date = DateTime.Now.AddDays(-6), Type = GameType.Multiplication, Score = 2 },
        new Game { Date = DateTime.Now.AddDays(-7), Type = GameType.Division, Score = 3 },
        new Game { Date = DateTime.Now.AddDays(-8), Type = GameType.Subtraction, Score = 4 },
        new Game { Date = DateTime.Now.AddDays(-9), Type = GameType.Addition, Score = 4 },
        new Game { Date = DateTime.Now.AddDays(-10), Type = GameType.Multiplication, Score = 1 },
        new Game { Date = DateTime.Now.AddDays(-11), Type = GameType.Subtraction, Score = 0 },
        new Game { Date = DateTime.Now.AddDays(-12), Type = GameType.Division, Score = 2 },
        new Game { Date = DateTime.Now.AddDays(-13), Type = GameType.Subtraction, Score = 5 },
        };

        internal static void AddToHistory(GameType type, int gameScore)
        {
            games.Add(new Game
            {
                Date = DateTime.Now,
                Score = gameScore,
                Type = type
            });
        }

        internal static void PrintGames()
        {
            Console.Clear();
            Console.WriteLine("Games history:");
            Console.WriteLine("-----------------------");

            foreach (Game game in games)
            {
                Console.WriteLine($"{game.Date} - {game.Type}: {game.Score} pts");
            }

            Console.WriteLine("-----------------------\n");
            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadLine();
        }
    }
}
