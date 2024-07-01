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
                    PlayGame("+");
                    break;
                case "2":
                    PlayGame("-");
                    break;
                case "3":
                    PlayGame("*");
                    break;
                case "4":
                    PlayGame("/");
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

    private void PlayGame(string operation)
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

        history.Add(new GameRecord(operation, $"{a} {operation} {b}", answer, isCorrect, stopwatch.Elapsed));
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

    public GameRecord(string gameType, string question, int userAnswer, bool isCorrect, TimeSpan timeTaken)
    {
        GameType = gameType;
        Question = question;
        UserAnswer = userAnswer;
        IsCorrect = isCorrect;
        TimeTaken = timeTaken;
    }
}
