using MathGame.Models;

namespace MathGame {
    internal static class Helpers {

        internal static List<Game> games = new();
        internal static void PrintGames() {

            Console.Clear();
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Games history:");
            Console.WriteLine("\n");

            foreach (Game game in games) {
                Console.WriteLine($"{game.Date} - {game.Type}: {game.Score}");
            }

            Console.WriteLine("----------------------------------\n");
            Console.WriteLine("Press any key to go back to main menu:");
            Console.ReadLine();
        }

        internal static int GenerateRandomNumber(int min, int limit) {
            Random random = new Random();
            int randomNumber = random.Next(min, limit);

            return randomNumber;
        }

        internal static int[] GetDivisionNumbers() {
            int firstNumber = GenerateRandomNumber(1, 99);
            int secondNumber = GenerateRandomNumber(1, 99);

            int[] result = new int[2];

            while (firstNumber % secondNumber != 0) {
                firstNumber = GenerateRandomNumber(1, 99);
                secondNumber = GenerateRandomNumber(1, 99);
            }

            result[0] = firstNumber;
            result[1] = secondNumber;

            return result;
        }



        internal static void AddToHistory(int gameScore, GameType gameType) {
            games.Add(new Game 
            {
                Date = DateTime.Now,
                Score = gameScore,
                Type = gameType
            });
        }
    }
}
