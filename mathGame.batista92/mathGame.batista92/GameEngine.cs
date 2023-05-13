using mathGame.batista92.Models;

namespace mathGame.batista92;

internal class GameEngine
{
    internal void AdditionGame(string msg)
    {
        Random random = new Random();
        int score = 0;

        int firstNumber;
        int secondNumber;

        for (int i = 0; i < 5; i++)
        {
            Console.Clear();
            Console.WriteLine(msg);

            firstNumber = random.Next(1, 9);
            secondNumber = random.Next(1, 9);

            Console.WriteLine($"{firstNumber} + {secondNumber}");
            var result = Console.ReadLine();
            result = Helpers.ValidadeResult(result);

            if (int.Parse(result) == firstNumber + secondNumber)
            {
                Console.WriteLine("You answer was correct! Type any key for next question");
                score++;
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Your answer war incorrect. Type any key for next question");
                Console.ReadKey();
            }
        }

        Console.WriteLine($"Game over! Your final score is: {score} pts.");
        Console.WriteLine("Type any key for return to the menu...");
        Console.ReadKey();
        Helpers.AddToHistory(score, GameType.Addition);
    }

    internal void SubtractionGame(string msg)
    {
        Random random = new Random();
        int score = 0;

        int firstNumber;
        int secondNumber;

        for (int i = 0; i < 5; i++)
        {
            Console.Clear();
            Console.WriteLine(msg);

            firstNumber = random.Next(1, 9);
            secondNumber = random.Next(1, 9);

            Console.WriteLine($"{firstNumber} - {secondNumber}");
            var result = Console.ReadLine();
            result = Helpers.ValidadeResult(result);

            if (int.Parse(result) == firstNumber - secondNumber)
            {
                Console.WriteLine("You answer was correct! Type any key for next question");
                score++;
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Your answer war incorrect. Type any key for next question");
                Console.ReadKey();
            }
        }

        Console.WriteLine($"Game over! Your final score is: {score}");
        Console.WriteLine("Type any key for return to the menu");
        Console.ReadKey();
        Helpers.AddToHistory(score, GameType.Subtraction);
    }

    internal void MultiplicationGame(string msg)
    {
        Random random = new Random();
        int score = 0;

        int firstNumber;
        int secondNumber;

        for (int i = 0; i < 5; i++)
        {
            Console.Clear();
            Console.WriteLine(msg);

            firstNumber = random.Next(1, 9);
            secondNumber = random.Next(1, 9);

            Console.WriteLine($"{firstNumber} * {secondNumber}");
            var result = Console.ReadLine();
            result = Helpers.ValidadeResult(result);

            if (int.Parse(result) == firstNumber * secondNumber)
            {
                Console.WriteLine("You answer was correct! Type any key for next question");
                score++;
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Your answer war incorrect. Type any key for next question");
                Console.ReadKey();
            }
        }

        Console.WriteLine($"Game over! Your final score is: {score}");
        Console.WriteLine("Type any key for return to the menu");
        Console.ReadKey();
        Helpers.AddToHistory(score, GameType.Multuplication);
    }

    internal void DivisionGame(string msg)
    {
        Random random = new Random();
        int score = 0;

        int firstNumber;
        int secondNumber;

        for (int i = 0; i < 5; i++)
        {
            Console.Clear();
            Console.WriteLine(msg);

            var divisionNumbers = Helpers.GetDivisionNumbers();
            firstNumber = divisionNumbers[0];
            secondNumber = divisionNumbers[1];

            Console.WriteLine($"{firstNumber} / {secondNumber}");
            var result = Console.ReadLine();
            result = Helpers.ValidadeResult(result);

            if (int.Parse(result) == firstNumber / secondNumber)
            {
                Console.WriteLine("You answer was correct! Type any key for next question");
                score++;
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Your answer war incorrect. Type any key for next question");
                Console.ReadKey();
            }
        }

        Console.WriteLine($"Game over! Your final score is: {score}");
        Console.WriteLine("Type any key for return to the menu");
        Console.ReadKey();
        Helpers.AddToHistory(score, GameType.Division);
    }
}
