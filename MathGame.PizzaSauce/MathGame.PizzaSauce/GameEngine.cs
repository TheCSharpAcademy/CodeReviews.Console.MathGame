using MyFirstProgram.Models;
using System.Security.AccessControl;
using static System.Formats.Asn1.AsnWriter;

namespace MyFirstProgram
{
    internal class GameEngine
    {
        string correctMessage = "Correct! Type any key to continue...";
        string wrongMessage = "Not quite. Type any key to continue...";

        internal int AdditionGame(string message, string difficulty, int questions, bool isRandom)
        {
            DateTime startTime = DateTime.Now;
            int score = 0;

            for (int i = 0; i < questions; i++)
            {
                Console.Clear();
                Console.WriteLine(message);
                var random = new Random();

                int lowerValue = 0;
                int upperValue = 0;

                if (difficulty == "Easy")
                {
                    lowerValue = 1;
                    upperValue = 9;
                }
                else if (difficulty == "Medium")
                {
                    lowerValue = 10;
                    upperValue = 99;
                }
                else if (difficulty == "Hard")
                {
                    lowerValue = 100;
                    upperValue = 999;
                }
                int firstNumber = random.Next(lowerValue, upperValue);
                int secondNumber = random.Next(lowerValue, upperValue);

                Console.WriteLine($"{firstNumber} + {secondNumber}");
                var result = Console.ReadLine();
                while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
                {
                    Console.Clear();
                    Console.WriteLine(message);
                    Console.WriteLine($"{firstNumber} + {secondNumber}");
                    Console.WriteLine("Please enter an integer");
                    result = Console.ReadLine();
                }

                if (int.Parse(result) == firstNumber + secondNumber)
                {
                    Console.WriteLine(correctMessage);
                    score++;
                    Console.ReadLine();
                    if (isRandom)
                    {
                        return 1;
                    }
                }
                else
                {
                    Console.WriteLine(wrongMessage);
                    Console.ReadLine();
                    if (isRandom)
                    {
                        return 0;
                    }
                }
            }

            DateTime endTime = DateTime.Now;
            int timeToComplete = Helpers.GetTimeToComplete(startTime, endTime);

            Helpers.AddToHistory(score, GameType.Addition, difficulty, timeToComplete);

            Helpers.DisplayScore(score, questions, timeToComplete);
            return 0;
        }
        internal int SubtractionGame(string message, string difficulty, int questions, bool isRandom)
        {
            DateTime startTime = DateTime.Now;
            int score = 0;

            for (int i = 0; i < questions; i++)
            {
                Console.Clear();
                Console.WriteLine(message);
                var random = new Random();

                int lowerValue = 0;
                int upperValue = 0;

                if (difficulty == "Easy")
                {
                    lowerValue = 1;
                    upperValue = 9;
                }
                else if (difficulty == "Medium")
                {
                    lowerValue = 10;
                    upperValue = 99;
                }
                else if (difficulty == "Hard")
                {
                    lowerValue = 100;
                    upperValue = 999;
                }
                int firstNumber = random.Next(lowerValue, upperValue);
                int secondNumber = random.Next(lowerValue, upperValue);

                Console.WriteLine($"{firstNumber} - {secondNumber}");
                var result = Console.ReadLine();
                while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
                {
                    Console.Clear();
                    Console.WriteLine(message);
                    Console.WriteLine($"{firstNumber} - {secondNumber}");
                    Console.WriteLine("Please enter an integer");
                    result = Console.ReadLine();
                }

                if (int.Parse(result) == firstNumber - secondNumber)
                {
                    Console.WriteLine(correctMessage);
                    score++;
                    Console.ReadLine();
                    if (isRandom)
                    {
                        return 1;
                    }
                }
                else
                {
                    Console.WriteLine(wrongMessage);
                    Console.ReadLine();
                    if (isRandom)
                    {
                        return 0;
                    }
                }
            }

            DateTime endTime = DateTime.Now;
            int timeToComplete = Helpers.GetTimeToComplete(startTime, endTime);

            Helpers.AddToHistory(score, GameType.Subtraction, difficulty, timeToComplete);
            Helpers.DisplayScore(score, questions, timeToComplete);
            return 0;
        }
        internal int MultiplicationGame(string message, string difficulty, int questions, bool isRandom)
        {
            DateTime startTime = DateTime.Now;
            int score = 0;

            for (int i = 0; i < questions; i++)
            {
                Console.Clear();
                Console.WriteLine(message);
                var random = new Random();
                int lowerValue = 0;
                int upperValue = 0;

                if (difficulty == "Easy")
                {
                    lowerValue = 1;
                    upperValue = 9;
                }
                else if (difficulty == "Medium")
                {
                    lowerValue = 10;
                    upperValue = 99;
                }
                else if (difficulty == "Hard")
                {
                    lowerValue = 100;
                    upperValue = 999;
                }
                int firstNumber = random.Next(lowerValue, upperValue);
                int secondNumber = random.Next(lowerValue, upperValue);

                Console.WriteLine($"{firstNumber} * {secondNumber}");
                var result = Console.ReadLine();
                while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
                {
                    Console.Clear();
                    Console.WriteLine(message);
                    Console.WriteLine($"{firstNumber} * {secondNumber}");
                    Console.WriteLine("Please enter an integer");
                    result = Console.ReadLine();
                }

                if (int.Parse(result) == firstNumber * secondNumber)
                {
                    Console.WriteLine(correctMessage);
                    score++;
                    Console.ReadLine();
                    if (isRandom)
                    {
                        return 1;
                    }
                }
                else
                {
                    Console.WriteLine(wrongMessage);
                    Console.ReadLine();
                    if (isRandom)
                    {
                        return 0;
                    }
                }
            }
            DateTime endTime = DateTime.Now;
            int timeToComplete = Helpers.GetTimeToComplete(startTime, endTime);

            Helpers.AddToHistory(score, GameType.Multiplication, difficulty, timeToComplete);
            Helpers.DisplayScore(score, questions, timeToComplete);
            return 0;
        }
        internal int DivisionGame(string message, string difficulty, int questions, bool isRandom)
        {
            DateTime startTime = DateTime.Now;
            int score = 0;
            for (int i = 0; i < questions; i++)
            {
                Console.Clear();
                Console.WriteLine(message);
                var divisionNumbers = Helpers.GetDivisionNumbers(difficulty);
                var firstNumber = divisionNumbers[0];
                var secondNumber = divisionNumbers[1];

                Console.WriteLine($"{firstNumber} / {secondNumber}");
                var result = Console.ReadLine();
                while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
                {
                    Console.Clear();
                    Console.WriteLine(message);
                    Console.WriteLine($"{firstNumber} / {secondNumber}");
                    Console.WriteLine("Please enter an integer");
                    result = Console.ReadLine();
                }

                if (int.Parse(result) == firstNumber / secondNumber)
                {
                    Console.WriteLine(correctMessage);
                    score++;
                    Console.ReadLine();
                    if (isRandom)
                    {
                        return 1;
                    }
                }
                else
                {
                    Console.WriteLine(wrongMessage);
                    Console.ReadLine();
                    if (isRandom)
                    {
                        return 0;
                    }
                }
            }

            DateTime endTime = DateTime.Now;
            int timeToComplete = Helpers.GetTimeToComplete(startTime, endTime);

            Helpers.AddToHistory(score, GameType.Division, difficulty, timeToComplete);
            Helpers.DisplayScore(score, questions, timeToComplete);
            return 0;
        }
        internal void RandomGame(string message, string difficulty, int questions, bool isRandom)
        {
            DateTime startTime = DateTime.Now;
            int score = 0;

            for (int i = 0; i < questions; i++)
            {
                Random random = new Random();
                int gameNo = random.Next(1, 5);
                switch (gameNo)
                {
                    case 1:
                        score += AdditionGame(message, difficulty, 1, isRandom);
                        break;
                    case 2:
                        score += SubtractionGame(message, difficulty, 1, isRandom);
                        break;
                    case 3:
                        score += MultiplicationGame(message, difficulty, 1, isRandom);
                        break;
                    case 4:
                        score += DivisionGame(message, difficulty, 1, isRandom);
                        break;
                }
            }
            DateTime endTime = DateTime.Now;
            int timeToComplete = Helpers.GetTimeToComplete(startTime, endTime);

            Helpers.AddToHistory(score, GameType.Random, difficulty, timeToComplete);

            Helpers.DisplayScore(score, questions, timeToComplete);
        }
    }
}
