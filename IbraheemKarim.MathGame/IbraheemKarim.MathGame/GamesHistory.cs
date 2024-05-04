namespace IbraheemKarim.MathGame
{
    internal static class GamesHistory
    {
        private static List<GameRecord> games = new();

        internal static void AddToHistory(int gameScore, GameType gameType)
        {
            games.Add(new GameRecord
            {
                Date = DateTime.Now,
                Score = gameScore,
                Type = gameType
            });
        }
        internal static void PrintHistory()
        {
            Console.Clear();
            Console.WriteLine("Games History");
            Console.WriteLine("---------------------------");
            foreach (var game in games)
            {
                Console.WriteLine(game);
            }
            Console.WriteLine("---------------------------\n");
            Console.WriteLine("Press any key to return to Main Menu");
            Console.ReadKey();
        }
    }
}
