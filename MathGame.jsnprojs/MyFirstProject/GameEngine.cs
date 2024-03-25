using MyFirstProject.Models;
using System.Diagnostics;

namespace MyFirstProject;
internal class GameEngine
{
    internal void DivisionGame(string message)
    {
        int difficultyUpperBound = 0;
        var difficulty = Helpers.GetDifficulty(out difficultyUpperBound);
        int numbersOfQuestions = Helpers.GetNumbersOfQuestions();
        var score = 0;
    
        //Calculate the amount of time it takes for player to finish the game
        Stopwatch playTimer = new Stopwatch();
        playTimer.Start();

        for (int i = 0; i < numbersOfQuestions; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            var divisionNumbers = Helpers.GetDivisionNumbers(difficultyUpperBound);
            var firstNumber = divisionNumbers[0];
            var secondNumber = divisionNumbers[1];

            Console.WriteLine($"{firstNumber} / {secondNumber}");
            var result = Console.ReadLine();

            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == firstNumber / secondNumber)
            {
                Console.WriteLine("Your answer was correct! Press enter to continue");
                score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your answer was incorrect. Press enter to continue");
                Console.ReadLine();
            }

            if (i == numbersOfQuestions - 1)
            {
                Console.WriteLine($"Game over. Your final score is {score}.  Press enter to exit");
                Console.ReadLine();
            }
        }

        playTimer.Stop();
        int playTimeInSeconds = Convert.ToInt32(playTimer.ElapsedMilliseconds / 1000);
        
