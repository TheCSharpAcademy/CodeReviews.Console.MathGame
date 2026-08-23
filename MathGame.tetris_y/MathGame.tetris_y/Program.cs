using System;
using System.Runtime.Intrinsics.Arm;

class Program
{
    static void Main(string[] args)
    {
        List<string> previousGames = new List<string>();

        while (true)
        {
            Console.WriteLine("===== Welcome to the Math Game! =====");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Display game history");
            Console.WriteLine("0. Exit");

            Console.Write("Enter your choice (1-5): ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    previousGames.AddRange(PerformCalculation("+"));
                    break;
                case 2:
                    previousGames.AddRange(PerformCalculation("-"));
                    break;
                case 3:
                    previousGames.AddRange(PerformCalculation("*"));
                    break;
                case 4:
                    previousGames.AddRange(PerformCalculation("/"));
                    break;
                case 5:
                    DisplayHistory(previousGames);
                    break;
                case 0:
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

    static void DisplayHistory(List<string> history)
    {
        Console.Clear();

        foreach(string game in history)
        {
            Console.WriteLine(game);
        }

        Console.Write("Press any key to continue...");
        Console.ReadLine();
    }

    static List<string> PerformCalculation(string operation)
    {
        Random random = new Random();
        List<string> history = new List<string>();

        for (int i = 0; i < 5; i++)
        {
            int num1 = 0;
            int num2 = 0;
            int correctAnswer = 0;

            switch (operation)
            {
                case "+":
                    num1 = random.Next(1, 101);
                    num2 = random.Next(1, 101);
                    correctAnswer = num1 + num2;
                    Console.Write($"What is {num1} + {num2}?: ");
                    break;
                case "-":
                    num1 = random.Next(1, 101);
                    num2 = random.Next(1, 101);
                    correctAnswer = num1 - num2;
                    Console.Write($"What is {num1} - {num2}?: ");
                    break;
                case "*":
                    num1 = random.Next(1, 101);
                    num2 = random.Next(1, 101);
                    correctAnswer = num1 * num2;
                    Console.Write($"What is {num1} * {num2}?: ");
                    break;
                case "/":
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
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Incorrect. The correct answer is {correctAnswer}.\n");
            }

            history.Add($"Operation: {num1} {operation} {num2} Correct Answer: {correctAnswer} Your Answer: {userAnswer}");

            Console.ResetColor();
        }

        return history;
    }
}