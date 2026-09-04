using MathGame_v2.Model;

namespace MathGame_v2
{
    internal class Helper
    {
        internal static List<Game> gamesList = new();

        internal static void ViewGameHistory()
        {
            foreach(Game game in gamesList)
            {
                Console.WriteLine($"{game.Date} {game.Type} - {game.Score} pts");
            }
        }
        internal static void AddLog(GameType gameType, int gameScore)
        {
            gamesList.Add(new Game
            {
                Date = DateTime.Now,
                Type = gameType,
                Score = gameScore
            });
        }
        internal static int[] GetDivisibleNumbers()
        {
            
            Random random = new();
            int number1 = random.Next(1, 99);
            int number2 = random.Next(1, 99);
            int[] result = new int[2];

            while (number1 % number2 != 0)
            {
                number1 = random.Next(1, 99);
                number2 = random.Next(1, 99);
            }
            result[0] = number1;
            result[1] = number2;
            return result;
        }

        internal static string GetName()
        {
            Console.WriteLine("Please enter your name.");
            var name = Console.ReadLine();
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name can't be empty string.");
                name = Console.ReadLine();
            }
            return name;
        }

        internal static string ValidateResult(string? result)
        {
            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
            {
                Console.WriteLine("Result must be an integer.");
                result = Console.ReadLine();
            }
            return result;
        }

    }
}
