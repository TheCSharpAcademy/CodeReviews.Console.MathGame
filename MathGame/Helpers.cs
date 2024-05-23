using MathGame.Models;
using System.Reflection.Metadata.Ecma335;
using static System.Formats.Asn1.AsnWriter;

namespace MathGame
{
    internal class Helpers
    {
        internal static string? GetName()
        {
            Console.WriteLine("Please type your name");
            var name = Console.ReadLine();

            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name can't be empty.");
                name = Console.ReadLine();
            }

            return name;
        }

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

        internal static string SetDifficulty()
        {
            bool invalidKey = true;
            string difficulty = "Easy";

            Console.Clear();

            Console.WriteLine(@$"Select the difficulty level:
E - Easy
M - Medium
H - Hard");
            var difficultySelected = Console.ReadLine().ToLower().Trim();

            while (invalidKey)
            {
                invalidKey = false;

                switch (difficultySelected)
                {
                    case "e":
                        difficulty = "Easy";
                        break;
                    case "m":
                        difficulty = "Medium";
                        break;
                    case "h":
                        difficulty = "Hard";
                        break;
                    default:
                        invalidKey = true;
                        Console.WriteLine("Invalid Input. You must choose an option from the list.");
                        difficultySelected = Console.ReadLine().ToLower().Trim();
                        break;
                }
            }

            return difficulty;
        }

        internal static int[] GetDivisionNumbers(string difficulty)
        {
            var random = new Random();
            var result = new int[2];
            
            if (difficulty == "Easy")
            {
                var firstNumber = random.Next(0, 99);
                var secondNumber = random.Next(0, 99);

                while (firstNumber % secondNumber != 0)
                {
                    firstNumber = random.Next(1, 99);
                    secondNumber = random.Next(1, 99);
                }

                result[0] = firstNumber;
                result[1] = secondNumber;
            }
            if (difficulty == "Medium")
            {
                var firstNumber = random.Next(0, 149);
                var secondNumber = random.Next(0, 149);

                while (firstNumber % secondNumber != 0)
                {
                    firstNumber = random.Next(1, 149);
                    secondNumber = random.Next(1, 149);
                }

                result[0] = firstNumber;
                result[1] = secondNumber;
            }
            else if (difficulty == "Hard")
            {
                var firstNumber = random.Next(0, 199);
                var secondNumber = random.Next(0, 199);

                while (firstNumber % secondNumber != 0)
                {
                    firstNumber = random.Next(1, 199);
                    secondNumber = random.Next(1, 199);
                }

                result[0] = firstNumber;
                result[1] = secondNumber;
            }

            return result;
        }

        internal static void AddToHistory(int gameScore, string difficulty, int questions, GameType gameType)
        {
            games.Add(new Game
            {
                Date = DateTime.Now,
                Score = gameScore,
                Type = gameType,
                GameDifficulty = difficulty,
                Questions = questions,
            });
        }

        internal static int NumberOfQuestions()
        {
            Console.Clear();
            Console.WriteLine("Enter number of questions to play: ");
            string? input = Console.ReadLine();
            ValidateResult(input);

            int questions = Convert.ToInt32(input);

            return questions;
        }

        internal static void GameOver(int i, int questions, int gameScore)
        {
            if (i == questions - 1)
            {
                Console.WriteLine($"Game over. Your final score is {gameScore}.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
                Console.Clear();
            }
        }

        internal static void PrintGames()
        {
            Console.Clear();
            Console.WriteLine(@"Select which game history you'd like to view. Choose from the options below:
A - Addition
S - Subtraction
M - Multiplication
D - Division");
            var gameSelected = Console.ReadLine().ToLower().Trim();
            var gamesToPrint = games.Where(x => x.Type == GameType.Addition);
            bool invalidKey = true;

            while (invalidKey)
            {
                invalidKey = false;

                switch (gameSelected)
                {
                    case "a":
                        gamesToPrint = games.Where(x => x.Type == GameType.Addition);
                        break;
                    case "s":
                        gamesToPrint = games.Where(x => x.Type == GameType.Subtraction);
                        break;
                    case "m":
                        gamesToPrint = games.Where(x => x.Type == GameType.Multiplication);
                        break;
                    case "d":
                        gamesToPrint = games.Where(x => x.Type == GameType.Division);
                        break;
                    default:
                        invalidKey = true;
                        Console.WriteLine("Invalid Input. Please select an option from the list.");
                        gameSelected = Console.ReadLine().ToLower().Trim();
                        break;
                }
            }

            Console.Clear();
            Console.WriteLine("Games History");
            Console.WriteLine("--------------------------------------------------");
            foreach (var game in gamesToPrint)
            {
                Console.WriteLine($"{game.Date} | {game.GameDifficulty} - {game.Type} | Questions Asked: {game.Questions}    Score: {game.Score}pts");
            }
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadLine();
        }

        internal static string? ValidateResult(string result)
        {
            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
            {
                Console.WriteLine("Your answer must be an integer. Try again.");
                result = Console.ReadLine();
            }

            return result;
        }
    }
}
