using MyFirstProgram.Models;
using System.Diagnostics;

namespace MyFirstProgram
{
    internal class GameEngine
    {

        internal void AdditionGame(string difficulty)
        {
            var random = new Random();

            int firstNumber;
            int secondNumber;

            int min = Helpers.GetMin(difficulty);

            int max = Helpers.GetMax(difficulty);

            var score = 0;

            var numQuestions = Helpers.GetNumberOfQuestions();

            var stopwatch = new Stopwatch();

            stopwatch.Start();

            for (int i = 0; i < numQuestions; i++)
            {
                Console.Clear();

                firstNumber = random.Next(min, max);
                secondNumber = random.Next(min, max);

                Console.WriteLine($"{firstNumber} + {secondNumber}");

                var input = Console.ReadLine();
                input = Helpers.ValidateResult(input);

                if (int.Parse(input) == firstNumber + secondNumber)
                {
                    Console.WriteLine("Your answer was correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect.");
                }

                Console.WriteLine("Enter any key to continue.");
                Console.ReadLine();
            }

            stopwatch.Stop();

            var totalElapsedTime = Math.Round(stopwatch.Elapsed.TotalSeconds, 1);

            Helpers.AddToHistory(score, GameType.Addition, totalElapsedTime);

            Console.WriteLine($"Game over. Score: {score}");
            Console.WriteLine("Enter any key to continue.");
            Console.ReadLine();
        }

        internal void SubtractionGame(string difficulty)
        {
            var random = new Random();

            int firstNumber;
            int secondNumber;

            int min = Helpers.GetMin(difficulty);

            int max = Helpers.GetMax(difficulty);

            var numQuestions = Helpers.GetNumberOfQuestions();


            var score = 0;

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < numQuestions; i++)
            {
                Console.Clear();

                firstNumber = random.Next(min, max);
                secondNumber = random.Next(min, max);

                Console.WriteLine($"{firstNumber} - {secondNumber}");

                var input = Console.ReadLine();
                input = Helpers.ValidateResult(input);

                if (int.Parse(input) == firstNumber - secondNumber)
                {
                    Console.WriteLine("Your answer was correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect.");
                }

                Console.WriteLine("Enter any key to continue.");
                Console.ReadLine();
            }

            stopwatch.Stop();

            var totalElapsedTime = Math.Round(stopwatch.Elapsed.TotalSeconds, 1);

            Helpers.AddToHistory(score, GameType.Subtraction, totalElapsedTime);
            Console.WriteLine($"Game over. Score: {score}");
            Console.WriteLine("Enter any key to continue.");
            Console.ReadLine();
        }

        internal void MultiplicationGame(string difficulty)
        {
            var random = new Random();

            int firstNumber;
            int secondNumber;

            int min = Helpers.GetMin(difficulty);

            int max = Helpers.GetMax(difficulty);

            var numQuestions = Helpers.GetNumberOfQuestions();

            var score = 0;

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < numQuestions; i++)
            {
                Console.Clear();

                firstNumber = random.Next(min, max);
                secondNumber = random.Next(min, max);

                Console.WriteLine($"{firstNumber} * {secondNumber}");

                var input = Console.ReadLine();
                input = Helpers.ValidateResult(input);

                while (string.IsNullOrEmpty(input) || !int.TryParse(input, out _))
                {
                    Console.WriteLine("Your answer needs to be an integer. Try again.");
                    input = Console.ReadLine();
                }

                if (int.Parse(input) == firstNumber * secondNumber)
                {
                    Console.WriteLine("Your answer was correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect.");
                }

                Console.WriteLine("Enter any key to continue.");
                Console.ReadLine();
            }

            stopwatch.Stop();
            var totalElapsedTime = Math.Round(stopwatch.Elapsed.TotalSeconds, 1);

            Helpers.AddToHistory(score, GameType.Multiplication, totalElapsedTime);
            Console.WriteLine($"Game over. Score: {score}");
            Console.WriteLine("Enter any key to continue.");
            Console.ReadLine();
        }

        internal void DivisionGame(string difficulty)
        {
            var random = new Random();

            int firstNumber;
            int secondNumber;

            var score = 0;
            var numQuestions = Helpers.GetNumberOfQuestions();


            var stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < numQuestions; i++)
            {
                Console.Clear();

                int[] numbers = Helpers.GetDivisionNumbers(difficulty);

                firstNumber = numbers[0];
                secondNumber = numbers[1];

                Console.WriteLine($"{firstNumber} / {secondNumber}");

                var input = Console.ReadLine();
                input = Helpers.ValidateResult(input);

                while (string.IsNullOrEmpty(input) || !int.TryParse(input, out _))
                {
                    Console.WriteLine("Your answer needs to be an integer. Try again.");
                    input = Console.ReadLine();
                }

                if (int.Parse(input) == firstNumber / secondNumber)
                {
                    Console.WriteLine("Your answer was correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect.");
                }

                Console.WriteLine("Enter any key to continue.");
                Console.ReadLine();
            }
            stopwatch.Stop();
            var totalElapsedTime = Math.Round(stopwatch.Elapsed.TotalSeconds, 1);

            Helpers.AddToHistory(score, GameType.Division, totalElapsedTime);
            Console.WriteLine($"Game over. Score: {score}");
            Console.WriteLine("Enter any key to continue.");
            Console.ReadLine();
        }

        internal void RandomGame(string difficulty)
        {
            var random = new Random();

            int firstNumber;
            int secondNumber;

            int min = Helpers.GetMin(difficulty);

            int max = Helpers.GetMax(difficulty);

            var numQuestions = Helpers.GetNumberOfQuestions();

            var score = 0;

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < numQuestions; i++)
            {
                Console.Clear();

                string[] mathStatement = Helpers.GetRandomMathQuestion(min, max, difficulty);

                firstNumber = int.Parse(mathStatement[0]);
                secondNumber = int.Parse(mathStatement[2]);

                Console.WriteLine($"{firstNumber} {mathStatement[1]} {secondNumber}");

                var input = Console.ReadLine();
                input = Helpers.ValidateResult(input);

                var operand = mathStatement[1];

                int correctAnswer = 0;

                switch (operand)
                {
                    case "+":
                        correctAnswer = firstNumber + secondNumber;
                        break;
                    case "-":
                        correctAnswer = firstNumber - secondNumber;
                        break;
                    case "*":
                        correctAnswer = firstNumber * secondNumber;
                        break;
                    case "/":
                        correctAnswer = firstNumber / secondNumber;
                        break;
                }

                if (int.Parse(input) == correctAnswer)
                {
                    Console.WriteLine("Your answer was correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect.");
                }

                Console.WriteLine("Enter any key to continue.");
                Console.ReadLine();
            }

            stopwatch.Stop();
            var totalElapsedTime = Math.Round(stopwatch.Elapsed.TotalSeconds, 1);

            Helpers.AddToHistory(score, GameType.Random, totalElapsedTime);
            Console.WriteLine($"Game over. Score: {score}");
            Console.WriteLine("Enter any key to continue.");
            Console.ReadLine();
        }

    }
}
