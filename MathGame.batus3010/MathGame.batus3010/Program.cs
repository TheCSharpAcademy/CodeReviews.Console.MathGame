using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Game game = new Game();
        game.Start();
    }
}

public class Game
{
    private List<GameRecord> history = new List<GameRecord>();

    public void Start()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nMath Game");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. History");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option: ");
            string? option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    SelectDifficultyAndPlayGame("+");
                    break;
                case "2":
                    SelectDifficultyAndPlayGame("-");
                    break;
                case "3":
                    SelectDifficultyAndPlayGame("*");
                    break;
                case "4":
                    SelectDifficultyAndPlayGame("/");
                    break;
                case "5":
                    ShowHistory();
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    private void SelectDifficultyAndPlayGame(string operation)
    {
        Console.WriteLine("\nSelect Difficulty Level:");
        Console.WriteLine("1. Easy");
        Console.WriteLine("2. Medium");
        Console.WriteLine("3. Hard");
        Console.Write("Select an option: ");
        string? difficulty = Console.ReadLine();

        int maxNumber = difficulty switch
        {
            "1" => 10, // Easy
            "2" => 50, // Medium
            "3" => 100, // Hard
            _ => 10
        };

        PlayGame(operation, maxNumber);
    }
    private void PlayGame(string operation, int maxNumber)
    {
        Random rand = new Random();
        int a = rand.Next(0, 101);
        int b = operation == "/" ? rand.Next(1, 101) : rand.Next(0, 101);
        if (operation == "/")
        {
            while (a % b != 0)
            {
                a = rand.Next(0, 101);
                b = rand.Next(1, 101);
            }
        }

        string question = $"What is {a} {operation} {b}?";
        Console.WriteLine(question);
        Stopwatch stopwatch = Stopwatch.StartNew();
        int answer = Convert.ToInt32(Console.ReadLine());
        stopwatch.Stop();

        int correctAnswer = operation switch
        {
            "+" => a + b,
            "-" => a - b,
            "*" => a * b,
            "/" => a / b,
            _ => 0
        };

        bool isCorrect = answer == correctAnswer;
        if (isCorrect)
        {
            Console.WriteLine("Correct!");
        }
        else
        {
            Console.WriteLine($"Wrong! The correct answer was {correctAnswer}.");
        }

        history.Add(new GameRecord(operation, $"{a} {operation} {b}", answer, isCorrect, stopwatch.Elapsed, maxNumber));
    }

    private void ShowHistory()
    {
        if (history.Count == 0)
        {
            Console.WriteLine("No history yet.");
            return;
        }

        Console.WriteLine("\nGame History:");
        for (int i = 0; i < history.Count; i++)
        {
            var game = history[i];
            Console.WriteLine($"ID: {i + 1} | Type: {game.GameType} | Question: {game.Question} | Answer: {game.UserAnswer} | Result: {(game.IsCorrect ? "Correct" : "Wrong")} | Taken time: {game.TimeTaken.TotalSeconds} seconds");
        }
    }
}

public class GameRecord
{
    public string GameType { get; }
    public string Question { get; }
    public int UserAnswer { get; }
    public bool IsCorrect { get; }
    public TimeSpan TimeTaken { get; }
    public string Difficulty { get; }

    public GameRecord(string gameType, string question, int userAnswer, bool isCorrect, TimeSpan timeTaken, int maxNumber)
    {
        GameType = gameType;
        Question = question;
        UserAnswer = userAnswer;
        IsCorrect = isCorrect;
        TimeTaken = timeTaken;
        Difficulty = maxNumber switch
        {
            10 => "Easy",
            50 => "Medium",
            100 => "Hard",
            _ => "Unknown"
        };
    }
}
