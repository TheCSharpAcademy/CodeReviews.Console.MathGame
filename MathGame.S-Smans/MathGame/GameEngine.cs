using System.Diagnostics;

namespace MathGame;

internal class GameEngine
{
    private Helper _helper;

    public GameEngine(Helper helper) 
    {
        _helper = helper;
    }

    internal void Addition()
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        int score = 0;
        for (int i = 0; i < _helper.QuestionAmount; i++)
        {
            score = AdditionPlay() ? ++score : score;
        }
        stopWatch.Stop();
        TimeSpan time = stopWatch.Elapsed;
        string duration = time.ToString("mm':'ss");

        Console.WriteLine($"Your score is: {score} in {duration}");
        _helper.AddHistory(GameType.Addition, score, (Difficulty)_helper.DifficultyLevel, duration, _helper.QuestionAmount);
        Console.ReadLine();
    }

    internal void Subtraction()
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        int score = 0;
        for (int i = 0; i < _helper.QuestionAmount; i++)
        {
            score = SubtractionPlay() ? ++score : score;
        }
        stopWatch.Stop();
        TimeSpan time = stopWatch.Elapsed;
        string duration = time.ToString("mm':'ss");

        Console.WriteLine($"Your score is: {score} in {duration}");
        _helper.AddHistory(GameType.Subtraction, score, (Difficulty)_helper.DifficultyLevel, duration, _helper.QuestionAmount);
        Console.ReadLine();
    }

    internal void Multiplication()
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        int score = 0;
        for (int i = 0; i < _helper.QuestionAmount; i++)
        {
            score = MultiplicationPlay() ? ++score: score;
        }
        stopWatch.Stop();
        TimeSpan time = stopWatch.Elapsed;
        string duration = time.ToString("mm':'ss");

        Console.WriteLine($"Your score is: {score} in {duration}");
        _helper.AddHistory(GameType.Multiplication, score, (Difficulty)_helper.DifficultyLevel, duration, _helper.QuestionAmount);
        Console.ReadLine();
    }

    internal void Division()
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        int score = 0;
        for (int i = 0; i < _helper.QuestionAmount; i++)
        {
            score = DivisionPlay() ? ++score : score;
        }
        stopWatch.Stop();
        TimeSpan time = stopWatch.Elapsed;
        string duration = time.ToString("mm':'ss");

        Console.WriteLine($"Your score is: {score} in {duration}");
        _helper.AddHistory(GameType.Division, score, (Difficulty)_helper.DifficultyLevel, duration, _helper.QuestionAmount);
        Console.ReadLine();
    }

    internal void Random()
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        int score = 0;

        for (int i = 0; i < _helper.QuestionAmount; i++)
        {
            Random random = new Random();
            int operandIndex = random.Next(0, 4);
            switch (operandIndex)
            {
                case 0:
                    score = AdditionPlay() ? ++score : score;
                    break;
                case 1:
                    score = SubtractionPlay() ? ++score : score;
                    break;
                case 2:
                    score = DivisionPlay() ? ++score : score;
                    break;
                case 3:
                    score = MultiplicationPlay() ? ++score : score;
                    break;
                default:
                    Console.WriteLine("ERROR on Random GameType: default executed!");
                    Environment.Exit(1);
                    break;
            }
        }

        stopWatch.Stop();
        TimeSpan time = stopWatch.Elapsed;
        string duration = time.ToString("mm':'ss");

        Console.WriteLine($"Your score is: {score} in {duration}");
        _helper.AddHistory(GameType.Random, score, (Difficulty)_helper.DifficultyLevel, duration, _helper.QuestionAmount);
        Console.ReadLine();
    }

    private bool DivisionPlay()
    {
        Console.Clear();
        Console.WriteLine("Division");

        int[] numbers = _helper.GetDivisionNumbers();
        Console.WriteLine($"{numbers[0]} / {numbers[1]}");
        int userInput = _helper.VerifyResultsInput();

        if (userInput == numbers[0] / numbers[1])
        {
            Console.WriteLine("Correct!");
            Console.ReadLine();
            return true;
        }
        else
        {
            Console.WriteLine("WRONG!");
            Console.ReadLine();
            return false;
        }
    }

    private bool MultiplicationPlay()
    {
        Console.Clear();
        Console.WriteLine("Multiplication");

        int[] numbers = _helper.GetTwoNumbers();
        Console.WriteLine($"{numbers[0]} * {numbers[1]}");
        int userInput = _helper.VerifyResultsInput();

        if (userInput == numbers[0] * numbers[1])
        {
            Console.WriteLine("Correct!");
            Console.ReadLine();
            return true;
        }
        else
        {
            Console.WriteLine("WRONG!");
            Console.ReadLine();
            return false;
        }
    }

    private bool SubtractionPlay()
    {
        Console.Clear();
        Console.WriteLine("Subtraction");

        int[] numbers = _helper.GetTwoNumbers();
        Console.WriteLine($"{numbers[0]} - {numbers[1]}");
        int userInput = _helper.VerifyResultsInput();

        if (userInput == numbers[0] - numbers[1])
        {
            Console.WriteLine("Correct!");
            Console.ReadLine();
            return true;
        }
        else
        {
            Console.WriteLine("WRONG!");
            Console.ReadLine();
            return false;
        }
    }

    private bool AdditionPlay()
    {
        Console.Clear();
        Console.WriteLine("Addition");

        int[] numbers = _helper.GetTwoNumbers();
        Console.WriteLine($"{numbers[0]} + {numbers[1]}");
        int userInput = _helper.VerifyResultsInput();

        if (userInput == numbers[0] + numbers[1])
        {
            Console.WriteLine("Correct!");
            Console.ReadLine();
            return true;
        }
        else
        {
            Console.WriteLine("WRONG!");
            Console.ReadLine();
            return false;
        }
    }
}