using MathGame.Models;
using System.Security.AccessControl;

namespace MathGame
{
    internal class Helpers
    {
        internal static List<Game> games = new List<Game>
        {
            //new Game { Date = DateTime.Now.AddDays(1), Score = 1, Type = GameType.Addition, Difficulty = DifficultyOptions.Easy, Duration = TimeSpan.FromSeconds(80)},
            //new Game { Date = DateTime.Now.AddDays(2), Score = 2, Type = GameType.Substraction, Difficulty = DifficultyOptions.Hard, Duration = TimeSpan.FromSeconds(90)},
            //new Game { Date = DateTime.Now.AddDays(3), Score = 3, Type = GameType.Multiplication, Difficulty = DifficultyOptions.Normal, Duration = TimeSpan.FromSeconds(70)},
            //new Game { Date = DateTime.Now.AddDays(4), Score = 4, Type = GameType.Division, Difficulty = DifficultyOptions.Hard, Duration = TimeSpan.FromSeconds(60)},
            //new Game { Date = DateTime.Now.AddDays(5), Score = 5, Type = GameType.Multiplication, Difficulty = DifficultyOptions.Normal, Duration = TimeSpan.FromSeconds(50)},
            //new Game { Date = DateTime.Now.AddDays(6), Score = 4, Type = GameType.Substraction, Difficulty = DifficultyOptions.Easy, Duration = TimeSpan.FromSeconds(40)},
            //new Game { Date = DateTime.Now.AddDays(7), Score = 3, Type = GameType.Division, Difficulty = DifficultyOptions.Normal, Duration = TimeSpan.FromSeconds(30)},
            //new Game { Date = DateTime.Now.AddDays(8), Score = 2, Type = GameType.Addition, Difficulty = DifficultyOptions.Easy, Duration = TimeSpan.FromSeconds(20)},
            //new Game { Date = DateTime.Now.AddDays(9), Score = 1, Type = GameType.Addition, Difficulty = DifficultyOptions.Hard, Duration = TimeSpan.FromSeconds(10)},
            //new Game { Date = DateTime.Now.AddDays(10), Score = 5, Type = GameType.Multiplication, Difficulty = DifficultyOptions.Normal, Duration = TimeSpan.FromSeconds(100)},
            //new Game { Date = DateTime.Now.AddDays(11), Score = 3, Type = GameType.Division, Difficulty = DifficultyOptions.Easy, Duration = TimeSpan.FromSeconds(75)},
            //new Game { Date = DateTime.Now.AddDays(12), Score = 4, Type = GameType.Addition, Difficulty = DifficultyOptions.Hard, Duration = TimeSpan.FromSeconds(85)},
            //new Game { Date = DateTime.Now.AddDays(13), Score = 1, Type = GameType.Multiplication, Difficulty = DifficultyOptions.Normal, Duration = TimeSpan.FromSeconds(95)},
            //new Game { Date = DateTime.Now.AddDays(14), Score = 2, Type = GameType.Substraction, Difficulty = DifficultyOptions.Easy, Duration = TimeSpan.FromSeconds(100)}
        };
        internal static void PrintGames()
        {
            //var gamesToPrint = games.Where(x => x.Date > new DateTime(2025, 10, 7)).OrderByDescending(x =>x.Score);

            Console.Clear();
            Console.WriteLine("Games History");
            Console.WriteLine("-----------------------------");

            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date} - {game.Type} (Difficulty: {game.Difficulty}), Time - {game.Duration.Seconds} seconds : {game.Score}pts");
            }
            Console.WriteLine("------------------------------\n");
            Console.WriteLine("Press any key to return to Main Menu");
            Console.ReadLine();
        }

        internal static void AddToHistory(int gameScore, GameType gameType, DifficultyOptions difficulty, TimeSpan duration)
        {
            games.Add(new Game
            {
                Date = DateTime.Now,
                Score = gameScore,
                Type = gameType,
                Difficulty = difficulty,
                Duration = duration
            });
        }
        internal static DifficultyOptions GetDifficultyOption()
        {
            DifficultyOptions difficultyOption = DifficultyOptions.None;
            do
            {
                Console.Clear();
                Console.WriteLine("----------------------------------------"); 
                Console.WriteLine(
                $@"Difficulty options:
                A - Easy
                B - Normal
                C - Hard");
                Console.WriteLine("----------------------------------------");

                string difficultySelected = Console.ReadLine();
                switch (difficultySelected.Trim().ToLower())
                {
                    case "a":
                        difficultyOption = DifficultyOptions.Easy;
                        break;
                    case "b":
                        difficultyOption = DifficultyOptions.Normal;
                        break;
                    case "c":
                        difficultyOption = DifficultyOptions.Hard;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            } while (difficultyOption == DifficultyOptions.None);

            return difficultyOption;
        }
        internal static int GetRandomNumber(DifficultyOptions difficulty)
        {
            var random = new Random();
            int number = 0;
            switch (difficulty)
            {
                case DifficultyOptions.Easy:
                    number = random.Next(0, 10);
                    break;
                case DifficultyOptions.Normal:
                    number = random.Next(10, 100);
                    break;
                case DifficultyOptions.Hard:
                    number = random.Next(100, 1000);
                    break;
            }
            return number;
        }
        internal static int[] GetDivisionNumbers(DifficultyOptions difficulty)
        {
            var random = new Random();
            var result = new int[2];
            int firstNumber;
            int secondNumber;
            switch (difficulty)
            {
                case DifficultyOptions.Easy:
                    firstNumber = random.Next(0, 10);
                    secondNumber = random.Next(1, 10);
                    while (firstNumber % secondNumber != 0)
                    {
                        firstNumber = random.Next(0, 10);
                        secondNumber = random.Next(1, 10);
                    }

                    result[0] = firstNumber;
                    result[1] = secondNumber;
                    break;
                case DifficultyOptions.Normal:
                    firstNumber = random.Next(10, 100);
                    secondNumber = random.Next(2, 11);
                    while (firstNumber % secondNumber != 0)
                    {
                        firstNumber = random.Next(10, 100);
                        secondNumber = random.Next(2, 11);
                    }

                    result[0] = firstNumber;
                    result[1] = secondNumber;
                    break;
                case DifficultyOptions.Hard:
                    firstNumber = random.Next(100, 1000);
                    secondNumber = random.Next(11, 100);
                    while (firstNumber % secondNumber != 0)
                    {
                        firstNumber = random.Next(100, 1000);
                        secondNumber = random.Next(11, 100);
                    }

                    result[0] = firstNumber;
                    result[1] = secondNumber;
                    break;
            }

            return result;
        }

        internal static string? ValidateResult(string result)
        {
            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
            {
                Console.WriteLine("Your answer needs to be an Integer. Try again.");
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
    }
}
