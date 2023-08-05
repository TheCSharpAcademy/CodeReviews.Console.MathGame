namespace MathGame.lordWalnuts;
using MathGame.lordWalnuts.Models;
using System.Diagnostics;
internal class GameEngine
{
    //DIVISION GAME
    internal void DivisionGame(string message, Difficulty difficulty, int numberOfQuestion, bool isRandomGame)
    {
        var score = 0;

        //initialize a timer. 
        Stopwatch stopWatch = new();
        stopWatch.Start();
        TimeSpan ts = new();

        //
        for (int i = 0; i < numberOfQuestion; i++)
        {
            Console.Clear();

            Console.WriteLine($"{message}, Difficulty: {difficulty}");

            var divisionNumbers = Helpers.GetDivisionNumbers();
            var firstNumber = divisionNumbers[0];
            var secondNumber = divisionNumbers[1];

            Console.WriteLine($"{firstNumber} / {secondNumber}");

            var result = Console.ReadLine();
            result = Helpers.ValidateResult(result);

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
            if (i == numberOfQuestion - 1 && !isRandomGame)
            {
                Console.Clear();
                stopWatch.Stop();
                ts = stopWatch.Elapsed;
                Console.WriteLine($"Game over. Your final score is {score} and took {ts.Seconds} Seconds");
                Console.WriteLine("Press any key to go back to the main menu.");
                Console.ReadLine();
            }
        }
        //checks if the game mode is random
        if (!isRandomGame)
        {
            Helpers.AddToHistory(score, GameType.Addition, difficulty, $"{ts.Seconds}s");
        }
        else
        {
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Helpers.randomGameScore += score;
            Helpers.randomGameTime = Helpers.randomGameTime.Add(ts);
        }
    }

    //MULTIPLICATION GAME
    internal void MultiplicationGame(string message, Difficulty difficulty, int numberOfQuestions, bool isRandomGame)
    {

        var random = new Random();
        var score = 0;

        int firstNumber;
        int secondNumber;

        //intialize timer
        Stopwatch stopWatch = new();
        stopWatch.Start();
        TimeSpan ts = new();

        for (int i = 0; i < numberOfQuestions; i++)
        {
            Console.Clear();
            Console.WriteLine($"{message}, Difficulty: {difficulty}");

            firstNumber = random.Next(1, 9);
            secondNumber = random.Next(1, 9);

            Console.WriteLine($"{firstNumber} * {secondNumber}");

            var result = Console.ReadLine();
            result = Helpers.ValidateResult(result);

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

            if (i == numberOfQuestions - 1 && !isRandomGame)
            {
                Console.Clear();
                stopWatch.Stop();
                ts = stopWatch.Elapsed;
                Console.WriteLine($"Game over. Your final score is {score} and took {ts.Seconds} Seconds");
                Console.WriteLine("Press any key to go back to the main menu.");
                Console.ReadLine();
            }
        }

        if (!isRandomGame)
        {
            Helpers.AddToHistory(score, GameType.Addition, difficulty, $"{ts.Seconds}s");
        }
        else
        {
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Helpers.randomGameScore += score;
            Helpers.randomGameTime = Helpers.randomGameTime.Add(ts);
        }
    }

    //SUBRACTION GAME
    internal void SubtractionGame(string message, Difficulty difficulty, int numberOfQuestions, bool isRandomGame)
    {
        var random = new Random();
        var score = 0;

        int firstNumber;
        int secondNumber;

        // timer
        Stopwatch stopWatch = new();
        stopWatch.Start();
        TimeSpan ts = new();

        for (int i = 0; i < numberOfQuestions; i++)
        {
            Console.Clear();
            Console.WriteLine($"{message}, Difficulty: {difficulty}");

            firstNumber = random.Next(1, 9);
            secondNumber = random.Next(1, 9);

            Console.WriteLine($"{firstNumber} - {secondNumber}");

            var result = Console.ReadLine();
            result = Helpers.ValidateResult(result);

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

            if (i == numberOfQuestions - 1 && !isRandomGame)
            {
                Console.Clear();
                stopWatch.Stop();
                ts = stopWatch.Elapsed;
                Console.WriteLine($"Game over. Your final score is {score} and took {ts.Seconds} Seconds");
                Console.WriteLine("Press any key to go back to the main menu.");
                Console.ReadLine();
            }
        }
        if (!isRandomGame)
        {
            Helpers.AddToHistory(score, GameType.Addition, difficulty, $"{ts.Seconds}s");
        }
        else
        {
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Helpers.randomGameScore += score;
            Helpers.randomGameTime = Helpers.randomGameTime.Add(ts);
        }
    }

    //ADDITION GAME
    internal void AdditionGame(string message, Difficulty difficulty, int numberOfQuestions, bool isRandomGame)
    {
        var random = new Random();
        var score = 0;

        int firstNumber;
        int secondNumber;

        //timer
        Stopwatch stopWatch = new();
        stopWatch.Start();
        TimeSpan ts = new();

        for (int i = 0; i < numberOfQuestions; i++)
        {
            Console.Clear();
            Console.WriteLine($"{message}, Difficulty: {difficulty}");

            firstNumber = random.Next(1, 9);
            secondNumber = random.Next(1, 9);

            Console.WriteLine($"{firstNumber} + {secondNumber}");

            var result = Console.ReadLine();
            result = Helpers.ValidateResult(result);

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
            if (i == numberOfQuestions - 1 && !isRandomGame)
            {
                Console.Clear();
                stopWatch.Stop();
                ts = stopWatch.Elapsed;
                Console.WriteLine($"Game over. Your final score is {score} and took {ts.Seconds} Seconds");
                Console.WriteLine("Press any key to go back to the main menu.");
                Console.ReadLine();
            }
        }
        if (!isRandomGame)
        {
            Helpers.AddToHistory(score, GameType.Addition, difficulty, $"{ts.Seconds}s");
        }
        else
        {
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Helpers.randomGameScore += score;
            Helpers.randomGameTime = Helpers.randomGameTime.Add(ts);
        }
    }

    //RANDOM GAME
    internal void RandomGame(string message, Difficulty difficulty, int numberOfQuestions)
    {
        for (int i = 0; i < numberOfQuestions; i++)
        {
            //
            Helpers.RandomGameLogic(difficulty, this, message);
        }

        //add score and time to the database
        Helpers.AddToHistory(Helpers.randomGameScore, GameType.Random, difficulty, Helpers.randomGameTime.ToString());

        Console.WriteLine($"Game over. Your final score is {Helpers.randomGameScore} and took {Helpers.randomGameTime.Seconds} Seconds");
        Console.WriteLine("Press any key to go back to the main menu.");
        Console.ReadLine();

        //clear score for new game
        Helpers.randomGameTime = TimeSpan.Zero;
        Helpers.randomGameScore = 0;
    }
}