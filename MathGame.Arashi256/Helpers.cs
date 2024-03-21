using MathGame.Arashi256.Models;

namespace MathGame.Arashi256
{
    internal class Helpers
    {
        internal static List<Game> games = new List<Game>();

        internal static void PrintGames()
        {
            //var gamesToPrint = games.Where(x => x.Type  == GameType.Division).ToList();
            Console.Clear();
            Console.WriteLine("Games History\n");
            foreach (var game in games)
            {
                //Console.WriteLine(game);
                Console.WriteLine($"{game.Date} - {game.Type} on {game.Difficulty} difficulty: {game.Score} pts in {game.Time} time");
            }
            Console.WriteLine("\nPress any key to go back to the main menu");
            Console.ReadLine();
        }

        internal static void AddToHistory(int gamescore, GameType gametype, int difficulty, string? time)
        {
            //games.Add($"{DateTime.Now} - {gametype}: Score = {gamescore} pts");
            games.Add(new Game { Date = DateTime.Now, Score = gamescore, Type = gametype, Difficulty = (Difficulty)difficulty, Time = time });
        }

        internal static int[] GetDivisionNumbers(int difficulty)
        {
            var random = new Random();
            var result = new int[2];
            var firstNumber = random.Next(1, 99) * difficulty;
            var secondNumber = random.Next(1, 99) * difficulty;
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
                Console.WriteLine("Your answer needs to be an integer (whole number). Try again");
                result = Console.ReadLine();
            }
            return result;
        }

        internal static string GetName()
        {
            Console.WriteLine("Please type your name");
            var name = Console.ReadLine();
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be empty");
                name = Console.ReadLine();
            }
            return name;
        }

        internal static int GetNumberOfRounds(GameType type)
        {
            Console.WriteLine($"How many rounds of {type} game do you want to play?");
            return int.Parse(Helpers.ValidateResult(Console.ReadLine()));
        }
    }
}
