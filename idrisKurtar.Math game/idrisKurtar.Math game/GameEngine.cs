using idrisKurtar.Math_game.Models;
using System;
using System.Linq;
using System.Security.AccessControl;


namespace idrisKurtar.Math_game
{
    internal class GameEngine
    {
        internal static void AdditionGame(string message)
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
                Console.WriteLine(firstNumber + " + " + secondNumber);
                var result = Console.ReadLine();
                if (int.Parse(result) == firstNumber + secondNumber)
                {
                    Console.WriteLine("Your answer was correct.Type any key for the next question.");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Type any key for the next question.");
                    Console.ReadLine();
                }
                if (i == 4)
                {
                    Console.WriteLine($"Game over. Your final score is {score}. Press any key to go back to the main menu.");
                    Console.ReadLine();

                }

            }
            Helpers.AddToHistory(score, GameType.Addition);
        }

        internal static void SubstractionGame(string message)
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
                Console.WriteLine(firstNumber + " - " + secondNumber);
                var result = Console.ReadLine();
                if (int.Parse(result) == firstNumber - secondNumber)
                {
                    Console.WriteLine("Your answer was correct.Type any key for the next question.");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Type any key for the next question.");
                    Console.ReadLine();
                }
                if (i == 4)
                {
                    Console.WriteLine($"Game over. Your final score is {score}. Press any key to go back to the main menu.");
                    Console.ReadLine();
                }
            }

            Helpers.AddToHistory(score, GameType.Substraciton);
        }
        internal static void MultiplictionGame(string message)
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
                Console.WriteLine(firstNumber + " * " + secondNumber);
                var result = Console.ReadLine();
                if (int.Parse(result) == firstNumber * secondNumber)
                {
                    Console.WriteLine("Your answer was correct.Type any key for the next question.");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Type any key for the next question.");
                    Console.ReadLine();
                }
                if (i == 4)
                {
                    Console.WriteLine($"Game over. Your final score is {score}. Press any key to go back to the main menu.");
                    Console.ReadLine();
                }

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

                var divisonNumbers = Helpers.GetDivisonNumbers();
                var firstNumber = divisonNumbers[0];
                var secondNumber = divisonNumbers[1];

                Console.WriteLine(firstNumber + " / " + secondNumber);
                var result = Console.ReadLine();

                if (int.Parse(result) == firstNumber / secondNumber)
                {
                    Console.WriteLine("Your answer was correct.Type any key for the next question.");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Type any key for the next question.");
                    Console.ReadLine();
                }
                if (i == 4)
                {
                    Console.WriteLine($"Game over. Your final score is {score}. Press any key to go back to the main menu.");
                    Console.ReadLine();
                }
            }
            Helpers.AddToHistory(score, GameType.Division);
        }
    }
}
