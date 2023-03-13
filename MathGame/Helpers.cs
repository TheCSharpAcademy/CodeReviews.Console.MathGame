using System.Linq;
using MathGame.Models;

namespace MathGame
{
    internal class Helpers
    {

        internal  static List<Game> games = new();

        internal static void PrintGames()
        {

            Console.Clear();
            Console.WriteLine("Games History");
            Console.WriteLine("---------------------");

            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date} - {game.Type}:({game.Difficulty} Mode) {game.Score} pts {game.NumberOfQuestions} questions {game.TimeToFinsh} seconds");
            }
            Console.WriteLine("--------------------\n");
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }

        internal static int Questions()
        {
            Console.WriteLine("How many questions would you like to have?");
            var questions = Console.ReadLine();
            questions = ValidateResult(questions);
            int numberOfQuestions = int.Parse(questions);
            return numberOfQuestions;
        }
        internal static int [] GetDivisionNumbers(DifficultyLevel difficulty)
        {
            var random = new Random();
            int [] result = new int [2];
            int firstNumber;
            int secondNumber;

            if (difficulty == DifficultyLevel.Easy)
            {
                firstNumber = random.Next(1, 100);
                secondNumber = random.Next(1, 10);
            }
            else if(difficulty == DifficultyLevel.Medium)
            {
                firstNumber = random.Next(10, 900);
                secondNumber = random.Next(10, 100);
            }
            else
            {
                firstNumber = random.Next(100, 10000);
                secondNumber = random.Next(100, 500);
            }


            while (firstNumber % secondNumber != 0)
            {
                if (difficulty == DifficultyLevel.Easy)
                {
                    firstNumber = random.Next(1, 100);
                    secondNumber = random.Next(1, 10);
                }
                else if (difficulty == DifficultyLevel.Medium)
                {
                    firstNumber = random.Next(10, 900);
                    secondNumber = random.Next(10, 100);
                }
                else
                {
                    firstNumber = random.Next(100, 10000);
                    secondNumber = random.Next(100, 500);
                }
            }

            result [0] = firstNumber;
            result [1] = secondNumber;

            return result;
        }

        internal static int [] GetSubtractionNumbers(DifficultyLevel difficulty)
        {
            var random = new Random();
            int [] result = new int [2];
            int firstNumber;
            int secondNumber;

            if (difficulty == DifficultyLevel.Easy)
            {
                 firstNumber = random.Next(1, 10);
                 secondNumber = random.Next(1, 10);
            }
            else if (difficulty == DifficultyLevel.Medium)
            {
                 firstNumber = random.Next(10, 100);
                 secondNumber = random.Next(10, 50);
            }
            else
            {
                 firstNumber = random.Next(1000, 10000);
                 secondNumber = random.Next(100, 9000);
            }

            while (firstNumber < secondNumber)
            {

                if (difficulty == DifficultyLevel.Easy)
                {
                    firstNumber = random.Next(1, 10);
                    secondNumber = random.Next(1, 10);
                }
                else if (difficulty == DifficultyLevel.Medium)
                {
                    firstNumber = random.Next(10, 100);
                    secondNumber = random.Next(10, 50);
                }
                else
                {
                    firstNumber = random.Next(1000, 10000);
                    secondNumber = random.Next(100, 9000);
                }
            }

            result [0] = firstNumber;
            result [1] = secondNumber;

            return result;
        }

        internal static void AddToHistory(int score, GameType game, DifficultyLevel difficultyLevel, int seconds, int questions)
        {
            games.Add(new Game
            {
                Date = DateTime.Now,
                Score = score,
                Type = game,
                Difficulty = difficultyLevel,
                TimeToFinsh = seconds,
                NumberOfQuestions = questions
            }) ; ;
        }

        internal static string ValidateResult(string guess)
        {
            while (string.IsNullOrEmpty(guess) || !Int32.TryParse(guess, out _))
            {
                Console.WriteLine("Your answer needs to be a whole number. Please try again");
                guess = Console.ReadLine();
            }
            return (guess);
        }
        internal static string GetName()
        {
            Console.WriteLine("Please type your name: ");

            var name = Console.ReadLine();

                while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Please enter a name.");
                name = Console.ReadLine();
            }
            return name;
        }
    }
}


