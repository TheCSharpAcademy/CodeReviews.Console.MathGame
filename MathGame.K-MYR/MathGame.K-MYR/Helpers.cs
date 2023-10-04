using MathGame.K_MYR.Models;
using System;

namespace MathGame.K_MYR
{
    internal class Helpers
    {
        internal static List<Game> games = new();

        internal static void PrintGames()
        {
            Console.Clear();
            Console.WriteLine("Games History");
            Console.WriteLine("--------------------------------------------------------------------------");
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date} - {game.Duration:hh\\:mm\\:ss} | {game.Type} - {game.Difficulty} : {game.Score}");
            }
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("\nPress any key to return to Main Menu");
            Console.ReadLine();
        }

        internal static void AddToHistory(int gameScore, DifficultyMode difficulty, GameType gameType, TimeSpan gameDuration)
        {
            games.Add(new Game
            {
                Score = gameScore,
                Difficulty = difficulty,
                Date = DateTime.Now,
                Type = gameType,
                Duration = gameDuration
            });
        }

        internal static int[] GetDivisionNumbers(DifficultyMode difficulty)
        {
            Random random = new();
            var result = new int[2];
            int upperLimit = 0;

            switch (difficulty)
            {
                case DifficultyMode.Hard:
                    upperLimit = 200;
                    break;
                case DifficultyMode.Medium:
                    upperLimit = 100;
                    break;
                case DifficultyMode.Easy:
                    upperLimit = 50;
                    break;
            }

            int firstNumber = random.Next(21, upperLimit);
            int secondNumber = random.Next(2, 20);

            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(21, upperLimit);
                secondNumber = random.Next(2, 20);
            }

            result[0] = firstNumber;
            result[1] = secondNumber;

            return result;
        }

        internal static string? ValidateResult(string result)
        {
            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
            {
                Console.WriteLine("Your answer need to be an integer. Try again.");
                result = Console.ReadLine();
            }
            return result;
        }

        internal static string GetName()
        {
            Console.WriteLine("Please type your name");
            string? name = Console.ReadLine();

            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name can't be empty");
                name = Console.ReadLine();
            }
            return name;
        }

        internal static int GetNumberOfGames()
        {
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("How many games do you want play?");
            Console.WriteLine("--------------------------------------------------------------------------");

            string? NumberOfGamesString = Console.ReadLine();
            int NumberOfGames;

            while (string.IsNullOrEmpty(NumberOfGamesString) || !Int32.TryParse(NumberOfGamesString, out NumberOfGames))
            {
                Console.WriteLine("Your answer need to be an integer. Try again.");
                NumberOfGamesString = Console.ReadLine();
            }
            return NumberOfGames;
        }

        internal static TimeSpan GetGameDuration(DateTime startDate)
        {
            TimeSpan gameDuration = (DateTime.UtcNow - startDate);
            return gameDuration;
        }

        internal static DifficultyMode GetDifficulty()
        {
            bool invalidInput = true;
            DifficultyMode difficulty = new();
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("Choose the difficutly:");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("H - Hard");
            Console.WriteLine("M - Medium");
            Console.WriteLine("E - Easy");
            Console.WriteLine("--------------------------------------------------------------------------");            

            while (invalidInput)
            {
                var readResult = Console.ReadLine();

                switch (readResult.Trim().ToLower())
                {
                    case "h":
                        invalidInput = false;
                        difficulty = DifficultyMode.Hard;
                        break;
                    case "m":
                        invalidInput = false;
                        difficulty = DifficultyMode.Medium;
                        break;
                    case "e":
                        invalidInput = false;
                        difficulty = DifficultyMode.Easy;
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }
            }
            Console.WriteLine("Press enter to start the game");

            return difficulty;
        }
    }
}
