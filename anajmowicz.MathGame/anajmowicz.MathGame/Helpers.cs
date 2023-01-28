namespace anajmowicz.MathGame
{
    internal class Helpers
    {
        static List<string> games = new();
        internal static void GetGames()
        {
            Console.Clear();
            Console.WriteLine("Games history:");
            Console.WriteLine("-----------------------");

            foreach (string game in games)
            {
                Console.WriteLine(game);
            }

            Console.WriteLine("-----------------------\n");
            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadLine();
        }

        internal static void AddToHistory(string message, int score)
        {
            games.Add($"{DateTime.Now}  - {message}: {score} pts");
            // add name later
        }
    }
}
