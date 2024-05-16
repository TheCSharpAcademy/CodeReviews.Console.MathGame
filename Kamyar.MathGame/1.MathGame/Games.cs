using System;
using System.Diagnostics;

public class Game
{
    public Game(string questionType, int difficulty)
    {
        int num1, num2;
        int result = 0;

        switch (questionType)
        {
            case "A":
                GenerateNumbers(out num1, out num2, difficulty);
                result = num1 + num2;
                PlayGame($"{num1} + {num2} = ", result);
                break;
            case "S":
                GenerateNumbers(out num1, out num2, difficulty);
                result = num1 - num2;
                PlayGame($"{num1} - {num2} = ", result);
                break;
            case "M":
                GenerateNumbers(out num1, out num2, difficulty);
                result = num1 * num2;
                PlayGame($"{num1} * {num2} = ", result);
                break;
            case "D":
                // Generate numbers until division results in a whole number
                do
                {
                    GenerateNumbers(out num1, out num2, difficulty);
                } while (num1 % num2 != 0);
                result = num1 / num2;
                PlayGame($"{num1} / {num2} = ", result);
                break;
            default:
                Console.WriteLine("Invalid question type.");
                break;
        }
    }

    private void GenerateNumbers(out int num1, out int num2, int difficulty)
    {
        Random random = new Random();
        if (difficulty == 1)
        {
            num1 = random.Next(1, 50);
            num2 = random.Next(1, 50);
        }
        else if (difficulty == 2)
        {
            num1 = random.Next(5, 200);
            num2 = random.Next(5, 200);
        }
        else
        {
            num1 = random.Next(20, 1000);
            num2 = random.Next(20, 1000);
        }


    }

    private void PlayGame(string question, int result)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        stopwatch.Start();

        Console.Write(question);
        int input;
        bool isValid = false;
        do
        {
            string inputStr = Console.ReadLine()!;

            // Try to parse the input string to an integer
            isValid = int.TryParse(inputStr, out input);

            if (!isValid)
            {
                Console.WriteLine("Invalid input. Please enter an integer.");
            }

        } while (!isValid);

        stopwatch.Stop();
        double elapsedTime = stopwatch.Elapsed.TotalSeconds;

        if (result == input)
        {
            Messages.WinMessage();
            Results.SaveResult(question, result, "Correct", elapsedTime);
        }
        else
        {
            Messages.LossMessage(result);
            Results.SaveResult(question, result, "Incorrect", elapsedTime);
        }

    }
}
