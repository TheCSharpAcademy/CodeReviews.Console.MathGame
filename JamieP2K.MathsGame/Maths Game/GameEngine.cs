using Maths_Game.Models;

namespace Maths_Game;

internal class GameEngine
{
    internal void RunGame(GameType operation)
    {
        Random random = new();
        int firstNumber;
        int secondNumber;
        int score = 0;

        for (int i = 0; i < 5; i++)
        {
            firstNumber = random.Next(1, 9);
            secondNumber = random.Next(1, 9);
            if (firstNumber < secondNumber) (firstNumber, secondNumber) = (secondNumber, firstNumber);

            (int correctAnswer, string symbol) = operation switch
            {
                GameType.Addition => (firstNumber + secondNumber, "+"),
                GameType.Subtraction => (firstNumber - secondNumber, "-"),
                GameType.Multiplication => (firstNumber * secondNumber, "*"),
            };

            Console.Clear();
            Console.WriteLine($"Question {i + 1}");
            Console.WriteLine($"{firstNumber} {symbol} {secondNumber}");
            string result = Console.ReadLine();

            if (int.TryParse(result, out int parsed) && parsed == correctAnswer)
            {
                Console.WriteLine("\nCorrect");
                score++;
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\nIncorrect");
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
            }
        }

        Helpers.AddToHistory(operation, score);

        Console.WriteLine($"\nYour final score was {score}/5");
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

    internal void RunDivisionGame()
    {
        int score = 0;

        for (int i = 0; i < 5; i++)
        {
            (int firstNumber, int secondNumber) = Helpers.GetDivisionNumbers();

            Console.Clear();
            Console.WriteLine($"Question {i + 1}");
            Console.WriteLine($"{firstNumber} / {secondNumber}");
            string result = Console.ReadLine();

            if (int.TryParse(result, out int parsed) && parsed == firstNumber / secondNumber)
            {
                Console.WriteLine("\nCorrect");
                score++;
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\nIncorrect");
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
            }
        }

        Helpers.AddToHistory(GameType.Division, score);

        Console.WriteLine($"\nYour final score was {score}/5");
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();

    }
}
