namespace Math_Game
{
    internal class Helpers
    {
        static List<string> games = new();
        internal static void AddToHistory(int gameScore, string gameType)
        {
            games.Add($"{DateTime.Now} - {gameType}: {gameScore} pts");
        }

        internal static int[] GetDivisionNumbers()
        {
            var random = new Random();
            var firstNumber = random.Next(0, 99);
            var secondNumber = random.Next(0, 99);

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

        internal static int[] GetDivisionNumbersHard()
        {
            var random = new Random();
            var firstNumber = random.Next(0, 99);
            var secondNumber = random.Next(0, 99);

            var result = new int[2];

            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(25, 300);
                secondNumber = random.Next(25, 300);
            }

            result[0] = firstNumber;
            result[1] = secondNumber;

            return result;
        }

        internal static void GetGames()
        {
            Console.Clear();
            Console.WriteLine("Game History");
            Console.WriteLine("----------------------------------");
            foreach (var game in games)
            {
                Console.WriteLine(game);
            }
            Console.WriteLine("------------------------------\n");
            Console.WriteLine("Press any key to go back to menu");
            Console.ReadLine();
        }

        internal static string Difficulty()
        {

            var easy = "e";
            var hard = "h";

            Console.WriteLine("Please choose difficulty e = easy, h = hard");
            string difficulty = Console.ReadLine();

            if (difficulty == "e")
            {
                difficulty = easy;
            }
            else
            {
                difficulty = hard;
            }

            return difficulty;
        }

        internal static int NumberOfQuestions()
        {
            Console.WriteLine("How many questions would you like to answer");
            var questionAmount = int.Parse(Console.ReadLine());
            return questionAmount;
        }
    }
}
