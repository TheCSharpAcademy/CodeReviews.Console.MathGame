using System;

namespace MathGame.VincentyArmstrong;

public class Game
{
    private int result;

    public GameType Type { get; }
    public int Questions { get; }
    public bool HardMode { get; }
    public int Score { get; private set; }

    public Game(GameType type, int questions, bool hardMode)
    {
        Questions = questions;
        HardMode = hardMode;
        Type = type;
        Play();
    }

    private void Play()
    {
        int firstNumber;
        int secondNumber;
        for (int i = 0; i < Questions; i++)
        {
            Random random = new();
            if (HardMode)
            {
                firstNumber = random.Next(1, 999);
                secondNumber = random.Next(1, 999);
            }
            else
            {
                firstNumber = random.Next(1, 99);
                secondNumber = random.Next(1, 99);
            }

            Console.Clear();
            Console.WriteLine($"Round {i + 1}");
            Console.WriteLine("Calculate:");
            CalculateResult(firstNumber, secondNumber);
            GetAnswerFromUser();
        }
        Console.WriteLine($"Game finished. Your final score is {Score} out of {Questions}");
        Console.WriteLine($"Press any key to return to Main Menu");
        Console.ReadLine();
    }

    private void CalculateResult(int firstNumber, int secondNumber)
    {
        Random random = new();
        if (Type.Equals(GameType.Addition))
        {
            result = firstNumber + secondNumber;
            Console.WriteLine($"{firstNumber} + {secondNumber}");
        }
        if (Type.Equals(GameType.Subtraction))
        {
            result = firstNumber - secondNumber;
            Console.WriteLine($"{firstNumber} - {secondNumber}");
        }
        if (Type.Equals(GameType.Multiplication))
        {
            result = firstNumber * secondNumber;
            Console.WriteLine($"{firstNumber} x {secondNumber}");
        }
        if (Type.Equals(GameType.Division))
        {
            int[] divisors = Utilities.GetDevisors(firstNumber);
            secondNumber = divisors[random.Next(divisors.Length)];
            result = firstNumber / secondNumber;
            Console.WriteLine($"{firstNumber} ÷ {secondNumber}");
        }
    }

    private void GetAnswerFromUser()
    {
        bool parsed;
        int userResult;
        do
        {
            parsed = int.TryParse(Console.ReadLine(), out userResult);
            if (!parsed) Console.WriteLine("Please enter a number");
        } while (!parsed);
        if (userResult == result) Score++;
    }

}

public enum GameType { Addition, Subtraction, Multiplication, Division };