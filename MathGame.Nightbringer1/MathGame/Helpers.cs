using MathGame.Models;

namespace MathGame
{
    internal static class Helpers
    {
        internal static List<Game> games = new List<Game>()
        {
            new Game {Date = DateTime.Now.AddDays(1), Type = Game.GameType.Addition, Score = 5},
            new Game {Date = DateTime.Now.AddDays(1), Type = Game.GameType.Subtraction, Score = 1}
        };
        internal static void PrintGames()
        {
            var gamesToPrint = games.Where(x => x.Date > new DateTime(2024, 06, 17)).OrderByDescending(x => x.Score);

            Console.Clear();
            Console.WriteLine("Game History");
            Console.WriteLine("-------------------------------------");
            foreach (Game game in gamesToPrint)
            {
                Console.WriteLine($"{game.Date} - {game.Type}: {game.Score}pts");
            }
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadLine();
        }

        internal static void AddToHistory(Game.GameType gameType, int gameScore)
        {
            games.Add(new Game
            {
                Date = DateTime.Now,
                Score = gameScore,
                Type = gameType
            });
        }

        internal static string GetName()
        {
            
            Console.WriteLine("Please type your name into the field below: ");
            string name = Console.ReadLine();
            while(name == null) 
            {
                Console.WriteLine("Please input a name! This field cannot be empty");
                name = Console.ReadLine();
            }
            return name;
        }
        internal static int[] GetDivisionNumbers()
        {
            var random = new Random();

            var firstNumber = random.Next(1, 99);
            int secondNumber = random.Next(1, 99);

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

        internal static string? ValidateResult(string result)
        {
            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
            {
                Console.WriteLine("Your answer needs to be an integer, try again!");
                result = Console.ReadLine();
                
            }
            return result;
        }
    }
}
