namespace MathGame.AndreasGuy54
{
    internal class Helpers
    {
        static List<string> games = new();
        internal static void GetGames()
        {
            Console.Clear();
            Console.WriteLine("Games History\n--------------------------------------------------------------");
            foreach (var game in games)
            {
                Console.WriteLine(game);
            }
            Console.WriteLine("--------------------------------------------------------------\n");
            Console.WriteLine("Press any key to return to the Main Menu:");
            Console.ReadLine();
        }

        internal static void AddToHistory(int gameScore, string gameType)
        {
            games.Add($"{DateTime.Now} - {gameType}: {gameScore}pts");
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
