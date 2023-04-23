using MathProject.Models;
using System.Linq;

namespace MathProject
{
    internal class Helpers
    {
        
        internal static List<Game> games = new List<Game>
        {
            //new Game { Date = DateTime.Now.AddDays(1), Type = GameType.Addition, Score = 5 },
            //new Game { Date = DateTime.Now.AddDays(2), Type = GameType.Multiplication, Score = 4 },
            //new Game { Date = DateTime.Now.AddDays(3), Type = GameType.Division, Score = 4 },
            //new Game { Date = DateTime.Now.AddDays(4), Type = GameType.Subtraction, Score = 3 },
            //new Game { Date = DateTime.Now.AddDays(5), Type = GameType.Addition, Score = 1 },
            //new Game { Date = DateTime.Now.AddDays(6), Type = GameType.Multiplication, Score = 2 },
            //new Game { Date = DateTime.Now.AddDays(7), Type = GameType.Division, Score = 3 },
            //new Game { Date = DateTime.Now.AddDays(8), Type = GameType.Subtraction, Score = 4 },
            //new Game { Date = DateTime.Now.AddDays(9), Type = GameType.Addition, Score = 4 },
            //new Game { Date = DateTime.Now.AddDays(10), Type = GameType.Multiplication, Score = 1 },
            //new Game { Date = DateTime.Now.AddDays(11), Type = GameType.Subtraction, Score = 0 },
            //new Game { Date = DateTime.Now.AddDays(12), Type = GameType.Division, Score = 2 },
            //new Game { Date = DateTime.Now.AddDays(13), Type = GameType.Subtraction, Score = 5 },
        };

        internal static string ValidateResult(string result)
        {
            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
            {
                Console.WriteLine("Your answer needs to be an integer. Try again.");
                result = Console.ReadLine();
            }
            return result;
        }

        internal static int[] GetDivisionNumbers(int low, int high)
        {
        

        Random random = new Random();
            int firstNumber = random.Next(low, high);
            int secondNumber = random.Next(low, high);

            int[] results = new int[2];

            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(low, high);
                secondNumber = random.Next(low, high);
            }

            results[0] = firstNumber;
            results[1] = secondNumber;

            return results;
        }

        // added a GameDifficulty
        internal static void AddToHistory(int gameScore, GameType gameType, GameDifficulty difficulty)
        {
            games.Add(new Game
            {
                Date = DateTime.Now,
                Score = gameScore,
                Type = gameType,
                Difficulty = difficulty
            }); ;
        }

        internal static void PrintGames()
        {
           // IEnumerable<Game> gamesToPrint = games.Where(x => x.Type == GameType.Division);

            Console.Clear();
            Console.WriteLine("Games History");
            Console.WriteLine("-----------------------");
            foreach (Game game in games) // gamesTopPrint if use
            {
                // added game difficulty
                Console.WriteLine($"{game.Date} - {game.Type} - {game.Difficulty}: {game.Score} pts");
            }
            Console.WriteLine("-----------------------\n");
            Console.WriteLine("Press any key to return to Main Menu");
            Console.ReadLine();
        }

        internal static string GetName()
        {
            Console.WriteLine("Type Name");
            string name = Console.ReadLine();

            while(string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name can't be empty");
                name = Console.ReadLine();
            }
            return name;
        }
    }
}
