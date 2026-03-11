

using System.Diagnostics;

namespace MathGame
{
    internal class Helpers
    {
        internal static List<Game> games = new List<Game>() { };

        internal static void AddToList(int gameScore, string gameDifficulty, GameType gameType, string gameTime)
        {
            games.Add(new Game
            {
                Score = gameScore,
                Difficulty = gameDifficulty,
                Type = gameType,
                Seconds = gameTime
            });
        }

        internal static void DisplayHistory()
        {

            Console.WriteLine("Your session history:");
            Console.WriteLine("------------------------------------------------");
            foreach (Game game in games)
            {
                Console.WriteLine($@"Mode: {game.Difficulty} {game.Type} - Score: {game.Score} - Completion time: {game.Seconds} seconds.");
            }
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Press 'enter' to return to menu.");
            Console.ReadLine();

        }
    }
}
