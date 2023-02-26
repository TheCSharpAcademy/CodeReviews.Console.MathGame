using System.Security.Cryptography.X509Certificates;
using MathGame.Models;
namespace MathGame;

public class GameEngine
{
    Action<string, DifficultyLevel> [] functions = new Action<string, DifficultyLevel> [] { Addition, Subtraction, Multiplication, Division };

    internal static void Addition(string message, DifficultyLevel difficulty)
    {
        var start = DateTime.Now;
        Console.Clear();
        var random = new Random();
        var numberOfQuestions = Helpers.Questions();
        var score = 0;
        int firstNumber;
        int secondNumber;

        for (int i = 1; i <= numberOfQuestions; i++)
        {
            Console.Clear();
            if (difficulty == DifficultyLevel.Easy)
            {
                firstNumber = random.Next(1, 10);
                secondNumber = random.Next(1, 10);
            }
            else if (difficulty == DifficultyLevel.Medium)
            {
                firstNumber = random.Next(10, 100);
                secondNumber = random.Next(10, 100);
            }
            else
            {
                firstNumber = random.Next(100, 1000);
                secondNumber = random.Next(10, 1000);
            }
            Console.WriteLine($"{i}.) {firstNumber} + {secondNumber} =");
            var guess = Helpers.ValidateResult(Console.ReadLine());

            if (int.Parse(guess) == firstNumber + secondNumber)
            {
                Console.WriteLine("Correct! Press any button to continue");
                Console.ReadLine();
                score++;
            }
            else
            {
                Console.WriteLine($"Wrong! The correct answer was {firstNumber + secondNumber}. Press any Key to continue");
                Console.ReadLine();
            }
        }
        var finish = DateTime.Now - start;

        Console.Clear();
        Console.WriteLine($"Congrats you scored {score}. Press any key to continue");
        Console.ReadLine();
        Helpers.AddToHistory(score, GameType.Addition, difficulty, finish.Seconds, numberOfQuestions);
    }

    internal static void Subtraction(string message, DifficultyLevel difficulty)
    {
        var score = 0;
        var start = DateTime.Now;
        int firstNumber, secondNumber;

        Console.Clear();
        var numberOfQuestions = Helpers.Questions();
        for (int i = 1; i <= numberOfQuestions; i++)
        {
            firstNumber = Helpers.GetSubtractionNumbers(difficulty) [0];
            secondNumber = Helpers.GetSubtractionNumbers(difficulty) [1];
            Console.Clear();
            Console.WriteLine($"{i}). {firstNumber} - {secondNumber} =");
            var guess = Helpers.ValidateResult(Console.ReadLine());

            if (int.Parse(guess) == firstNumber - secondNumber)
            {
                Console.WriteLine("Correct! Press any key to continue");
                score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"Wrong! The correct answer was {firstNumber - secondNumber}. Press any key to continue.");
                Console.ReadLine();
            }
        }
        var finish = DateTime.Now - start;

        Console.Clear();
        Console.WriteLine($"Congrats you scored {score}. Press any key to continue");
        Console.ReadLine();
        Helpers.AddToHistory(score, GameType.Subtraction, difficulty, finish.Seconds, numberOfQuestions);
    }

    internal static void Multiplication(string message, DifficultyLevel difficulty)
    {
        var start = DateTime.Now;
        Console.Clear();
        var random = new Random();
        var numberOfQuestions = Helpers.Questions();
        var score = 0;
        int firstNumber, secondNumber;

        for (int i = 1; i <= numberOfQuestions; i++)
        {
            Console.Clear();
            if (difficulty == DifficultyLevel.Easy)
            {
                firstNumber = random.Next(1, 10);
                secondNumber = random.Next(1, 10);
            }
            else if (difficulty == DifficultyLevel.Medium)
            {
                firstNumber = random.Next(10, 100);
                secondNumber = random.Next(1, 10);
            }
            else
            {
                firstNumber = random.Next(100, 1000);
                secondNumber = random.Next(10, 100);
            }
            Console.WriteLine($"{i}.) {firstNumber} * {secondNumber} =");
            var guess = Helpers.ValidateResult(Console.ReadLine());

            if (int.Parse(guess) == firstNumber * secondNumber)
            {
                Console.WriteLine("Correct! Press any button to continue");
                Console.ReadLine();
                score++;
            }
            else
            {
                Console.WriteLine($"Wrong! The correct answer was {firstNumber * secondNumber}. Press any Key to continue");
                Console.ReadLine();
            }
        }
        var finish = DateTime.Now - start;

        Console.Clear();
        Console.WriteLine($"Congrats you scored {score}. Press any key to continue");
        Console.ReadLine();
        Helpers.AddToHistory(score, GameType.Multiplication, difficulty, finish.Seconds, numberOfQuestions);
    }

    internal static void Division(string message, DifficultyLevel difficulty)
    {
        var start = DateTime.Now;
        Console.Clear();
        var numberOfQuestions = Helpers.Questions();
        int firstNumber, secondNumber;
        var score = 0;

        for (int i = 1; i <= numberOfQuestions; i++)
        {
            firstNumber = Helpers.GetDivisionNumbers(difficulty) [0];
            secondNumber = Helpers.GetDivisionNumbers(difficulty) [1];
            Console.Clear();
            Console.WriteLine($"{i}). {firstNumber} / {secondNumber} =");
            var guess = Helpers.ValidateResult(Console.ReadLine());

            if (int.Parse(guess) == firstNumber / secondNumber)
            {
                Console.WriteLine("Correct! Press any key to continue");
                score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"Wrong! The correct answer was {firstNumber / secondNumber}. Press any key to continue.");
                Console.ReadLine();
            }
        }
        var finish = DateTime.Now - start;

        Console.Clear();
        Console.WriteLine($"Congrats you scored {score}. Press any key to continue");
        Console.ReadLine();
        Helpers.AddToHistory(score, GameType.Division, difficulty, finish.Seconds, numberOfQuestions);
    }

    internal void RandomGame(string message, DifficultyLevel difficulty)
    {
        var random = new Random();
        int index = random.Next(functions.Length);

        functions [index](message, difficulty);
    }

}