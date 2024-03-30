using CSharpAcademy_MathsGame.Models;

namespace CSharpAcademy_MathsGame;

internal class GameEngine
{

    internal void AdditionGame()
    {
        Random random = new Random();

        int score = 0;

        for (int i = 0; i < 5; i++)
        {
            Console.Clear();
            Console.WriteLine("Addition game");

            var firstNumber = random.Next(1, 9);
            var secondNumber = random.Next(1, 9);

            Console.Write($"\n{firstNumber} + {secondNumber} = ");
            var result = Console.ReadLine();

            bool checkResult = int.TryParse(result, out var parseResult);
            if (checkResult)
            {
                if (parseResult == firstNumber + secondNumber)
                {
                    Console.WriteLine("Your answer was correct!");
                    score++;
                }
                else Console.WriteLine($"Incorrect answer. The correct answer was {firstNumber + secondNumber}.");
            }
            else Console.WriteLine("Your answer was not a valid number.");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        Console.Clear();
        Console.WriteLine($"\nGame over. Your final score was: {score}");

        Helpers.CaptureScore(score, GameType.Addition);
    }

    internal void SubtractionGame()
    {
        Random random = new Random();

        int score = 0;

        for (int i = 0; i < 5; i++)
        {
            Console.Clear();
            Console.WriteLine("Subtraction game");

            var firstNumber = random.Next(1, 9);
            var secondNumber = random.Next(1, 9);

            Console.Write($"\n{firstNumber} - {secondNumber} = ");
            var result = Console.ReadLine();

            bool checkResult = int.TryParse(result, out var parseResult);
            if (checkResult)
            {
                if (parseResult == firstNumber - secondNumber)
                {
                    Console.WriteLine("Your answer was correct!");
                    score++;
                }
                else Console.WriteLine($"Incorrect answer. The correct answer was {firstNumber - secondNumber}.");
            }
            else Console.WriteLine("Your answer was not a valid number.");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        Console.Clear();
        Console.WriteLine($"\nGame over. Your final score was: {score}");

        Helpers.CaptureScore(score, GameType.Subtraction);
    }

    internal void MultiplicationGame()
    {
        Random random = new Random();

        int score = 0;

        for (int i = 0; i < 5; i++)
        {
            Console.Clear();
            Console.WriteLine("Multiplication game");

            var firstNumber = random.Next(1, 9);
            var secondNumber = random.Next(1, 9);

            Console.Write($"\n{firstNumber} * {secondNumber} = ");
            var result = Console.ReadLine();

            bool checkResult = int.TryParse(result, out var parseResult);
            if (checkResult)
            {
                if (parseResult == firstNumber * secondNumber)
                {
                    Console.WriteLine("Your answer was correct!");
                    score++;
                }
                else Console.WriteLine($"Incorrect answer. The correct answer was {firstNumber * secondNumber}.");
            }
            else Console.WriteLine("Your answer was not a valid number.");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        Console.Clear();
        Console.WriteLine($"\nGame over. Your final score was: {score}");

        Helpers.CaptureScore(score,GameType.Multiplication);
    }

    internal void DivisionGame()
    {
        int score = 0;

        for (int i = 0; i < 5; i++)
        {
            Console.Clear();
            Console.WriteLine("Division game");

            int[] divisionNumbers = Helpers.GetDivisionNumbers();
            int firstNumber = divisionNumbers[0];
            int secondNumber = divisionNumbers[1];

            Console.Write($"\n{firstNumber} / {secondNumber} = ");
            var result = Console.ReadLine();

            bool checkResult = int.TryParse(result, out var parseResult);
            if (checkResult)
            {
                if (parseResult == firstNumber / secondNumber)
                {
                    Console.WriteLine("Your answer was correct!");
                    score++;
                }
                else Console.WriteLine($"Incorrect answer. The correct answer was {firstNumber / secondNumber}.");
            }
            else Console.WriteLine("Your answer was not a valid number.");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        Console.Clear();
        Console.WriteLine($"\nGame over. Your final score was: {score}");

        Helpers.CaptureScore(score, GameType.Division);
    }
}
