using MathGame.basemkasem.Modles;

namespace MathGame.basemkasem
{
    internal class Helpers
    {
        internal static List<Game> games = new();
        internal static string GetName()
        {
            Console.Write("Enter your name: ");

            var name = Console.ReadLine();

            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name can't be empty. Try again");
                name = Console.ReadLine();
            }
            return name;
        }
        internal static void PrintGames()
        {
            var gamesToPrint = games.Where(x => x.Date > new DateTime(2024, 03, 30)).OrderByDescending(x => x.Score);

            Console.Clear();
            Console.WriteLine("Games History: ");
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date} - Difficulty: {game.Difficulty} - {game.Type}: {game.Score} pts ");
            }
            Console.WriteLine("Press any key to go to the menu.");
            Console.ReadLine();
        }
        internal static void AddToHistory(int gameScore, GameType gameType, GameDifficulty difficulty)
        {
            games.Add(new Game
            {
                Score = gameScore,
                Date = DateTime.Now,
                Type = gameType,
                Difficulty = difficulty
            });
        }
        internal static int[] GetDivisionNumbers(GameDifficulty difficulty)
        {
            var random = new Random();

            int firstNumber;
            int secondNumber;

            var result = new int[2];

            do
            {
                if (difficulty == GameDifficulty.Easy)
                {
                    firstNumber = random.Next(1, 99);
                    secondNumber = random.Next(1, 99);
                }
                else if (difficulty == GameDifficulty.Medium)
                {
                    firstNumber = random.Next(1, 999);
                    secondNumber = random.Next(1, 99);
                }
                else
                {
                    firstNumber = random.Next(1, 9999);
                    secondNumber = random.Next(1, 999);
                }
            } while (firstNumber % secondNumber != 0);

            result[0] = firstNumber;
            result[1] = secondNumber;

            return result;
        }

        internal static string? ValidateResult(string result)
        {
            while (string.IsNullOrEmpty(result) || !int.TryParse(result, out _))
            {
                Console.WriteLine("The answer needs to be an interger. Try again");
                result = Console.ReadLine();
            }
            return result;
        }

        internal static GameDifficulty DifficultyLevelChosen()
        {
            Console.WriteLine(@"Choose the difficulty level: 
1. Easy.
2. Medium.
3. Hard.");
            var result = Console.ReadLine();
            result = ValidateResult(result);
            do
            {
                if (result == "1")
                    return GameDifficulty.Easy;
                else if (result == "2")
                    return GameDifficulty.Medium;
                else if (result == "3")
                    return GameDifficulty.Hard;
                else
                    continue;
            } while (true);

        }
    }
}
