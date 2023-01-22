using System.Diagnostics;

namespace MathGame;

internal class GameEngine
{
    private Helper helper;

    public GameEngine(Helper helper) 
    {
        this.helper = helper;
    }
    internal void Addition()
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        int score = 0;
        for (int i = 0; i < helper.ask; i++)
        {
            score = AdditionPlay() ? ++score : score;
        }
        stopWatch.Stop();
        TimeSpan time = stopWatch.Elapsed;
        string duration = time.ToString("mm':'ss");

        Console.WriteLine($"Your score is: {score} in {duration}");
        helper.AddHistory(GameType.Addition, score, (Difficulty)helper.lvl, duration, helper.ask);
        Console.ReadLine();
    }
    internal void Subtraction()
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        int score = 0;
        for (int i = 0; i < helper.ask; i++)
        {
            score = SubtractionPlay() ? ++score : score;
        }
        stopWatch.Stop();
        TimeSpan time = stopWatch.Elapsed;
        string duration = time.ToString("mm':'ss");

        Console.WriteLine($"Your score is: {score} in {duration}");
        helper.AddHistory(GameType.Subtraction, score, (Difficulty)helper.lvl, duration, helper.ask);
        Console.ReadLine();
    }

    internal void Multiplication()
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        int score = 0;
        for (int i = 0; i < helper.ask; i++)
        {
            score = MultiplicationPlay() ? ++score: score;
        }
        stopWatch.Stop();
        TimeSpan time = stopWatch.Elapsed;
        string duration = time.ToString("mm':'ss");

        Console.WriteLine($"Your score is: {score} in {duration}");
        helper.AddHistory(GameType.Multiplication, score, (Difficulty)helper.lvl, duration, helper.ask);
        Console.ReadLine();
    }

    internal void Division()
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        int score = 0;
        for (int i = 0; i < helper.ask; i++)
        {
            score = DivisionPlay() ? ++score : score;
        }
        stopWatch.Stop();
        TimeSpan time = stopWatch.Elapsed;
        string duration = time.ToString("mm':'ss");

        Console.WriteLine($"Your score is: {score} in {duration}");
        helper.AddHistory(GameType.Division, score, (Difficulty)helper.lvl, duration, helper.ask);
        Console.ReadLine();
    }

    internal void Random()
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        int score = 0;
        for (int i = 0; i < helper.ask; i++)
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
        helper.AddHistory(GameType.Random, score, (Difficulty)helper.lvl, duration, helper.ask);
        Console.ReadLine();
    }

    private bool DivisionPlay()
    {
        Console.Clear();
        Console.WriteLine("Division");

        int[] numbers = helper.GetDivisionNumbers();
        Console.WriteLine($"{numbers[0]} / {numbers[1]}");
        int userInput = helper.VerifyResultsInput();

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

        int[] numbers = helper.GetTwoNumbers();
        Console.WriteLine($"{numbers[0]} * {numbers[1]}");
        int userInput = helper.VerifyResultsInput();

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

        int[] numbers = helper.GetTwoNumbers();
        Console.WriteLine($"{numbers[0]} - {numbers[1]}");
        int userInput = helper.VerifyResultsInput();

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

        int[] numbers = helper.GetTwoNumbers();
        Console.WriteLine($"{numbers[0]} + {numbers[1]}");
        int userInput = helper.VerifyResultsInput();

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
