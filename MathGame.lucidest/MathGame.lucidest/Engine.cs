using System;
using System.Collections.Generic;
using System.Text;

namespace MathGame
{
    public class Engine
    {
        public static bool Addition()
        {
            int num1 = Random.Shared.Next(0, 13);
            int num2 = Random.Shared.Next(0, 13);

            Console.WriteLine($"{num1} + {num2} = ?");
            Console.Write("\nAnswer: ");

            string input = Console.ReadLine();

            int answer = Validation.Validate(input);
            int corrAns = num1 + num2;

            if (corrAns == answer)
            {
                Console.WriteLine("That's correct, good job!");
                return true;
            }
            else
            {
                Console.WriteLine($"Incorrect, correct answer: {corrAns}");
                return false;
            }
        }

        public static bool Subtraction()
        {
            int num1 = Random.Shared.Next(0, 13);
            int num2 = Random.Shared.Next(0, 13);

            Console.WriteLine($"{num1} - {num2} = ?");
            Console.Write("\nAnswer: ");

            string input = Console.ReadLine();

            int answer = Validation.Validate(input);
            int corrAns = num1 - num2;

            if (corrAns == answer)
            {
                Console.WriteLine("That's correct, good job!");
                return true;
            }
            else
            {
                Console.WriteLine($"Incorrect, correct answer: {corrAns}");
                return false;
            }
        }

        public static bool Multiplication()
        {
            int num1 = Random.Shared.Next(0, 13);
            int num2 = Random.Shared.Next(0, 13);

            Console.WriteLine($"{num1} * {num2} = ?");
            Console.Write("\nAnswer: ");

            string input = Console.ReadLine();

            int answer = Validation.Validate(input);
            int corrAns = num1 * num2;

            if (corrAns == answer)
            {
                Console.WriteLine("That's correct, good job!");
                return true;
            }
            else
            {
                Console.WriteLine($"Incorrect, correct answer: {corrAns}");
                return false;
            }
        }

        public static bool Division()
        {
            int num1 = Random.Shared.Next(1, 13);
            int maxQuot = 100 / num1;
            int corrQuot = Random.Shared.Next(0, maxQuot + 1);
            int num2 = num1 * corrQuot;

            Console.WriteLine($"{num2} / {num1} = ?");
            Console.Write("\nAnswer: ");

            string input = Console.ReadLine();

            int answer = Validation.Validate(input);

            if (corrQuot == answer)
            {
                Console.WriteLine("That's correct, good job!");
                return true;
            }
            else
            {
                Console.WriteLine($"Incorrect, correct answer: {corrQuot}");
                return false;
            }
        }
    }
}