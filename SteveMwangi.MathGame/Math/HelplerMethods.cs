using Math.Models;


namespace Math
{
    internal class HelperMethods
    {
        static List<Model> gameHistory = new();

        internal static void ListHistory()
        {
            Console.Clear();
            Console.WriteLine(".....................................");
            foreach (var history in gameHistory)
            {
                Console.WriteLine($"{history.Date} - {history.GameType} Score: {history.Score}/{history.Questions} Timetaken: {history.TimeTaken}");
            }
            Console.WriteLine(".....................................\n");
            Console.WriteLine("Press any key to go back to main menu");
            Console.ReadLine();
        }


        internal static void AddHistory(int score, GameType gameType, int questions, TimeSpan timeTaken)
        {
            gameHistory.Add(new Model
            {
                Score = score,
                GameType = gameType,
                Date = DateTime.UtcNow,
                Questions = questions,
                TimeTaken = timeTaken
            });
        }


        internal static int[] GetDivisionNumbers()
        {
            var random = new Random();
            int firstNumber = random.Next(1, 99);
            int secondNumber = random.Next(1, 99);

            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(1, 99);
                secondNumber = random.Next(1, 99);
            }

            var result = new int[2];
            result[0] = firstNumber;
            result[1] = secondNumber;

            return result;

        }

    }
}
