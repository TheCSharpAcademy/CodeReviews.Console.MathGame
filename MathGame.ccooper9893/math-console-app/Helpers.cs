
using System.Linq;

namespace math_console_app
{
    internal class Helpers
    {

        internal static List<Game> games = new List<Game>
        {
/*              new Game { Date = DateTime.Now.AddDays(1), Type = GameType.Addition, Score = 5 },
                new Game { Date = DateTime.Now.AddDays(2), Type = GameType.Multiplication, Score = 4 },
                new Game { Date = DateTime.Now.AddDays(3), Type = GameType.Division, Score = 4 },
                new Game { Date = DateTime.Now.AddDays(4), Type = GameType.Subtraction, Score = 3 },
                new Game { Date = DateTime.Now.AddDays(5), Type = GameType.Addition, Score = 1 },
                new Game { Date = DateTime.Now.AddDays(6), Type = GameType.Multiplication, Score = 2 },
                new Game { Date = DateTime.Now.AddDays(7), Type = GameType.Division, Score = 3 },
                new Game { Date = DateTime.Now.AddDays(8), Type = GameType.Subtraction, Score = 4 },
                new Game { Date = DateTime.Now.AddDays(9), Type = GameType.Addition, Score = 4 },
                new Game { Date = DateTime.Now.AddDays(10), Type = GameType.Multiplication, Score = 1 },
                new Game { Date = DateTime.Now.AddDays(11), Type = GameType.Subtraction, Score = 0 },
                new Game { Date = DateTime.Now.AddDays(12), Type = GameType.Division, Score = 2 },
                new Game { Date = DateTime.Now.AddDays(13), Type = GameType.Subtraction, Score = 5 },*/
        };

        internal static void ViewGameHistory()
        {

/*            var gamesToPrint = games.Where( x => x.Date > new DateTime( 2022, 08, 09 )).OrderByDescending( x => x.Score );*/

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
