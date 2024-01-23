using MathGame.WinnieNgina.Models;

namespace MathGame.WinnieNgina
{
    internal class Helpers
    {
        // This is a field. Variable declared directly within a class 
        internal static List<Game> games = new List<Game>
        {
        };

        internal static void PrintGames()
        {
            Console.Clear();
            Console.WriteLine("Games History");
            Console.WriteLine("-------------------------------");
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date} - {game.Type}: {game.Score}pts. The game difficulty level is: {game.Level}");
            }
            Console.WriteLine("-------------------------------/n");
            Console.WriteLine("Press any key to return to the Main Menu");
            Console.ReadLine();

        }
        internal static void AddToHistory(int gameScore, GameType gameType, DifficultLevel level)
        {
            games.Add(new Game
            {
                Date = DateTime.Now,
                Score = gameScore,
                Type = gameType,
                Level = level

            });

        }
        internal static (int FirstNumber, int SecondNumber, DifficultLevel Level) GetDivisionNumbers()
        {
            var random = new Random();
            Console.WriteLine("Choose the game difficulty level:");
            Console.WriteLine("E - Easy (0-100)");
            Console.WriteLine("M - Medium (100-500)");
            Console.WriteLine("D - Difficult (500-1000)");
            Console.WriteLine("-----------------------------------------");
            var level = Console.ReadLine()?.Trim().ToLower();

            int firstNumber;
            int secondNumber;
            DifficultLevel difficultyLevel;
            switch (level)
            {
                case "e":
                    firstNumber = random.Next(0, 100);
                    secondNumber = random.Next(0, 100);
                    difficultyLevel = DifficultLevel.Easy;
                    while (firstNumber % secondNumber != 0)
                    {
                        firstNumber = random.Next(0, 100);
                        secondNumber = random.Next(0, 100);
                    }
                    break;

                case "m":
                    firstNumber = random.Next(100, 500);
                    secondNumber = random.Next(100, 500);
                    difficultyLevel = DifficultLevel.Medium;
                    while (firstNumber % secondNumber != 0)
                    {
                        firstNumber = random.Next(100, 500);
                        secondNumber = random.Next(100, 500);
                    }
                    break;

                case "d":
                    firstNumber = random.Next(500, 1000);
                    secondNumber = random.Next(500, 1000);
                    difficultyLevel = DifficultLevel.Difficult;
                    while (firstNumber % secondNumber != 0)
                    {
                        firstNumber = random.Next(500, 1000);
                        secondNumber = random.Next(500, 1000);
                    }
                    break;

                default:
                    Console.WriteLine("Invalid Input. Defaulting to Medium difficulty.");
                    firstNumber = random.Next(100, 500);
                    secondNumber = random.Next(100, 500);
                    difficultyLevel = DifficultLevel.Medium;
                    while (firstNumber % secondNumber != 0)
                    {
                        firstNumber = random.Next(100, 500);
                        secondNumber = random.Next(100, 500);
                    }
                    break;
            }
            return (firstNumber, secondNumber, difficultyLevel);
        }

        internal static string? ValidateResult(string result)
        {
            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
            {
                Console.WriteLine("Your answer needs to be an integer. Try again.");
                result = Console.ReadLine();
            }
            return result;
        }
        internal static string GetName()
        {
            Console.WriteLine("Please enter your name");
            var name = Console.ReadLine();
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name can't be empty");
                name = Console.ReadLine();
            }
            return name;
        }
        internal static string? GetQuestions()
        {
            Console.WriteLine("Please enter the number of questions you would like to answer");
            var question = Console.ReadLine();
            while (string.IsNullOrEmpty(question) || !Int32.TryParse(question, out _))
            {
                Console.WriteLine("Your answer needs to be an integer. Try again.");
                question = Console.ReadLine();
            }
            return question;
        }
        internal static (int FirstNumber, int SecondNumber, DifficultLevel Level) GetNumbers()
        {
            var random = new Random();
            DifficultLevel difficultyLevel;

            Console.WriteLine("Choose the game difficulty level:");
            Console.WriteLine("E - Easy (0-10)");
            Console.WriteLine("M - Medium (10-50)");
            Console.WriteLine("D - Difficult (50-100)");
            Console.WriteLine("-----------------------------------------");

            var level = Console.ReadLine()?.Trim().ToLower();

            int firstNumber;
            int secondNumber;

            switch (level)
            {
                case "e":
                    firstNumber = random.Next(0, 11);
                    secondNumber = random.Next(0, 11);
                    difficultyLevel = DifficultLevel.Easy;
                    break;

                case "m":
                    firstNumber = random.Next(10, 51);
                    secondNumber = random.Next(10, 51);
                    difficultyLevel = DifficultLevel.Medium;
                    break;

                case "d":
                    firstNumber = random.Next(50, 101);
                    secondNumber = random.Next(50, 101);
                    difficultyLevel = DifficultLevel.Difficult;
                    break;

                default:
                    Console.WriteLine("Invalid Input. Defaulting to Medium difficulty.");
                    firstNumber = random.Next(0, 11);
                    secondNumber = random.Next(0, 11);
                    difficultyLevel = DifficultLevel.Medium;
                    break;
            }
            return (firstNumber, secondNumber, difficultyLevel);
        }
    }
}
