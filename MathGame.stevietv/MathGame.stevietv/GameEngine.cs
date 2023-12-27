using MathGame.stevietv.Models;

namespace MathGame.stevietv
{
    internal class GameEngine
    {
        internal void DivisionGame(string message)
        {
            int score = 0;

            Difficulty difficulty = Helpers.GetDifficulty();

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);

                var divisionNumbers = Helpers.GetDivisionNumbers(difficulty);
                var firstNumber = divisionNumbers[0];
                var secondNumber = divisionNumbers[1];

                Console.WriteLine($"{firstNumber} / {secondNumber}");

                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber / secondNumber)
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                    Console.ReadLine();
                }

                if (i == 4) Console.WriteLine($"Game Over. Your final score is {score}");
            }

            Helpers.AddToHistory(score, GameType.Division, difficulty);
        }

        internal void MultiplicationGame(string message)
        {
            var random = new Random();

            int firstNumber;
            int secondNumber;
            int score = 0;

            Difficulty difficulty = Helpers.GetDifficulty();

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine($"{message} - {difficulty}");
                firstNumber = Helpers.GetNumber(difficulty);
                secondNumber = Helpers.GetNumber(difficulty);

                Console.WriteLine($"{firstNumber} * {secondNumber}");

                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);


                if (int.Parse(result) == firstNumber * secondNumber)
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                    Console.ReadLine();
                }

                if (i == 4) Console.WriteLine($"Game Over. Your final score is {score}");
            }

            Helpers.AddToHistory(score, GameType.Multiplication, difficulty);
        }

        internal void SubtractionGame(string message)
        {
            var random = new Random();

            int firstNumber;
            int secondNumber;
            int score = 0;

            Difficulty difficulty = Helpers.GetDifficulty();

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine($"{message} - {difficulty}");
                firstNumber = Helpers.GetNumber(difficulty);
                secondNumber = Helpers.GetNumber(difficulty);

                Console.WriteLine($"{firstNumber} - {secondNumber}");

                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);


                if (int.Parse(result) == firstNumber - secondNumber)
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                    Console.ReadLine();
                }

                if (i == 4) Console.WriteLine($"Game Over. Your final score is {score}");
            }

            Helpers.AddToHistory(score, GameType.Subtraction, difficulty);
        }

        internal void AdditionGame(string message)
        {
            var random = new Random();

            int firstNumber;
            int secondNumber;
            int score = 0;

            Difficulty difficulty = Helpers.GetDifficulty();

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine($"{message} - {difficulty}");
                firstNumber = Helpers.GetNumber(difficulty);
                secondNumber = Helpers.GetNumber(difficulty);

                Console.WriteLine($"{firstNumber} + {secondNumber}");

                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber + secondNumber)
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                    Console.ReadLine();
                }

                if (i == 4)
                {
                    Console.WriteLine($"Game Over. Your final score is {score}");
                    Console.ReadLine();
                }
            }

            Helpers.AddToHistory(score, GameType.Addition, difficulty);
        }
    }
}
