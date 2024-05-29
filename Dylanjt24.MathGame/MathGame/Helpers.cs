using MathGame.Models;
using System.Timers;

namespace MathGame
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
        private static System.Timers.Timer mathTimer;

        // Get and show scores of previous games
        internal static void PrintGames()
        {
            // LINQ Query examples:
            //var gamesToPrint = games.Where(x => x.Type == GameType.Division);
            //var gamesToPrint = games.Where(x => x.Date > new DateTime(2024, 02, 10) && x.Score > 3);
            //var gamesToPrint = games.Where(x => x.Date > new DateTime(2024, 02, 10)).OrderByDescending(x => x.Score);

            Console.Clear();
            Console.WriteLine("Games History");
            Console.WriteLine("------------------------------------------");
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date} - {game.Type} - {game.Difficulty}: {game.Score} pts in {game.SecondsTaken} seconds");
            }
            Console.WriteLine("------------------------------------------\n");
            Console.WriteLine("Press enter to return to the main menu.");
            Console.ReadLine();
        }

        // Add the datetime, game type, score, and difficulty to game history list so user can view later
        internal static void AddToHistory(int score, GameType gameType, GameDifficulty difficulty, int secondsTaken)
        {
            games.Add(new Game
            {
                Date = DateTime.Now,
                Score = score,
                Type = gameType,
                Difficulty = difficulty,
                SecondsTaken = secondsTaken
            });
        }

        // Get numbers for division game
        // Use parameters so they can be passed by ChooseDifficulty
        internal static int[] GetDivisionNumbers(int minNum, int maxNum)
        {
            var random = new Random();
            var firstNumber = random.Next(minNum, maxNum);
            var secondNumber = random.Next(minNum, maxNum);

            // Generate numbers until they are evenly divisible
            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(minNum, maxNum);
                secondNumber = random.Next(minNum, maxNum);
            }
            int[] result = { firstNumber, secondNumber };

            return result;
        }

        internal static void Quit()
        {
            Console.WriteLine("See ya later!");
        }

        internal static string? ValidateResult(string result)
        {
            // Repeat readline if initial result was empty, or if it wasn't an integer
            // Using _ since I don't need an output
            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
            {
                Console.WriteLine("Your answer needs to be an integer. Try again.");
                result = Console.ReadLine();
            }
            return result;
        }

        internal static string GetName()
        {
            Console.WriteLine("Please type your name:");
            var name = Console.ReadLine();

            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name can't be empty.");
                name = Console.ReadLine();
            }

            return name;
        }

        internal static int[] ChooseDifficulty()
        {
            Console.Clear();
            var mathNums = new int[3];
            var diffSelected = false;
            do
            {
                Console.WriteLine(@"Choose a difficulty:
    E - Easy
    M - Medium
    H - Hard
------------------------------------------");
                var difficulty = Console.ReadLine();
                mathNums[0] = 1;

                // Set math number range based on difficulty selected
                switch (difficulty.Trim().ToLower())
                {
                    case "e":
                        mathNums[1] = 10;
                        // Save number that corresponds to the difficulty enum
                        mathNums[2] = 0;
                        // Break out of the while loop
                        diffSelected = true;
                        break;
                    case "m":
                        mathNums[1] = 50;
                        mathNums[2] = 1;
                        diffSelected = true;
                        break;
                    case "h":
                        mathNums[1] = 100;
                        mathNums[2] = 2;
                        diffSelected = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid input.\n");
                        break;
                }
                // Continue asking until they enter a valid input
            } while (diffSelected == false);
            return mathNums;
        }

        internal static int NumOfQuestions()
        {
            Console.Clear();
            Console.WriteLine("How many questions would you like to do?");
            var amount = Console.ReadLine();
            while (string.IsNullOrEmpty(amount) || !Int32.TryParse(amount, out _))
            {
                Console.WriteLine("Your answer must be an integer. Try again:");
                amount = Console.ReadLine();
            }
            return int.Parse(amount);
        }
    }
}
