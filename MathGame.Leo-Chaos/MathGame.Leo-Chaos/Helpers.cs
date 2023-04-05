using BasicMathsProject.Models;


namespace BasicMathsProject
{
    internal class Helpers
    {
        private static int _difficultyLevel;
        public static int DifficultyLevel { get { return _difficultyLevel; } }

        internal static List<Game> games = new List<Game>{};

        internal static void PrintGames()
        {

            Console.Clear();
            Console.WriteLine("Games History");
            Console.WriteLine("----------------");
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date} - {game.Type} - {game.Level}: {game.Score}pts");
            }
            Console.WriteLine("----------------\n");
            Console.WriteLine("Press enter to return to main menu");
            Console.ReadLine();
        }

        internal static void AddToHistory(int gameScore, GameType gameType)
        {
            games.Add(new Game
            {
                Date = DateTime.Now,
                Score = gameScore,
                Type = gameType,
                Level = (Difficulty)DifficultyLevel
            });
        }

        internal static (int, int) GetDivisionNumbers()
        {
            var (firstNumber, secondNumber) = GameNumbers(99, 999, 9999);

            while (firstNumber % secondNumber != 0)
            {
                (firstNumber, secondNumber) = GameNumbers(99, 999, 9999);
            }

            return (firstNumber, secondNumber);
        }

        internal static string? ValidateResult(string result)
        {
            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
            {
                Console.WriteLine("Your answer needs to be an integer, try again");
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
                Console.WriteLine("Name can't be empty");
                name = Console.ReadLine();
            }
            return name;
        }

        internal static void ChooseDifficulty()
        {
            Console.WriteLine(@$"
What difficulty do you want? Choose an option:
1 - Easy
2 - Medium
3 - Hard");
            Console.WriteLine("--------------------------");

            var difficultyInput = Console.ReadLine();

            var difficultyCheck = DifficultyValidate(difficultyInput);
            _difficultyLevel = Int32.Parse(difficultyCheck);
        }
        internal static string DifficultyValidate(string result)
        {
            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _) || Int32.Parse(result) > 3)
            {
                Console.WriteLine("Pick 1,2 or 3. Try again");
                result = Console.ReadLine();
            }

            return result;
        }

        internal static (int, int) GameNumbers(
            int easy = 9,
            int medium = 99,
            int hard=999)
        {
            int firstNumber = 0;
            int secondNumber = 0;

            var random = new Random();

            switch (Helpers.DifficultyLevel)
            {
                case 1:
                    firstNumber = random.Next(1, easy);
                    secondNumber = random.Next(1, easy);
                    break;
                case 2:
                    firstNumber = random.Next(1, medium);
                    secondNumber = random.Next(1, medium);
                    break;
                case 3:
                    firstNumber = random.Next(1, hard);
                    secondNumber = random.Next(1, hard);
                    break;
                default:
                    break;
            }

            return (firstNumber, secondNumber);
        }
    }
}


