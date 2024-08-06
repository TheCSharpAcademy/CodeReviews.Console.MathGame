using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        MathGame.RunGameMenu();
    }
}

public class MathGame
{
    private static Random random = new Random();
    private static List<string> gameHistory = new List<string>();

    public static void RunGameMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Math Game ===");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. View game history");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option (1-6): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("You chose addition.");
                    (int x, int y) = Level();
                    Addition(x, y);
                    break;
                case "2":
                    Console.WriteLine("You chose subtraction.");
                    (x, y) = Level();
                    Subtraction(x, y);
                    break;
                case "3":
                    Console.WriteLine("You chose multiplication.");
                    (x, y) = Level();
                    Multiplication(x, y);
                    break;
                case "4":
                    Console.WriteLine("You chose division.");
                    (x, y) = Level();
                    Division(x, y);
                    break;
                case "5":
                    DisplayHistory();
                    break;
                case "6":
                    Console.WriteLine("Thanks for playing! Goodbye.");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    public static void Addition(int x, int y)
    {
        int a = random.Next(x, y + 1);
        int b = random.Next(x, y + 1);
        Console.WriteLine($"{a} + {b} = ?");
        int z = a + b;
        CheckAnswer(a, b, z, "+");
    }

    public static void Subtraction(int x, int y)
    {
        int a = random.Next(x, y + 1);
        int b = random.Next(x, y + 1);
        Console.WriteLine($"{a} - {b} = ?");
        int z = a - b;
        CheckAnswer(a, b, z, "-");
    }

    public static void Multiplication(int x, int y)
    {
        int a = random.Next(x, y + 1);
        int b = random.Next(x, y + 1);
        Console.WriteLine($"{a} * {b} = ?");
        int z = a * b;
        CheckAnswer(a, b, z, "*");
    }

    public static void Division(int x, int y)
    {
        int divisor = random.Next(x + 1, y + 2);  
        int quotient = random.Next(x, y + 1);  
        int dividend = divisor * quotient;  

        Console.WriteLine($"{dividend} / {divisor} = ?");
        CheckAnswer(dividend, divisor, quotient, "/");
    }

    public static void CheckAnswer(int x, int y, int correctAnswer, string operation)
    {
        Console.Write("Your answer: ");
        if (int.TryParse(Console.ReadLine(), out int userAnswer))
        {
            if (userAnswer == correctAnswer)
            {
                Console.WriteLine("Correct!");
                gameHistory.Add($"{x} {operation} {y} = {correctAnswer}, User answer: {userAnswer}, Result: Correct");
            }
            else
            {
                Console.WriteLine($"Incorrect. The correct answer was {correctAnswer}.");
                gameHistory.Add($"{x} {operation} {y} = {correctAnswer}, User answer: {userAnswer}, Result: Incorrect");
            }
        }
        else
        {
            Console.WriteLine("Invalid answer. No points awarded.");
            gameHistory.Add($"{x} {operation} {y} = {correctAnswer}, User answer: Invalid");
        }
    }

    public static (int, int) Level()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Difficulty Level ===");
            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Medium");
            Console.WriteLine("3. Hard");
            Console.Write("Choose a level (1-3): ");
            string choice = Console.ReadLine();

            int min = 0, max = 0;
            switch (choice)
            {
                case "1":
                    min = 0; max = 10;
                    break;
                case "2":
                    min = 11; max = 50;
                    break;
                case "3":
                    min = 51; max = 100;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    continue;
            }
            return (min, max);
        }
    }

    public static void DisplayHistory()
    {
        Console.WriteLine("=== Game History ===");
        if (gameHistory.Count == 0)
        {
            Console.WriteLine("No games have been played yet.");
        }
        else
        {
            for (int i = 0; i < gameHistory.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {gameHistory[i]}");
            }
        }
    }
}