using MathGame.DzemalKurtic.Models;

namespace MathGame.DzemalKurtic
{
    internal class GameEngine
    {
        internal void DivisionGame(string message)
        {
            var score = 0;

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

                if (int.Parse(result) == firstNumber / secondNumber)
                {
                    Console.WriteLine("You answer was correct! Type any key for the next question");
                    Console.ReadLine();
                    score++;
                }
                else
                {
                    Console.WriteLine("Your anwser was incorrect! Type any key for the next question");
                    Console.ReadLine();
                }

                if (i == 4)
                {
                    Console.WriteLine($"Game over. Your final score is {score}. Press any key to go back to the menu.");
                    Console.ReadLine();
                }
            }
            Helpers.AddToHistory(score, GameType.Division);
        }

        internal void MultiplicationGame(string message)
        {
            Console.WriteLine(message);

            var random = new Random();
            var score = 0;
            int firstNumber;
            int secondNumber;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);

                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);
                Console.WriteLine($"{firstNumber} * {secondNumber}");

                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber * secondNumber)
                {
                    Console.WriteLine("You answer was correct! Type any key for the next question");
                    Console.ReadLine();
                    score++;
                }
                else
                {
                    Console.WriteLine("Your anwser was incorrect! Type any key for the next question");
                    Console.ReadLine();
                }

                if (i == 4)
                {
                    Console.WriteLine($"Game over. Your final score is {score}. Press any key to go back to the menu.");
                    Console.ReadLine();
                }
            }
            Helpers.AddToHistory(score, GameType.Multiplication);
        }

        internal void SubtractionGame(string message)
        {
            Console.WriteLine(message);

            var random = new Random();
            var score = 0;
            int firstNumber;
            int secondNumber;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);

                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);
                Console.WriteLine($"{firstNumber} - {secondNumber}");

                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber - secondNumber)
                {
                    Console.WriteLine("You answer was correct! Type any key for the next question");
                    Console.ReadLine();
                    score++;
                }
                else
                {
                    Console.WriteLine("Your anwser was incorrect! Type any key for the next question");
                    Console.ReadLine();
                }

                if (i == 4)
                {
                    Console.WriteLine($"Game over. Your final score is {score}. Press any key to go back to the menu.");
                    Console.ReadLine();
                }
            }

            Helpers.AddToHistory(score, GameType.Subtraction);
        }

        internal void AdditionGame(string message)
        {
            Console.WriteLine(message);

            var random = new Random();
            var score = 0;
            int firstNumber;
            int secondNumber;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);

                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);
                Console.WriteLine($"{firstNumber} + {secondNumber}");

                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber + secondNumber)
                {
                    Console.WriteLine("You answer was correct! Type any key for the next question");
                    Console.ReadLine();
                    score++;
                }
                else
                {
                    Console.WriteLine("Your anwser was incorrect! Type any key for the next question");
                    Console.ReadLine();
                }

                if (i == 4)
                {
                    Console.WriteLine($"Game over. Your final score is {score}. Press any key to go back to the menu.");
                    Console.ReadLine();
                }
            }

            Helpers.AddToHistory(score, GameType.Addition);
        }
    }
}
