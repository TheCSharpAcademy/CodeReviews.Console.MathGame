
using System.Linq;

namespace math_console_app
{
    internal class Helpers
    {

        internal static List<Game> games = new List<Game>();

        internal static void ViewGameHistory()
        {

            Console.Clear();
            Console.WriteLine("Games History");
            Console.WriteLine("-------------------------------------------------\n");

            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date} - {game.Type}: {game.Score}pts - Difficulty: {game.Difficulty}");
            }

            Console.WriteLine("-------------------------------------------------\n");
            Console.WriteLine("Press any key to return the the main menu.");
            Console.ReadKey(true);
        }

        internal static int[] GetDivisionNumbers(int numberLimitLower, int numberLimitUpper)
        {
            var random = new Random();
            var result = new int[2];

            var firstNumber = random.Next(numberLimitLower, numberLimitUpper);
            var secondNumber = random.Next(numberLimitLower, numberLimitUpper);

            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(numberLimitLower, numberLimitUpper);
                secondNumber = random.Next(numberLimitLower, numberLimitUpper);
            }

            result[0] = firstNumber;
            result[1] = secondNumber;

            return result;
        }

        internal static void AddToHistory(int gameScore, GameType gameType, string difficulty)
        {

            string gameDifficulty;

            switch(difficulty)
            {
                case "e":
                    gameDifficulty = "Easy";
                    break;
                case "m":
                    gameDifficulty = "Medium";
                    break;
                case "h":
                    gameDifficulty = "Hard";
                    break;
                default:
                    gameDifficulty = "Unknown";
                    break;
            }

            games.Add( new Game
                {
                    Date = DateTime.Now,
                    Type = gameType,
                    Score = gameScore,
                    Difficulty = gameDifficulty,
                } 
            );
        }

        internal static string? ValidateResult(string result)
        {
            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
            {
                Console.WriteLine("Your input needs to be an integer. Please try again.");
                result = Console.ReadLine();

            }

            return result;
        }

        internal static string GetName()
        {
            Console.WriteLine("Please enter your name");

            var name = Console.ReadLine();
            
            while(string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be empty!");
                name = Console.ReadLine();
            }

            return name;

        }

        internal static string GetDifficulty()
        {
            Console.Clear();
            Console.WriteLine($@"Please choose a difficulty. 
            E - Easy
            M - Medium
            H - Hard
            ");
            var difficultySelected = Console.ReadLine()?.ToLower().Trim();

            while (string.IsNullOrEmpty(difficultySelected) || (difficultySelected != "e" && difficultySelected != "m" && difficultySelected != "h"))
            {
                Console.WriteLine("Please choose a valid difficulty!");
                difficultySelected = Console.ReadLine()?.ToLower().Trim();
            }

            return difficultySelected;

        }
    }
}