        Helpers.AddToHistory(score, Game.GameType.Division, difficulty, playTimeInSeconds, numbersOfQuestions);
    }

    internal void MultiplicationGame(string message)
    {
        int difficultyUpperBound = 0;
        var difficulty = Helpers.GetDifficulty(out difficultyUpperBound);
        int numbersOfQuestions = Helpers.GetNumbersOfQuestions();

        var random = new Random();
        var score = 0;

        int firstNumber;
        int secondNumber;

        //Calculate the amount of time it takes for player to finish the game
        Stopwatch playTimer = new Stopwatch();
        playTimer.Start();

        for (int i = 0; i < numbersOfQuestions; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            firstNumber = random.Next(1, difficultyUpperBound);
            secondNumber = random.Next(1, difficultyUpperBound);

            Console.WriteLine($"{firstNumber} * {secondNumber}");
            var result = Console.ReadLine();

            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == firstNumber * secondNumber)
            {
                Console.WriteLine("Your answer was correct! Press enter to continue");
                score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your answer was incorrect. Press enter to continue");
                Console.ReadLine();
            }

            if (i == numbersOfQuestions - 1)
            {
                Console.WriteLine($"Game over. Your final score is {score}.  Press enter to exit");
                Console.ReadLine();
            }
        }

        playTimer.Stop();
        int playTimeInSeconds = Convert.ToInt32(playTimer.ElapsedMilliseconds / 1000);

        Helpers.AddToHistory(score, Game.GameType.Multiplication, difficulty, playTimeInSeconds, numbersOfQuestions);
    }
    internal void SubtractionGame(string message)
    {
        int difficultyUpperBound = 0;
        var difficulty = Helpers.GetDifficulty(out difficultyUpperBound);
        int numbersOfQuestions = Helpers.GetNumbersOfQuestions();

        var random = new Random();
        var score = 0;

        int firstNumber;
        int secondNumber;

        //Calculate the amount of time it takes for player to finish the game
        Stopwatch playTimer = new Stopwatch();
        playTimer.Start();

        for (int i = 0; i < numbersOfQuestions; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            firstNumber = random.Next(1, difficultyUpperBound);
            secondNumber = random.Next(1, difficultyUpperBound);

            Console.WriteLine($"{firstNumber} - {secondNumber}");
            var result = Console.ReadLine();

            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == firstNumber - secondNumber)
            {
                Console.WriteLine("Your answer was correct! Press enter to continue");
                score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your answer was incorrect. Press enter to continue");
                Console.ReadLine();
            }

            if (i == numbersOfQuestions - 1)
            {
                Console.WriteLine($"Game over. Your final score is {score}.  Press enter to exit");
                Console.ReadLine();
            }
        }
        playTimer.Stop();
        int playTimeInSeconds = Convert.ToInt32(playTimer.ElapsedMilliseconds / 1000);

        Helpers.AddToHistory(score, Game.GameType.Subtraction, difficulty, playTimeInSeconds, numbersOfQuestions);
    }
    internal void AdditionGame(string message)
    {
        int difficultyUpperBound = 0;
        var difficulty = Helpers.GetDifficulty(out difficultyUpperBound);
        int numbersOfQuestions = Helpers.GetNumbersOfQuestions();

        var random = new Random();
        var score = 0;

        int firstNumber;
        int secondNumber;

        //Calculate the amount of time it takes for player to finish the game
        Stopwatch playTimer = new Stopwatch();
        playTimer.Start();

        for (int i = 0; i < numbersOfQuestions; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            firstNumber = random.Next(1, difficultyUpperBound);
            secondNumber = random.Next(1, difficultyUpperBound);

            Console.WriteLine($"{firstNumber} + {secondNumber}");
            var result = Console.ReadLine();

            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == firstNumber + secondNumber)
            {
                Console.WriteLine("Your answer was correct! Press enter to continue");
                score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your answer was incorrect. Press enter to continue");
                Console.ReadLine();
            }

            if (i == numbersOfQuestions - 1)
            {
                Console.WriteLine($"Game over. Your final score is {score}.  Press enter to exit");
                Console.ReadLine();
            }
        }

        playTimer.Stop();
        int playTimeInSeconds = Convert.ToInt32(playTimer.ElapsedMilliseconds / 1000);

        Helpers.AddToHistory(score, Game.GameType.Addition, difficulty, playTimeInSeconds, numbersOfQuestions);
    }

    internal void RandomGame(string message)
    {
        int difficultyUpperBound = 0;
        var difficulty = Helpers.GetDifficulty(out difficultyUpperBound);
        int numbersOfQuestions = Helpers.GetNumbersOfQuestions();

        var random = new Random();
        var score = 0;

        int firstNumber;
        int secondNumber;

        //Calculate the amount of time it takes for player to finish the game
        Stopwatch playTimer = new Stopwatch();
        playTimer.Start();

        for (int i = 0; i < numbersOfQuestions; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            Random randomMode = new();
            int randomModeNumber = randomMode.Next(0, 4);

            //Division
            if (randomModeNumber == 0)
            {
                var divisionNumbers = Helpers.GetDivisionNumbers(difficultyUpperBound);
                firstNumber = divisionNumbers[0];
                secondNumber = divisionNumbers[1];
            }
            else
            {
            firstNumber = random.Next(1, difficultyUpperBound);
            secondNumber = random.Next(1, difficultyUpperBound);
            }

            switch (randomModeNumber)
            {
                case 0:
                    Console.WriteLine($"{firstNumber} / {secondNumber}");
                    break;
                case 1:
                    Console.WriteLine($"{firstNumber} * {secondNumber}");
                    break;
                case 2:
                    Console.WriteLine($"{firstNumber} + {secondNumber}");
                    break;
                case 3:
                    Console.WriteLine($"{firstNumber} - {secondNumber}");
                    break;
            }

            var result = Console.ReadLine();

            result = Helpers.ValidateResult(result);

            // Checking answer
            int correctAnswer = 0;
            switch (randomModeNumber)
            {
                case 0:
                    correctAnswer = firstNumber / secondNumber;
                    break;
                case 1:
                    correctAnswer = firstNumber * secondNumber;
                    break;
                case 2:
                    correctAnswer = firstNumber + secondNumber;
                    break;
                case 3:
                    correctAnswer = firstNumber - secondNumber;
                    break;
                default:
                    throw new InvalidOperationException("Invalid operation number generated.");
            }

            if (int.Parse(result) == correctAnswer)
            {
                Console.WriteLine("Your answer was correct! Press enter to continue");
                score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your answer was incorrect. Press enter to continue");
                Console.ReadLine();
            }

            if (i == numbersOfQuestions - 1)
            {
                Console.WriteLine($"Game over. Your final score is {score}.  Press enter to exit");
                Console.ReadLine();
            }
        }

        playTimer.Stop();
        int playTimeInSeconds = Convert.ToInt32(playTimer.ElapsedMilliseconds / 1000);

        Helpers.AddToHistory(score, Game.GameType.RandomMode, difficulty, playTimeInSeconds, numbersOfQuestions);
    }
}
