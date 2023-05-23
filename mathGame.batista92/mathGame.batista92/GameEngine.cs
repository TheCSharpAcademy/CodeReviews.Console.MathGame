using mathGame.batista92.Models;

namespace mathGame.batista92;

internal class GameEngine
{
    int score;
    bool isRandomGame;
    TimeSpan timeTaken;
    readonly Random random = new();

    internal void AdditionGame(string msg, int numberOfQuestions, DifficultyLevel difficulty)
    {
        for (int i = 0; i < numberOfQuestions; i++)
        {
            Console.Clear();
            Console.WriteLine(msg);

            int[] numbers = Helpers.GetNumbers(difficulty);

            Console.WriteLine($"{numbers[0]} + {numbers[1]}");

            DateTime startTime = DateTime.Now;
            var result = Console.ReadLine();
            result = Helpers.ValidadeResult(result);
            DateTime endTime = DateTime.Now;
            timeTaken += endTime - startTime;

            if (int.Parse(result) == numbers[0] + numbers[1])
            {
                Console.WriteLine("You answer was correct! Type any key for next question");
                score++;
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Your answer war incorrect. Type any key for next question");
                Console.ReadKey();
            }
        }
        if (!isRandomGame)
        {
            Helpers.GameOver(score, GameType.Addition, numberOfQuestions, difficulty, timeTaken);
            score = 0;
            timeTaken = TimeSpan.Zero;
        }
    }

    internal void SubtractionGame(string msg, int numberOfQuestions, DifficultyLevel difficulty)
    {
        for (int i = 0; i < numberOfQuestions; i++)
        {
            Console.Clear();
            Console.WriteLine(msg);

            int[] numbers = Helpers.GetNumbers(difficulty);

            Console.WriteLine($"{numbers[0]} - {numbers[1]}");
            DateTime startTime = DateTime.Now;
            var result = Console.ReadLine();
            result = Helpers.ValidadeResult(result);
            DateTime endTime = DateTime.Now;
            timeTaken += endTime - startTime;

            if (int.Parse(result) == numbers[0] - numbers[1])
            {
                Console.WriteLine("You answer was correct! Type any key for next question");
                score++;
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Your answer war incorrect. Type any key for next question");
                Console.ReadKey();
            }
        }

        if (!isRandomGame)
        {
            Helpers.GameOver(score, GameType.Subtraction, numberOfQuestions, difficulty, timeTaken);
            score = 0;
            timeTaken = TimeSpan.Zero;
        }
    }

    internal void MultiplicationGame(string msg, int numberOfQuestions, DifficultyLevel difficulty)
    {
        for (int i = 0; i < numberOfQuestions; i++)
        {
            Console.Clear();
            Console.WriteLine(msg);

            int[] numbers = Helpers.GetNumbers(difficulty);

            Console.WriteLine($"{numbers[0]}  *  {numbers[1]}");
            DateTime startTime = DateTime.Now;
            var result = Console.ReadLine();
            result = Helpers.ValidadeResult(result);
            DateTime endTime = DateTime.Now;
            timeTaken += endTime - startTime;

            if (int.Parse(result) == numbers[0] * numbers[1])
            {
                Console.WriteLine("You answer was correct! Type any key for next question");
                score++;
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Your answer war incorrect. Type any key for next question");
                Console.ReadKey();
            }
        }
        if (!isRandomGame)
        {
            Helpers.GameOver(score, GameType.Multuplication, numberOfQuestions, difficulty, timeTaken);
            score = 0;
            timeTaken = TimeSpan.Zero;
        }
    }

    internal void DivisionGame(string msg, int numberOfQuestions, DifficultyLevel difficulty)
    {
        for (int i = 0; i < numberOfQuestions; i++)
        {
            Console.Clear();
            Console.WriteLine(msg);

            var divisionNumbers = Helpers.GetNumbers(difficulty, true);
            int firstNumber = divisionNumbers[0];
            int secondNumber = divisionNumbers[1];

            Console.WriteLine($"{firstNumber} / {secondNumber}");
            DateTime startTime = DateTime.Now;
            var result = Console.ReadLine();
            result = Helpers.ValidadeResult(result);
            DateTime endTime = DateTime.Now;
            timeTaken += endTime - startTime;

            if (int.Parse(result) == firstNumber / secondNumber)
            {
                Console.WriteLine("You answer was correct! Type any key for next question...");
                score++;
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Your answer war incorrect. Type any key for next question...");
                Console.ReadKey();
            }
        }
        if (!isRandomGame)
        {
            Helpers.GameOver(score, GameType.Division, numberOfQuestions, difficulty, timeTaken);
            score = 0;
            timeTaken = TimeSpan.Zero;
        }
    }

    internal void RandomGame(string msg, int numberOfQuestions, DifficultyLevel difficulty)
    {    
        isRandomGame = true;
        for (int i = 0; i < numberOfQuestions; i++)
        {
            var gameType = random.Next(1, 5);

            if (gameType == 1)
                AdditionGame(msg, 1, difficulty);

            if (gameType == 2)
                SubtractionGame(msg, 1, difficulty);

            if (gameType == 3)
                MultiplicationGame(msg, 1, difficulty);

            if (gameType == 4)
                DivisionGame(msg, 1, difficulty);
        }

        Helpers.GameOver(score, GameType.Random, numberOfQuestions, difficulty, timeTaken);
        
        score = 0;
        isRandomGame = false;
    }
}
