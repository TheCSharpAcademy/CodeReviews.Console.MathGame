namespace MathGame
{
    internal class Helpers
    {
        internal static List<string> gameHistory = new();

        internal static int[] GetDivisionNumbers()
        {
            var random = new Random();

            var firstNum = random.Next(1, 10);
            var secondNum = random.Next(1, 10);
            var result = new int[2];

            while (firstNum % secondNum != 0)
            {
                firstNum = random.Next(1, 10);
                secondNum = random.Next(1, 10);
            }

            result[0] = firstNum;
            result[1] = secondNum;

            return result;
        }

        internal static void ShowHistory()
        {
            Console.Clear();
            Console.WriteLine("Game history");
            Console.WriteLine("---------------------------------------------");

            foreach (var game in gameHistory)
            {
                Console.WriteLine(game);
            }

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Press any key to go back to menu");
            Console.ReadLine();
        }

        internal static void AddToHistory(int gameScore, string gameType)
        {
            gameHistory.Add($"Date:{DateTime.Now} - {gameType} game, your score is {gameScore}");
        }

        internal static string? Validate(string result)
        {
            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
            {
                Console.WriteLine("Input must be a integer");
                result = Console.ReadLine();
            }
            return result;
        }
    }
}