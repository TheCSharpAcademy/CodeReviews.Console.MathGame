using SimpleMathGame.Models;

namespace SimpleMathGame
{
    internal class Helpers
    {
        static List<Game> gameHistory = new();

        internal static int[] GetDivisionNumbers()
        {
            Random random = new Random();
            int firstNumber = random.Next(0, 99);
            int secondNumber = random.Next(1, 99);

            int[] results = new int[2];

            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(0, 99);
                secondNumber = random.Next(1, 99);
            }

            results[0] = firstNumber;
            results[1] = secondNumber;

            return results;
        }
        internal static void AddToHistory(int score, GameType typeOfGame, int amountOfQuestions)
        {
            gameHistory.Add(new Game
            {
                Date = DateTime.Now,
                Score = score,
                Type = typeOfGame,
                AmountOfQuestions = amountOfQuestions
            });
        }
        internal static void ClickToContinue()
        {
            Console.WriteLine("Click a button to continue");
            Console.ReadLine();
        }
        internal static void showGameHistory()
        {
            Console.Clear();
            Console.WriteLine(@"Game History
------------------------------------");
            foreach (Game game in gameHistory)
            {
                Console.WriteLine($"{game.Date} - {game.Type}: {game.Score} / {game.AmountOfQuestions}");
            }
            Console.WriteLine(@"------------------------------------
Press any key to return to the main menu
------------------------------------");
            Console.ReadLine();
        }

        internal static string? ValidateResult(string result)
        {
            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
            {
                Console.WriteLine("Your answer needs to be an integer. Try again.");
                result = Console.ReadLine();
            }

            return result;
        }

        internal static string GetName()
        {
            Console.WriteLine("Please type your name");
            string? name = Console.ReadLine();

            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name can't be empty");
                name = Console.ReadLine();
            }
                return name;
            
        }
    }
}
