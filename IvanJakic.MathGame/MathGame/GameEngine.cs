
using MathGame.Models;

namespace MathGame
{
    internal class GameEngine
    {
        internal void AdditionGame(string message)
        {
            var random = new Random();

            int firstNumber;
            int secondNumber;
            var score = 0;
            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);
                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);

                Console.WriteLine($"{firstNumber} + {secondNumber}");
                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                string res = int.Parse(result) == firstNumber + secondNumber ? $"Your answer was correct!\nScore: {++score}" +
                    $"\nType any key for next question." : "Your answer was incorrect. Type any key for next question.";
                Console.WriteLine(res);
                Console.ReadLine();
            }
            Helpers.AddToHistory(score, GameType.Addition);
            Console.WriteLine($"\nGame over.\nFinal score: {score}\nPress any key to continue...");
            Console.ReadLine();
        }

        internal void SubtractionGame(string message)
        {
            var random = new Random();

            int firstNumber;
            int secondNumber;
            var score = 0;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);
                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);

                Console.WriteLine($"{firstNumber} - {secondNumber}");
                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                string res = int.Parse(result) == firstNumber - secondNumber ? $"Your answer was correct!\nScore: {++score}" +
                    $"\nType any key for next question." : "Your answer was incorrect. Type any key for next question.";
                Console.WriteLine(res);
                Console.ReadLine();
            }
            Helpers.AddToHistory(score, GameType.Subtraction);
            Console.WriteLine($"\nGame over.\nFinal score: {score}\nPress any key to continue...");
        }

        internal void MultiplicationGame(string message)
        {
            var random = new Random();

            int firstNumber;
            int secondNumber;
            var score = 0;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);
                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);

                Console.WriteLine($"{firstNumber} * {secondNumber}");
                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);
                string res = int.Parse(result) == firstNumber * secondNumber ? $"Your answer was correct!\nScore: {++score}" +
                    $"\nType any key for next question." : "Your answer was incorrect. Type any key for next question.";
                Console.WriteLine(res);
                Console.ReadLine();
            }
            Helpers.AddToHistory(score, GameType.Multiplication);
            Console.WriteLine($"\nGame over.\nFinal score: {score}\nPress any key to continue...");
        }

        internal void DivisionGame(string message)
        {
            int score = 0;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);

                var divisionNumbers = Helpers.GetDivisionNumbers();
                var firstNumber = divisionNumbers[0];
                var secondNumber = divisionNumbers[1];
                
                Console.WriteLine($"{firstNumber} / {secondNumber}");
                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);
                string res = int.Parse(result) == firstNumber / secondNumber ? $"Your answer was correct!\nScore: {++score}" +
                    $"\nType any key for next question." : "Your answer was incorrect. Type any key for next question.";
                Console.WriteLine(res);
                Console.ReadLine();

            }
            Helpers.AddToHistory(score, GameType.Division);
            Console.WriteLine($"\nGame over.\nFinal score: {score}\nPress any key to continue...");
        }
    }
}
