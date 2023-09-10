using System.ComponentModel.Design;

namespace MathGame.Matija87
{
    internal static class GameEngine
    {
        public static void Addition()
        {
            Random random = new Random();
            Console.WriteLine("Addition game");
            Console.WriteLine("-------------");

            int firstNumber;
            int secondNumber;
            int score = 0;
            string? result;

            for (int i = 0; i < 5; i++)
            {
                firstNumber = random.Next(1, 10);
                secondNumber = random.Next(1, 10);
                Console.WriteLine($"{firstNumber} + {secondNumber}");
                
                do
                {
                    result = Console.ReadLine();
                } while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _));

                if (int.Parse(result) == firstNumber + secondNumber)
                {
                    score++;
                    Console.WriteLine($"Correct! Your current score is {score} / {i + 1}");
                }
                else
                {
                    Console.WriteLine($"Wrong answer! Your current score is {score} / {i + 1}");
                }
            }
        }

        public static void Subtraction()
        {
            Random random = new Random();
            Console.WriteLine("Subtraction game");
            Console.WriteLine("-----------------");

            int firstNumber;
            int secondNumber;
            int score = 0;
            string? result;

            for (int i = 0; i < 5; i++)
            {
                firstNumber = random.Next(1, 10);
                secondNumber = random.Next(1, 10);
                Console.WriteLine($"{firstNumber} - {secondNumber}");

                do
                {
                    result = Console.ReadLine();
                } while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _));

                if (int.Parse(result) == firstNumber - secondNumber)
                {
                    score++;
                    Console.WriteLine($"Correct! Your current score is {score} / {i + 1}");
                }
                else
                {
                    Console.WriteLine($"Wrong answer! Your current score is {score} / {i + 1}");
                }
            }
        }

        public static void Multiplication()
        {
            Random random = new Random();
            Console.WriteLine("Multiplication game");
            Console.WriteLine("--------------------");

            int firstNumber;
            int secondNumber;
            int score = 0;
            string? result;

            for (int i = 0; i < 5; i++)
            {
                firstNumber = random.Next(1, 10);
                secondNumber = random.Next(1, 10);
                Console.WriteLine($"{firstNumber} * {secondNumber}");

                do
                {
                    result = Console.ReadLine();
                } while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _));

                if (int.Parse(result) == firstNumber * secondNumber)
                {
                    score++;
                    Console.WriteLine($"Correct! Your current score is {score} / {i + 1}");
                }
                else
                {
                    Console.WriteLine($"Wrong answer! Your current score is {score} / {i + 1}");
                }
            }
        }
    }
}
