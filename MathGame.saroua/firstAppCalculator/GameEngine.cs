using firstAppCalculator.Models;
using System;

namespace firstAppCalculator;

internal class GameEngine
{
    internal void DivisionGame(string message, string difficulty)
    {
        var score = 0;
        int questionAmount = Helpers.AmountOfQuestion();
        string difficultyOfGame = "undefined";

        switch (difficulty)
        {
            case "1":
                difficultyOfGame = "Easy";
                break;
            case "2":
                difficultyOfGame = "Medium";
                break;
            case "3":
                difficultyOfGame = "Hard";
                break;
        }
        DateTime startTime = DateTime.Now;
        for (int i = 0; i < questionAmount; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            var divisionNumbers = Helpers.GetDivisionNumbers(difficulty);
            var firstNumber = divisionNumbers[0];
            var secondNumber = divisionNumbers[1];

            Console.WriteLine($"{firstNumber} / {secondNumber}");
            var result = Console.ReadLine();

            if (int.Parse(result) == firstNumber / secondNumber)
            {
                Console.WriteLine("Your answer was correct! Type any key for the next question");
                score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                Console.ReadLine();
            }
        }
    DateTime endTime = DateTime.Now;
    TimeSpan timeSpanned = endTime - startTime;
    Helpers.AddToHistory(score, GameType.Division, questionAmount, difficultyOfGame,timeSpanned);
    }

    internal void MultiplicationGame(string message, string difficulty)
    {
        var random = new Random();
        var score = 0;
        string difficultyOfGame = "";
        DateTime startTime = DateTime.Now;

        int firstNumber = 0;
        int secondNumber = 0;

        var questionAmount = Helpers.AmountOfQuestion();

        for (int i = 0; i < questionAmount; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            switch (difficulty)
            {
                case "1":
                    firstNumber = random.Next(1, 10);
                    secondNumber = random.Next(1, 10);
                    difficultyOfGame = "easy";
                    break;
                case "2":
                    firstNumber = random.Next(1, 99);
                    secondNumber = random.Next(1, 99);
                    difficultyOfGame = "medium";
                    break;
                case "3":
                    firstNumber = random.Next(1, 1000);
                    secondNumber = random.Next(1, 1000);
                    difficultyOfGame = "hard";
                    break;
            }

            Console.WriteLine($"{firstNumber} * {secondNumber}");
            var result = Console.ReadLine();

            if (int.Parse(result) == firstNumber * secondNumber)
            {
                Console.WriteLine("Your answer was correct! Type any key for the next question");
                score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                Console.ReadLine();
            }
        }
        DateTime endTime = DateTime.Now;
        TimeSpan timeSpanned = endTime - startTime;
        Helpers.AddToHistory(score, GameType.Division, questionAmount, difficultyOfGame, timeSpanned);
    }

    internal void SubtractionGame(string message, string difficulty)
    {
        var random = new Random();
        var score = 0;
        string difficultyOfGame = "";
        DateTime startTime = DateTime.Now;

        int firstNumber = 0;
        int secondNumber = 0;

        int questionAmount = Helpers.AmountOfQuestion();

        for (int i = 0; i < questionAmount; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            switch (difficulty)
            {
                case "1":
                    firstNumber = random.Next(1, 10);
                    secondNumber = random.Next(1, 10);
                    difficultyOfGame = "easy";
                    break;
                case "2":
                    firstNumber = random.Next(1, 99);
                    secondNumber = random.Next(1, 99);
                    difficultyOfGame = "medium";
                    break;
                case "3":
                    firstNumber = random.Next(1, 1000);
                    secondNumber = random.Next(1, 1000);
                    difficultyOfGame = "hard";
                    break;
            }

            Console.WriteLine($"{firstNumber} - {secondNumber}");
            var result = Console.ReadLine();

            if (int.Parse(result) == firstNumber - secondNumber)
            {
                Console.WriteLine("Your answer was correct! Type any key for the next question");
                score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                Console.ReadLine();
            }
        }
        DateTime endTime = DateTime.Now;
        TimeSpan timeSpanned = endTime - startTime;
        Helpers.AddToHistory(score, GameType.Subtraction, questionAmount, difficultyOfGame, timeSpanned);
    }

