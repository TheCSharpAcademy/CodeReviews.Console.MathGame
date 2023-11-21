using MathGame.nwdorian.Models;

namespace MathGame.nwdorian;

internal class GameEngine
{
    internal void DivisionGame(string message)
    {
        int score = 0;

        for (int i = 0; i < 5; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            int[] divisionNumbers = Helpers.GetDivisionNumbers();
            int firstNumber = divisionNumbers[0];
            int secondNumber = divisionNumbers[1];

            Console.WriteLine($"{firstNumber} / {secondNumber}");

            string? result = Console.ReadLine();
            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == firstNumber / secondNumber)
            {
                Console.WriteLine("Answer is correct. Press any key to continue");
                score++;
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Answer is incorrect. Press any key to continue");
                Console.ReadKey();
            }

            if (i == 4)
            {
                Console.WriteLine($"Game over! Your final score is {score}. Press any key to go to the main menu.");
                Console.ReadKey();
            }
        }
        Helpers.AddToHistory(score, GameType.Division, Helpers.GetGameDifficulty());
    }

    internal void MultiplicationGame(string message)
    {
        Random random = new Random();
        int score = 0;

        for (int i = 0; i < 5; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            int firstNumber = random.Next(1, Helpers.UpperLimit);
            int secondNumber = random.Next(1, Helpers.UpperLimit);

            Console.WriteLine($"{firstNumber} * {secondNumber}");

            string? result = Console.ReadLine();
            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == firstNumber * secondNumber)
            {
                Console.WriteLine("Answer is correct. Press any key to continue");
                score++;
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Answer is incorrect. Press any key to continue");
                Console.ReadKey();
            }

            if (i == 4)
            {
                Console.WriteLine($"Game over! Your final score is {score}. Press any key to go to the main menu.");
                Console.ReadKey();
            }
        }
        Helpers.AddToHistory(score, GameType.Multiplication, Helpers.GetGameDifficulty());
    }

    internal void SubtractionGame(string message)
    {
        Random random = new Random();
        int score = 0;

        for (int i = 0; i < 5; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            int firstNumber = random.Next(1, Helpers.UpperLimit);
            int secondNumber = random.Next(1, Helpers.UpperLimit);

            Console.WriteLine($"{firstNumber} - {secondNumber}");

            string? result = Console.ReadLine();
            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == firstNumber - secondNumber)
            {
                Console.WriteLine("Answer is correct. Press any key to continue");
                score++;
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Answer is incorrect. Press any key to continue");
                Console.ReadKey();
            }

            if (i == 4)
            {
                Console.WriteLine($"Game over! Your final score is {score}. Press any key to go to the main menu.");
                Console.ReadKey();
            }
        }
        Helpers.AddToHistory(score, GameType.Subtraction, Helpers.GetGameDifficulty());
    }

    internal void AdditionGame(string message)
    {
        Random random = new Random();
        int score = 0;

        for (int i = 0; i < 5; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            int firstNumber = random.Next(1, Helpers.UpperLimit);
            int secondNumber = random.Next(1, Helpers.UpperLimit);

            Console.WriteLine($"{firstNumber} + {secondNumber}");

            string? result = Console.ReadLine();
            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == firstNumber + secondNumber)
            {
                Console.WriteLine("Answer is correct. Press any key to continue");
                score++;
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Answer is incorrect. Press any key to continue");
                Console.ReadKey();
            }

            if (i == 4)
            {
                Console.WriteLine($"Game over! Your final score is {score}. Press any key to go to the main menu.");
                Console.ReadKey();
            }
        }
        Helpers.AddToHistory(score, GameType.Addition, Helpers.GetGameDifficulty());
    }
}

