using MathGame.Models;

namespace MathGame;

internal class GameEngine
{
    int randomScore;
    internal void AdditionGame(string message, int limit, bool isRandom, string difficulty)
    {
        int score = 0;

        for (int i = 0; i < limit; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            int[] numbers = Helpers.ChooseNumbers(difficulty, GameType.Addition);
            int firstNumber = numbers[0];
            int secondNumber = numbers[1];

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"{firstNumber} + {secondNumber}");

            string result = Console.ReadLine();
            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == firstNumber + secondNumber)
            {
                score++;
                randomScore++;
                Console.WriteLine("Your answer is correct! Type any key to continue.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your answer is incorrect. Type any key to continue.");
                Console.ReadLine();
            }
        }

        if (!isRandom)
        {
            Console.WriteLine($"Your score is: {score} out of {limit}. Press any key to go back to the main menu.");
            Console.ReadLine();
            Helpers.AddToHistory(score, GameType.Addition, limit, difficulty);
        }
    }

    internal void SubtractionGame(string message, int limit, bool isRandom, string difficulty)
    {
        int score = 0;

        for (int i = 0; i < limit; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            int[] numbers = Helpers.ChooseNumbers(difficulty, GameType.Subtraction);
            int firstNumber = numbers[0];
            int secondNumber = numbers[1];

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"{firstNumber} - {secondNumber}");

            string result = Console.ReadLine();
            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == firstNumber - secondNumber)
            {
                score++;
                randomScore++;
                Console.WriteLine("Your answer is correct! Type any key to continue.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your answer is incorrect. Type any key to continue.");
                Console.ReadLine();
            }
        }

        if (!isRandom)
        {
            Console.WriteLine($"Your score is: {score} out of {limit}. Press any key to go back to the main menu.");
            Console.ReadLine();
            Helpers.AddToHistory(score, GameType.Subtraction, limit, difficulty);
        }
    }

    internal void MultiplicationGame(string message, int limit, bool isRandom, string difficulty)
    {
        int score = 0;

        for (int i = 0; i < limit; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            int[] numbers = Helpers.ChooseNumbers(difficulty, GameType.Multiplication);
            int firstNumber = numbers[0];
            int secondNumber = numbers[1];

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"{firstNumber} * {secondNumber}");

            string result = Console.ReadLine();
            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == firstNumber * secondNumber)
            {
                score++;
                randomScore++;
                Console.WriteLine("Your answer is correct! Type any key to continue.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your answer is incorrect. Type any key to continue.");
                Console.ReadLine();
            }
        }

        if (!isRandom)
        {
            Console.WriteLine($"Your score is: {score} out of {limit}. Press any key to go back to the main menu.");
            Console.ReadLine();
            Helpers.AddToHistory(score, GameType.Multiplication, limit, difficulty);
        }
    }

    internal void DivisionGame(string message, int limit, bool isRandom,string difficulty)
    {
        Console.Clear();
        Console.WriteLine(message);
        int score = 0;

        for (int i = 0; i < limit; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            int[] numbers = Helpers.ChooseNumbers(difficulty, GameType.Division);
            int firstNumber = numbers[0];
            int secondNumber = numbers[1];

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"{firstNumber} / {secondNumber}");

            string result = Console.ReadLine();
            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == firstNumber / secondNumber)
            {
                score++;
                randomScore++;
                Console.WriteLine("Your answer is correct! Type any key to continue.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your answer is incorrect. Type any key to continue.");
                Console.ReadLine();
            }
        }

        if (!isRandom)
        {
            Console.WriteLine($"Your score is: {score} out of {limit}. Press any key to go back to the main menu.");
            Console.ReadLine();
            Helpers.AddToHistory(score, GameType.Division, limit, difficulty);
        }
    }

    internal void RandomGame(string message, int limit, string difficulty)
    {
        string[] gameTypeNames = Enum.GetNames(typeof(GameType));
        randomScore = 0;
        gameTypeNames = gameTypeNames.Where(x => x != "Random").ToArray();
        Random random = new Random();

        for (int i = 0; i < limit; i++)
        {
            int number = random.Next(0, gameTypeNames.Length);

            switch (gameTypeNames[number])
            {
                case "Addition":
                    AdditionGame("Random game - Addition", 1, true, difficulty);
                    break;

                case "Subtraction":
                    SubtractionGame("Random game - Subtraction", 1, true, difficulty);
                    break;

                case "Multiplication":
                    MultiplicationGame("Random game - Multiplication", 1, true, difficulty);
                    break;

                case "Division":
                    DivisionGame("Random game - Division", 1, true, difficulty);
                    break;
            }
        }

        Console.WriteLine($"Your score is: {randomScore} out of {limit}. Press any key to go back to the main menu.");
        Console.ReadLine();
        Helpers.AddToHistory(randomScore, GameType.Random, limit, difficulty);
    }
}
