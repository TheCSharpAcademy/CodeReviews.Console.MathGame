using MathProject.Models;
using System.Linq;

namespace MathProject
{
    internal class Helpers
    {
        
        internal static List<Game> games = new List<Game>
        {
            
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
            }); 
        }

        internal static void PrintGames()
        {
         
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
