using MyFirstProgram.Models;
using System.Linq;

namespace MyFirstProgram
{
    internal class Helpers
    {
        internal static List<Game> games = new List<Game>();

        internal static void GetGames()
        {
            // var gamesToPrint = games.Where(x => x.Date > new DateTime(2023, 11, 24) && x.Score > 3).OrderByDescending(x => x.Score);
            Console.Clear();
            Console.WriteLine("Games History:");
            Console.WriteLine("--------------------\n");

            foreach (var game in games)
            {
                Console.WriteLine(game.ToString());
            }
            Console.WriteLine("--------------------\n");

            Console.WriteLine("Enter any key to continue.");
            Console.ReadLine();
        }

        internal static int[] GetDivisionNumbers(string difficulty)
        {
            int number1;
            int number2;

            var random = new Random();

            do
            {
                int min = Helpers.GetMin(difficulty);

                int max = Helpers.GetMax(difficulty);

                number1 = random.Next(min, max);
                number2 = random.Next(min, max);
            } while (number1 % number2 != 0 || number1 == number2);

            int[] numbers = { number1, number2 };

            return numbers;
        }

        internal static void AddToHistory(int score, GameType gameType, double totalSeconds)
        {
            games.Add(new Game
            {
                Date = DateTime.Now,
                Score = score,
                Type = gameType,
                TotalSeconds = totalSeconds
            });
        }

        internal static string ValidateResult(string input)
        {
            while (string.IsNullOrEmpty(input) || !int.TryParse(input, out _))
            {
                Console.WriteLine("Your answer needs to be an integer. Try again.");
                input = Console.ReadLine();
            }

            return input;
        }

        internal static string GetName()
        {
            Console.WriteLine("Please enter your name:");

            var name = Console.ReadLine();

            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name can't be empty.");
                name = Console.ReadLine();
            }
            return name;
        }

        internal static string GetDifficulty()
        {
            Console.WriteLine("What level of difficulty do you want to play? Enter 'easy', 'medium' or 'hard' to answer.");
            var difficulty = Console.ReadLine().Trim().ToLower();

            while (string.IsNullOrEmpty(difficulty) || (difficulty != "easy" && difficulty != "medium" && difficulty != "hard"))
            {
                Console.WriteLine("Invalid input. Please try again.");
                difficulty = Console.ReadLine().Trim().ToLower();
            }

            Console.Write($"You chose {difficulty} difficulty.\nEnter any key to continue.");
            Console.ReadLine();

            return difficulty;
        }

        internal static int GetMin(string difficulty)
        {
            int min = difficulty == "easy" ? 1 :
                difficulty == "medium" ? 10 : 100;

            return min;
        }

        internal static int GetMax(string difficulty)
        {
            int max = difficulty == "easy" ? 10 :
                difficulty == "medium" ? 100 : 1000;

            return max;
        }

        internal static int GetNumberOfQuestions()
        {
            Console.Clear();
            Console.WriteLine("Enter the number of questions you want to do.");

            int numQuestions;

            while (!int.TryParse(Console.ReadLine(), out numQuestions))
            {
                Console.WriteLine("Please enter a valid integer.");
            }

            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
            return numQuestions;
        }

        internal static string[] GetRandomMathQuestion(int min, int max, string difficulty)
        {
            string[] operators = { "+", "-", "*", "/" };

            var random = new Random();

            var operatorsIndex = random.Next(operators.Length);

            var firstNumber = random.Next(min, max).ToString();
            var secondNumber = random.Next(min, max).ToString();

            var operand = operators[operatorsIndex];

            if (operand == "/")
            {
                int[] numbers = Helpers.GetDivisionNumbers(difficulty);
                firstNumber = numbers[0].ToString();
                secondNumber = numbers[1].ToString();
            }

            string[] statement = { firstNumber, operand, secondNumber };

            return statement;
        }
    }
}