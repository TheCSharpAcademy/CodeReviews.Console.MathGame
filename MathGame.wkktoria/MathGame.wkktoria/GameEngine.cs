using System.Diagnostics;
using MathGame.wkktoria.Models;

namespace MathGame.wkktoria;

internal static class GameEngine
{
    private static readonly Array GameTypes = typeof(GameType).GetEnumValues();


    internal static void Play(GameType gameType, DifficultyLevel difficultyLevel, int questions)
    {
        var score = 0;

        var random = new Random();

        var stopwatch = new Stopwatch();
        stopwatch.Start();

        for (var i = 0; i < questions; i++)
        {
            var questionGameType = gameType;

            while (questionGameType == GameType.Random)
                questionGameType = (GameType)GameTypes.GetValue(random.Next(GameTypes.Length));

            Console.Clear();
            Console.WriteLine($"{questionGameType} game");

            int[] numbers;
            int correctAnswer;

            switch (questionGameType)
            {
                case GameType.Addition:
                    numbers = GetNumbers(difficultyLevel);
                    correctAnswer = numbers[0] + numbers[1];
                    break;
                case GameType.Subtraction:
                    numbers = GetNumbers(difficultyLevel);
                    correctAnswer = numbers[0] - numbers[1];
                    break;
                case GameType.Multiplication:
                    numbers = GetNumbers(difficultyLevel);
                    correctAnswer = numbers[0] * numbers[1];
                    break;
                case GameType.Division:
                    numbers = GetDivisionNumbers(difficultyLevel);
                    correctAnswer = numbers[0] / numbers[1];
                    break;
                default:
                    numbers = new int[2];
                    correctAnswer = 0;
                    break;
            }

            Console.WriteLine($"{numbers[0]} {((char)questionGameType).ToString()} {numbers[1]} = ?");
            var result = Helpers.GetResult();

            if (result == correctAnswer)
            {
                Console.WriteLine("Your answer was correct.");
                score++;
                Console.WriteLine("Type any key for the next question.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"Your answer was incorrect. The correct answer is: {correctAnswer}.");
                Console.WriteLine("Type any key for the next question.");
                Console.ReadLine();
            }
        }

        stopwatch.Stop();
        var totalTime = stopwatch.Elapsed.TotalSeconds;

        Helpers.AddToHistory(score, gameType, totalTime, questions);
        PrintGameOver(score, totalTime, questions);
    }

    private static int[] GetNumbers(DifficultyLevel difficultyLevel)
    {
        var random = new Random();

        var numbers = new int[2];

        int firstNumber;
        int secondNumber;

        switch (difficultyLevel)
        {
            case DifficultyLevel.Easy:
                firstNumber = random.Next(1, 10);
                secondNumber = random.Next(1, 10);
                break;
            case DifficultyLevel.Medium:
                firstNumber = random.Next(10, 100);
                secondNumber = random.Next(10, 100);
                break;
            case DifficultyLevel.Hard:
                firstNumber = random.Next(100, 1000);
                secondNumber = random.Next(100, 1000);
                break;
            default:
                firstNumber = random.Next(1, 99);
                secondNumber = random.Next(1, 99);
                break;
        }

        numbers[0] = firstNumber;
        numbers[1] = secondNumber;

        return numbers;
    }


    private static int[] GetDivisionNumbers(DifficultyLevel difficultyLevel)
    {
        var divisionNumbers = GetNumbers(difficultyLevel);

        while (divisionNumbers[0] % divisionNumbers[1] != 0)
            divisionNumbers = GetNumbers(difficultyLevel);

        return divisionNumbers;
    }

    private static void PrintGameOver(int gameScore, double gameTime, int gameQuestions)
    {
        Console.Clear();
        Console.WriteLine(
            $"Game over. Your final score is {gameScore}/{gameQuestions} and your time was {gameTime} seconds.");
        Console.WriteLine("Press any key to go back to the main menu.");
        Console.ReadLine();
    }
}