namespace MathGame.Matija87
{
    public static class Helpers
    {
        public static string GetName()
        {
            Console.Write("Enter your name: ");
            string? name = Console.ReadLine();
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be empty!");
                Console.WriteLine("Enter your name: ");
                name = Console.ReadLine();
            }
            return name;
        }

        public static int[] GetDivisionNumbers()
        {
            Random random = new();
            int firstNumber = random.Next(0, 99);
            int secondNumber = random.Next(1, 99); //Prevents dividing by 0

            int[] result = new int[2];

            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(0, 99);
                secondNumber = random.Next(1, 99);
            }

            result[0] = firstNumber;
            result[1] = secondNumber;

            return result;
        }

        internal static List<string> games = new();

        public static void GetGames()
        {
            Console.Clear();
            Console.WriteLine("Games History:");
            Console.WriteLine("---------------------------");
            
            foreach (string game in games) 
            {
                Console.WriteLine(game);
            }

            Console.WriteLine("---------------------------");
            Console.WriteLine("Press any key to return to Main Menu");
            Console.ReadKey();
            Console.Clear();
        }

        public static void AddToHistory(int gameScore, string gameType)
        {
            games.Add($"{DateTime.Now} - {gameType}: {gameScore}");
        }
    }
}