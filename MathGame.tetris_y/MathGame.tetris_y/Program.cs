using System;
using System.Runtime.Intrinsics.Arm;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("===== Welcome to the Math Game! =====");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice (1-5):");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    PerformCalculation(1);
                    break;
                case 2:
                    PerformCalculation(2);
                    break;
                case 3:
                    PerformCalculation(3);
                    break;
                case 4:
                    PerformCalculation(4);
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Thank you for playing! Goodbye!\n");
                    Console.ResetColor();
                    return;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please try again.\n");
                    Console.ResetColor();
                    break;
            }
        }
    }

    static void PerformCalculation(int operation)
    {
        Random random = new Random();

        for (int i = 0; i < 5; i++)
        {
            int num1, num2;
            int correctAnswer = 0;

            switch (operation)
            {
                case 1:
                    num1 = random.Next(1, 101);
                    num2 = random.Next(1, 101);
                    correctAnswer = num1 + num2;
                    Console.Write($"What is {num1} + {num2}?: ");
                    break;
                case 2:
                    num1 = random.Next(1, 101);
                    num2 = random.Next(1, 101);
                    correctAnswer = num1 - num2;
                    Console.Write($"What is {num1} - {num2}?: ");
                    break;
                case 3:
                    num1 = random.Next(1, 101);
                    num2 = random.Next(1, 101);
                    correctAnswer = num1 * num2;
                    Console.Write($"What is {num1} * {num2}?: ");
                    break;
                case 4:
                    do
                    {
                        num1 = random.Next(1, 101);
                        num2 = random.Next(1, 101);
                    } while (num1 % num2 != 0);
                    correctAnswer = num1 / num2;
                    Console.Write($"What is {num1} / {num2}?: ");
                    break;
            }
            

            int userAnswer = Convert.ToInt32(Console.ReadLine());
            if (userAnswer == correctAnswer)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Correct!\n");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Incorrect. The correct answer is {correctAnswer}.\n");
                Console.ResetColor();
            }
        }
    }

    static bool checkDivisonResult(int num1, int num2)
    {
        if (num1 % num2 == 0)
        {
            return true;
        } else
        {
            return false;
        }

    }
}