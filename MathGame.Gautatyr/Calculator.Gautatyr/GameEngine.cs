using Calculator.Gautatyr.Models;

namespace Calculator.Gautatyr;

internal class GameEngine
{
    internal void AdditionGame(string message, GameDifficulty difficulty)
    {
        Console.Clear();
        Console.WriteLine(message);

        var random = new Random();
        var score = 0;

        int firstNumber;
        int secondNumber;
        int numberSize = 9;

        switch (difficulty)
        {
            case GameDifficulty.Easy:
                numberSize = 9;
                break;
            case GameDifficulty.Medium:
                numberSize = 99;
                break;
            case GameDifficulty.Hard:
                numberSize = 999;
                break;
        }

        for (int i = 0; i < 5; i++)
        {
            Console.Clear();
            Console.WriteLine(message);
            firstNumber = random.Next(1, numberSize);
            secondNumber = random.Next(1, numberSize);

            Console.WriteLine($"{firstNumber} + {secondNumber}");
            var result = Console.ReadLine();

            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == firstNumber + secondNumber)
            {
                Console.WriteLine("Your answer was correct ! Type any key for the next question.");
                score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your answer was incorrect.Type any key for the next question.");
                Console.ReadLine();
            }

            if (i == 4)
            {
                Console.WriteLine($"Game over. Your final score is {score}, press any key to go back to the menu.");
                Console.ReadLine();
            }
        }
        Helpers.AddToHistory(score, Models.GameType.Addition);
    }

    internal void SubstractionGame(string message, GameDifficulty difficulty)
    {
        Console.Clear();
        Console.WriteLine(message);

        var random = new Random();
        var score = 0;

        int firstNumber;
        int secondNumber;
        int numberSize = 9;

        switch (difficulty)
        {
            case GameDifficulty.Easy:
                numberSize = 9;
                break;
            case GameDifficulty.Medium:
                numberSize = 99;
                break;
            case GameDifficulty.Hard:
                numberSize = 999;
                break;
        }

        for (int i = 0; i < 5; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            firstNumber = random.Next(1, numberSize);
            secondNumber = random.Next(1, numberSize);

            Console.WriteLine($"{firstNumber} - {secondNumber}");
            var result = Console.ReadLine();

            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == firstNumber - secondNumber)
            {
                Console.WriteLine("Your answer was correct ! Type any key for the next question.");
                score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your answer was incorrect. Type any key for the next question.");
                Console.ReadLine();
            }

            if (i == 4)
            {
                Console.WriteLine($"Game over. Your final score is {score}, press any key to go back to the menu.");
                Console.ReadLine();
            }
        }
        Helpers.AddToHistory(score, Models.GameType.Substraction);
    }

    internal void MultiplicationGame(string message, GameDifficulty difficulty)
    {
        Console.Clear();
        Console.WriteLine(message);

        var random = new Random();
        var score = 0;

        int firstNumber;
        int secondNumber;
        int numberSize = 9;

        switch (difficulty)
        {
            case GameDifficulty.Easy:
                numberSize = 9;
                break;
            case GameDifficulty.Medium:
                numberSize = 99;
                break;
            case GameDifficulty.Hard:
                numberSize = 999;
                break;
        }

        for (int i = 0; i < 5; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            firstNumber = random.Next(1, numberSize);
            secondNumber = random.Next(1, numberSize);

            Console.WriteLine($"{firstNumber} * {secondNumber}");
            var result = Console.ReadLine();

            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == firstNumber * secondNumber)
            {
                Console.WriteLine("Your answer was correct ! Type any key for the next question.");
                score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your answer was incorrect.Type any key for the next question.");
                Console.ReadLine();
            }

            if (i == 4)
            {
                Console.WriteLine($"Game over. Your final score is {score}, press any key to go back to the menu.");
                Console.ReadLine();
            }
        }
        Helpers.AddToHistory(score, Models.GameType.Multiplication);
    }

    internal void DivisionGame(string message, GameDifficulty difficulty)
    {
        Console.Clear();
        Console.WriteLine(message);

        var score = 0;

        for (int i = 0; i < 5; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            var divisionNumbers = Helpers.GetDivisionNumbers(difficulty);
            var firstNumber = divisionNumbers[0];
            var secondNumber = divisionNumbers[1];

            Console.WriteLine($"{firstNumber} / {secondNumber}");
            var result = Console.ReadLine();
            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == firstNumber / secondNumber)
            {
                Console.WriteLine("Your answer was correct ! Type any key for the next question.");
                score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your answer was incorrect. Type any key for the next question.");
                Console.ReadLine();
            }

            if (i == 4)
            {
                Console.WriteLine($"Game over. Your final score is {score}, press any key to go back to the menu.");
                Console.ReadLine();
            }
        }
        Helpers.AddToHistory(score, Models.GameType.Division);
    }
}
