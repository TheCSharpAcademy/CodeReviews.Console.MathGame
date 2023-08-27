using MathGameConsole.Models;

namespace MathGameConsole
{
    internal class Helpers
    {
        internal static int DifficultyMultiplier()
        {
            string userDifficultySelection;
            int difficulty = 1;

            bool correctSelection = true;

            while (correctSelection)
            {
                Console.Clear();
                Console.WriteLine("----------------------------------");
                Console.WriteLine($@"Please select a difficulty:
    (E)asy
    (M)edium
    (H)ard");
                Console.WriteLine("----------------------------------");
                userDifficultySelection = Console.ReadLine();

                switch (userDifficultySelection!.ToLower())
                {
                    case "e":
                        correctSelection = false;
                        difficulty = 1;
                        break;
                    case "m":
                        correctSelection = false;
                        difficulty = 10;
                        break;
                    case "h":
                        correctSelection = false;
                        difficulty = 100;
                        break;
                    default:
                        Console.WriteLine($"Your difficulty is not available, please select again.");
                        break;
                }
            }
            return difficulty;
        }

        internal static int totalQuestions()
        {
            string noOfQuestions;

            Console.WriteLine("----------------------------------");
            Console.WriteLine("How many questions would you like to answer?");
            noOfQuestions = Console.ReadLine();
            noOfQuestions = ValidateResult(noOfQuestions);

            return int.Parse(noOfQuestions);
        }       

        //static string name;
        internal static int[] GetDivisionNumbers()
        {
            var random = new Random();
            var firstNumber = random.Next(1, 99);
            var secondNumber = random.Next(1, 99);

            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(1, 99);
                secondNumber = random.Next(1, 99);
            }

            var result = new int[2];

            result[0] = firstNumber;
            result[1] = secondNumber;

            return result;
        }

        internal static List<Game> games = new List<Game>
        {
        };
        internal static void AddToHistory(int noOfQuestions, int gameScore, GameType gameType, string gameTime)
        {
            // This creates an entry using the "Game" type in Models.
            games.Add(new Game
            {
                Date = DateTime.Now,
                Score = gameScore,
                Type = gameType,
                TotalQuestions = noOfQuestions,
                GameTime = gameTime
            }); ;
        }
        internal static void PrintGames()
        {
            Console.WriteLine("Games History:");
            Console.WriteLine("----------------------------------");
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date} - {game.Type}|No. of Questions: {game.TotalQuestions}|Score: {game.Score}pts|Time: {game.GameTime} seconds");
            }
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Press any key to return to the game menu.");
            Console.ReadLine();
        }

        // Checks to make sure the answer to any game is an integer and is not null.
        // This function is also utilised for checking that the number of questions selected is an int.
        // The "string?" allows the string to be nullable
        internal static string? ValidateResult(string result)
        {


            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _)) // _ is a throwaway variable
            {
                Console.WriteLine("Your answer needs to be an integer, Try again!");
                result = Console.ReadLine();
            }
            return result;
        }

        internal static string GetName()
        {

            Console.WriteLine("Welcome to the Math Game.\nPlease enter your name:\n");

            string name = Console.ReadLine();
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("You must select a name! Try again!");
                name = Console.ReadLine();
            }
            return name;
        }

        // Provides the amount of time taken to complete a game
        internal static String GameTime(DateTime startTime, int score, int noOfQuestions)
        {
            DateTime finishTime = DateTime.Now;
            TimeSpan interval = finishTime - startTime;
            Console.WriteLine($"Your final score is: {score} / {noOfQuestions}. It took you " + interval.Seconds + "." + interval.Milliseconds / 10 + " seconds\n");
            Console.WriteLine("Press any key to return to the main Menu.");

            return (interval.Seconds + "." + interval.Milliseconds / 10);
        }

    }
}