    internal void AdditionGame(string message, string difficulty)
    {
        var random = new Random();
        var score = 0;
        string difficultyOfGame = "";
        DateTime startTime = DateTime.Now;

        int firstNumber = 0;
        int secondNumber = 0;

        int questionAmount = Helpers.AmountOfQuestion();

        for (int i = 0; i < questionAmount; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            switch (difficulty)
            {
                case "1":
                    firstNumber = random.Next(1, 10);
                    secondNumber = random.Next(1, 10);
                    difficultyOfGame = "easy";
                    break;
                case "2":
                    firstNumber = random.Next(1, 99);
                    secondNumber = random.Next(1, 99);
                    difficultyOfGame = "medium";
                    break;
                case "3":
                    firstNumber = random.Next(1, 1000);
                    secondNumber = random.Next(1, 1000);
                    difficultyOfGame = "hard";
                    break;
            }

            Console.WriteLine($"{firstNumber} + {secondNumber}");
            var result = Console.ReadLine();

            if (int.Parse(result) == firstNumber + secondNumber)
            {
                Console.WriteLine("Your answer was correct! Type any key for the next question");
                score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                Console.ReadLine();
            }
        }
        DateTime endTime = DateTime.Now;
        TimeSpan timeSpanned = endTime - startTime;
        Helpers.AddToHistory(score, GameType.Division, questionAmount, difficultyOfGame, timeSpanned);
    }

    internal void RandomGame(string message, string difficulty)
    {
        var random = new Random();
        var score = 0;
        string difficultyOfGame = "";
        var result = "";
        DateTime startTime = DateTime.Now;

        int firstNumber = 0;
        int secondNumber = 0;

        var questionAmount = Helpers.AmountOfQuestion();

        for (int i = 0; i < questionAmount; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            switch (difficulty)
            {
                case "1":
                    firstNumber = random.Next(1, 10);
                    secondNumber = random.Next(1, 10);
                    difficultyOfGame = "easy";
                    break;
                case "2":
                    firstNumber = random.Next(1, 99);
                    secondNumber = random.Next(1, 99);
                    difficultyOfGame = "medium";
                    break;
                case "3":
                    firstNumber = random.Next(1, 1000);
                    secondNumber = random.Next(1, 1000);
                    difficultyOfGame = "hard";
                    break;
            }

            var randomOperator = random.Next(1, 5);
            switch (randomOperator)
            {
                case 1:
                    Console.WriteLine($"{firstNumber} + {secondNumber}");
                    result = Console.ReadLine();
                    if (int.Parse(result) == firstNumber + secondNumber)
                    {
                        Console.WriteLine("Your answer was correct! Type any key for the next question");
                        score++;
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                        Console.ReadLine();
                    }
                    break;
                case 2:
                    Console.WriteLine($"{firstNumber} * {secondNumber}");
                    result = Console.ReadLine();
                    if (int.Parse(result) == firstNumber * secondNumber)
                    {
                        Console.WriteLine("Your answer was correct! Type any key for the next question");
                        score++;
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                        Console.ReadLine();
                    }
                    break;
                case 3:
                    Console.WriteLine($"{firstNumber} - {secondNumber}");
                    result = Console.ReadLine();
                    if (int.Parse(result) == firstNumber - secondNumber)
                    {
                        Console.WriteLine("Your answer was correct! Type any key for the next question");
                        score++;
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                        Console.ReadLine();
                    }
                    break;
                case 4:
                    var divisionNumbers = Helpers.GetDivisionNumbers(difficulty);
                    firstNumber = divisionNumbers[0];
                    secondNumber = divisionNumbers[1];

                    Console.WriteLine($"{firstNumber} / {secondNumber}");
                    result = Console.ReadLine();

                    if (int.Parse(result) == firstNumber / secondNumber)
                    {
                        Console.WriteLine("Your answer was correct! Type any key for the next question");
                        score++;
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                        Console.ReadLine();
                    }
                    break;
            }
        }
        DateTime endTime = DateTime.Now;
        TimeSpan timeSpanned = endTime - startTime;
        Helpers.AddToHistory(score, GameType.Random, questionAmount, difficultyOfGame, timeSpanned);
    }
}