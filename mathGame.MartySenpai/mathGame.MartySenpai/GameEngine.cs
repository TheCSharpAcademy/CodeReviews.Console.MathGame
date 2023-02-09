using MathGame.Models;
using System;
using System.Diagnostics;

namespace MathGame;

internal class GameEngine
{
    internal void AdditionGame(string message, char operand)
    {
        Console.WriteLine(message);

        string difficulty = Menu.ShowDifficultyMenu();

        int nQuestions = Helpers.GetAmountOfQuestions();

        int score = 0;

        List<int> numbers = new List<int>();

        Stopwatch timer = new Stopwatch();
        timer.Start();

        for (int i = 0; i < nQuestions; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            numbers.Clear();
            Helpers.PrintQuestions(difficulty, numbers, operand);

            string input = Console.ReadLine();
            input = Helpers.ValidateInput(input);

            int output = numbers[0];
            output = Helpers.GetOutput(output, operand, numbers);

            score = Helpers.GetScore(input, output, score);

            if (i == nQuestions - 1)
            {
                Console.WriteLine($"Game over, Your final score is {score}. Press any key to go back to the main menu.");
                Console.ReadLine();
            }
        }

        timer.Start();
        TimeSpan timeTaken = timer.Elapsed;

        Helpers.AddToHistory(score, nQuestions, GameType.Addition, difficulty, timeTaken);
    }
    internal void SubtractionGame(string message, char operand)
    {
        Console.WriteLine(message);

        string difficulty = Menu.ShowDifficultyMenu();

        int nQuestions = Helpers.GetAmountOfQuestions();

        int score = 0;

        List<int> numbers = new List<int>();

        Stopwatch timer = new Stopwatch();
        timer.Start();

        for (int i = 0; i < nQuestions; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            numbers.Clear();
            Helpers.PrintQuestions(difficulty, numbers, operand);

            string input = Console.ReadLine();
            input = Helpers.ValidateInput(input);

            int output = numbers[0];
            output = Helpers.GetOutput(output, operand, numbers);

            score = Helpers.GetScore(input, output, score);

            if (i == nQuestions - 1)
            {
                Console.WriteLine($"Game over, Your final score is {score}. Press any key to go back to the main menu.");
                Console.ReadLine();
            }
        }

        timer.Start();
        TimeSpan timeTaken = timer.Elapsed;

        Helpers.AddToHistory(score, nQuestions, GameType.Subtraction, difficulty, timeTaken);

    }
    internal void MultiplicationGame(string message, char operand)
    {
        Console.WriteLine(message);

        string difficulty = Menu.ShowDifficultyMenu();

        int nQuestions = Helpers.GetAmountOfQuestions();

        int score = 0;

        List<int> numbers = new List<int>();

        Stopwatch timer = new Stopwatch();
        timer.Start();

        for (int i = 0; i < nQuestions; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            numbers.Clear();
            Helpers.PrintQuestions(difficulty, numbers, operand);

            string input = Console.ReadLine();
            input = Helpers.ValidateInput(input);

            int output = numbers[0];
            output = Helpers.GetOutput(output, operand, numbers);

            score = Helpers.GetScore(input, output, score);

            if (i == nQuestions - 1)
            {
                Console.WriteLine($"Game over, Your final score is {score}. Press any key to go back to the main menu.");
                Console.ReadLine();
            }
        }

        timer.Start();
        TimeSpan timeTaken = timer.Elapsed;

        Helpers.AddToHistory(score, nQuestions, GameType.Multiplication, difficulty, timeTaken);
    }
    internal void RandomGame(string message)
    {
        Console.WriteLine(message);

        Random random = new Random();

        string difficulty = Menu.ShowDifficultyMenu();

        int nQuestions = Helpers.GetAmountOfQuestions();

        List<char> operands = new List<char> { '+', '-', '*', '/'};

        int score = 0;

        List<int> numbers = new List<int>();

        Stopwatch timer = new Stopwatch();
        timer.Start();

        for (int i = 0; i < nQuestions; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            char operand = operands[random.Next(0, 4)];

            // Clear previous values from numbers. 
            numbers.Clear();
            if (operand == '/') 
            {
                numbers = Helpers.GetDivisionNumbers();
            }

            Helpers.PrintQuestions(difficulty, numbers, operand);

            string input = Console.ReadLine();

            input = Helpers.ValidateInput(input);

            int output = numbers[0];

            for (int j = 1; j < numbers.Count; j++)
            {
                // Fix division questions.
                if (operand == '+')
                {
                    output += numbers[j];
                }
                else if (operand == '-')
                {
                    output -= numbers[j];
                }
                else if (operand == '*')
                {
                    output *= numbers[j];
                }
                else
                {
                    output /= numbers[j];
                }
            }

            if (int.Parse(input) == output)
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

            if (i == nQuestions - 1)
            {
                Console.WriteLine($"Game over, Your final score is {score}. Press any key to go back to the main menu.");
                Console.ReadLine();
            }
        }
        timer.Stop();
        TimeSpan timeTaken = timer.Elapsed;

        Helpers.AddToHistory(score, nQuestions, GameType.Random, difficulty, timeTaken);
    }

    //DivisionGame does not offer difficult levels.
    internal void DivisionGame(string message, char operand)
    {
        Console.WriteLine(message);

        string difficulty = "Easy";

        int nQuestions = Helpers.GetAmountOfQuestions();

        int score = 0;

        List<int> numbers = new List<int>();

        Stopwatch timer = new Stopwatch();
        timer.Start();

        for (int i = 0; i < nQuestions; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            numbers.Clear();
            numbers = Helpers.GetDivisionNumbers();

            Helpers.PrintQuestions(difficulty, numbers, operand);

            string input = Console.ReadLine();
            input = Helpers.ValidateInput(input);

            int output = numbers[0];
            output = Helpers.GetOutput(output, operand, numbers);

            score = Helpers.GetScore(input, output, score);

            if (i == nQuestions - 1)
            {
                Console.WriteLine($"Game over, Your final score is {score}. Press any key to go back to the main menu.");
                Console.ReadLine();
            }
        }
        timer.Stop();
        TimeSpan timeTaken = timer.Elapsed;

       Helpers.AddToHistory(score,nQuestions, GameType.Division, difficulty, timeTaken);
    }
}
