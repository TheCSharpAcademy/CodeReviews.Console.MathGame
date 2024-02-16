using System;
using AdityaVaidya.MathGame.Models;

namespace AdityaVaidya.MathGame
{
    internal class GameEngine
    {
        internal static void AdditionGame(string message)
        {
            int score = 0;
            Console.WriteLine(message);
            var random = new Random();
            int firstNumber, secondNumber;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);
                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);
                Console.WriteLine($"{firstNumber} + {secondNumber}");

                int validInput = Helpers.ValidateInput();
               
                if (validInput == firstNumber + secondNumber)
                {
                    Console.WriteLine("Your answer is correct.Type any key for next question");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was wrong. Type any key for next question");
                    Console.ReadLine();
                }
                if (i == 4) Helpers.PublishScore(score);

            }
            Helpers.AddToHistory(score, Models.GameType.Addition);
        }

        internal static void SubstractionGame(string message)
        {
            int score = 0;
            Console.WriteLine(message);
            var random = new Random();
            int firstNumber, secondNumber;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);
                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);
                Console.WriteLine($"{firstNumber} - {secondNumber}");
                int validInput = Helpers.ValidateInput();

                if (validInput == firstNumber - secondNumber)
                {
                    Console.WriteLine("Your answer is correct.Type any key for next question");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was wrong. Type any key for next question");
                    Console.ReadLine();
                }
                if (i == 4)Helpers.PublishScore(score);
            }
            Helpers.AddToHistory(score, GameType.Substraction);
        }

        internal static void MultiplicationGame(string message)
        {
            int score = 0;
            Console.WriteLine(message);
            var random = new Random();
            int firstNumber, secondNumber;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);
                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);
                Console.WriteLine($"{firstNumber} * {secondNumber}");
                int validInput = Helpers.ValidateInput();

                if (validInput == firstNumber * secondNumber)
                {
                    Console.WriteLine("Your answer is correct.Type any key for next question");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was wrong. Type any key for next question");
                    Console.ReadLine();
                }
                if (i == 4) Helpers.PublishScore(score);
            }
            Helpers.AddToHistory(score, GameType.Multiplication);

        }

        internal static void DivisionGame(string message)
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
                int validInput = Helpers.ValidateInput();

                if (validInput == firstNumber / secondNumber)
                {
                    Console.WriteLine("Your answer is correct.Type any key for next question");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was wrong. Type any key for next question");
                    Console.ReadLine();
                }
                if (i == 4) Helpers.PublishScore(score);
            }
            Helpers.AddToHistory(score, GameType.Division);

        }
    }
}
