using math_game.models;

namespace math_game
{
    internal class helpers
    {
        internal static List<Game> games = new();

        internal static void ViewPreviousGame()
        {
            //Lambda
            //var gameToPrint = games.Where(x => x.Type == GameType.Division).OrderByDescending(x => x.Score);

            Console.Clear();
            Console.WriteLine("Previous Game History");
            Console.WriteLine("---------------------------------------------------------------");
            foreach (var game in games)
            //foreach (var game in gameToPrint)
            {
                Console.WriteLine($"{game.Date} - {game.Type}: {game.Score}pts");
            }
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("Press any key to go back to the main menu.");
            Console.ReadLine();
        }

        internal static void AddToHistory(int gameScore, GameType gameType)
        {
            //games.Add($"{DateTime.Now} - {gameType}: Score = {gameScore}");
            games.Add(new Game
            {
                Date = DateTime.Now,
                Score = gameScore,
                Type = gameType
            });
        }
    }
}
