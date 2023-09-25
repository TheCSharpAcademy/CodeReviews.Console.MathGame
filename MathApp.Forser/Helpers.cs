namespace MathApp
{
    internal class Helpers
    {
        static List<string> games = new List<string>();

        internal static void GetGames()
        {
            Console.Clear();
            Console.WriteLine("Games History");
            Console.WriteLine("-----------------------------");
            foreach (var game in games)
            {
                Console.WriteLine(game);
            }
            Console.WriteLine("-----------------------------\n");
            Console.WriteLine("Press any key to return to Main Menu!");
            Console.ReadLine();
        }
        internal static void AddToHistory(int gameScore, string gameType)
        {
            games.Add($"{DateTime.Now} - {gameType}: {gameScore} pts");
        }
        internal static int[] GetDivisionNumbers()
        {
            var random = new Random();
            var firstNumber = random.Next(1, 99);
            var secondNumber = random.Next(1, 99);

            var result = new int[2];
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
