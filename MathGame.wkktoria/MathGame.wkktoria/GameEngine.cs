using MathGame.wkktoria.Models;

namespace MathGame.wkktoria;

internal static class GameEngine
{
    internal static void AdditionGame(string message)
    {
        var random = new Random();

        var score = 0;

        for (var i = 0; i < 5; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            var firstNumber = random.Next(1, 9);
            var secondNumber = random.Next(1, 9);

            Console.WriteLine($"{firstNumber} + {secondNumber} = ?");
            var result = Helpers.GetResult();

            if (result == firstNumber + secondNumber)
            {
                Console.WriteLine("Your answer was correct.");
                score++;
                Console.WriteLine("Type any key for the next question.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your answer was incorrect.");
                Console.WriteLine("Type any key for the next question.");
                Console.ReadLine();
            }
        }

        Helpers.AddToHistory(score, GameType.Addition);

        Console.Clear();
        Console.WriteLine($"Game over. Your final score is {score}.");
        Console.WriteLine("Press any key to go back to the main menu.");
        Console.ReadLine();
    }

    internal static void SubtractionGame(string message)
    {
        var random = new Random();

        var score = 0;

        for (var i = 0; i < 5; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            var firstNumber = random.Next(1, 9);
            var secondNumber = random.Next(1, 9);

            Console.WriteLine($"{firstNumber} - {secondNumber} = ?");
            var result = Helpers.GetResult();

            if (result == firstNumber - secondNumber)
            {
                Console.WriteLine("Your answer was correct.");
                score++;
                Console.WriteLine("Type any key for the next question.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your answer was incorrect.");
                Console.WriteLine("Type any key for the next question.");
                Console.ReadLine();
            }
        }

        Helpers.AddToHistory(score, GameType.Subtraction);

        Console.Clear();
        Console.WriteLine($"Game over. Your final score is {score}.");
        Console.WriteLine("Press any key to go back to the main menu.");
        Console.ReadLine();
    }

    internal static void MultiplicationGame(string message)
    {
        var random = new Random();

        var score = 0;

        for (var i = 0; i < 5; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            var firstNumber = random.Next(1, 9);
            var secondNumber = random.Next(1, 9);

            Console.WriteLine($"{firstNumber} * {secondNumber} = ?");
            var result = Helpers.GetResult();

            if (result == firstNumber * secondNumber)
            {
                Console.WriteLine("Your answer was correct.");
                score++;
                Console.WriteLine("Type any key for the next question.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your answer was incorrect.");
                Console.WriteLine("Type any key for the next question.");
                Console.ReadLine();
            }
        }

        Helpers.AddToHistory(score, GameType.Multiplication);

        Console.Clear();
        Console.WriteLine($"Game over. Your final score is {score}.");
        Console.WriteLine("Press any key to go back to the main menu.");
        Console.ReadLine();
    }

    internal static void DivisionGame(string message)
    {
        var score = 0;

        for (var i = 0; i < 5; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            var divisionNumbers = Helpers.GetDivisionNumbers();
            var firstNumber = divisionNumbers[0];
            var secondNumber = divisionNumbers[1];

            Console.WriteLine($"{firstNumber} / {secondNumber} = ?");
            var result = Helpers.GetResult();

            if (result == firstNumber / secondNumber)
            {
                Console.WriteLine("Your answer was correct.");
                score++;
                Console.WriteLine("Type any key for the next question.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your answer was incorrect.");
                Console.WriteLine("Type any key for the next question.");
                Console.ReadLine();
            }
        }

        Helpers.AddToHistory(score, GameType.Division);

        Console.Clear();
        Console.WriteLine($"Game over. Your final score is {score}.");
        Console.WriteLine("Press any key to go back to the main menu.");
        Console.ReadLine();
    }
}