using static MathGame.Matija87.Models.Game;

namespace MathGame.Matija87
{
    internal static class GameEngine
    {
        internal static void Addition()
        {
            Random random = new();
            int min=0, max=0;

            DifficultyLevel difficulty = Helpers.Difficulty();

            switch (difficulty)
            {
                case DifficultyLevel.Easy:
                    min = 1;
                    max = 10;
                    break;
                case DifficultyLevel.Medium:
                    min = 5;
                    max = 20;
                    break;
                case DifficultyLevel.Hard:
                    min = 10;
                    max = 50;
                    break;
            }

            int numberOfQuestions = Helpers.NumberOfQuestions();

            Console.WriteLine("Addition game");
            Console.WriteLine("-------------");

            int firstNumber;
            int secondNumber;
            int score = 0;
            string? result;

            DateTime start = DateTime.Now;

            for (int i = 0; i < numberOfQuestions; i++)
            {
                firstNumber = random.Next(min, max);
                secondNumber = random.Next(min, max);
                Console.WriteLine($"{firstNumber} + {secondNumber}");

                result = Console.ReadLine();
                result = Helpers.ValidateResult(result);
                               
                if (int.Parse(result) == firstNumber + secondNumber)
                {
                    score++;
                    Console.WriteLine($"Correct! Your score is {score} / {i + 1}");
                }
                else
                {
                    Console.WriteLine($"Wrong answer! Your score is {score} / {i + 1}");
                }
            }

            DateTime stop = DateTime.Now;
            TimeSpan TimeElapsed = stop - start;
            double Time = TimeElapsed.TotalSeconds;

            Console.WriteLine("\nPress any key to go back to main menu");
            Console.ReadKey();

            Helpers.AddToHistory(score, numberOfQuestions, GameType.Addition, difficulty, Time);
        }

        internal static void Subtraction()
        {
            Random random = new();
            int min = 0, max = 0;

            DifficultyLevel difficulty = Helpers.Difficulty();

            switch (difficulty)
            {
                case DifficultyLevel.Easy:
                    min = 1;
                    max = 10;
                    break;
                case DifficultyLevel.Medium:
                    min = 5;
                    max = 20;
                    break;
                case DifficultyLevel.Hard:
                    min = 10;
                    max = 50;
                    break;
            }

            int numberOfQuestions = Helpers.NumberOfQuestions();

            Console.WriteLine("Subtraction game");
            Console.WriteLine("-----------------");

            int firstNumber;
            int secondNumber;
            int score = 0;
            string? result;

            DateTime start = DateTime.Now;

            for (int i = 0; i < numberOfQuestions; i++)
            {
                firstNumber = random.Next(min, max);
                secondNumber = random.Next(min, max);
                Console.WriteLine($"{firstNumber} - {secondNumber}");

                result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber - secondNumber)
                {
                    score++;
                    Console.WriteLine($"Correct! Your score is {score} / {i + 1}");
                }
                else
                {
                    Console.WriteLine($"Wrong answer! Your score is {score} / {i + 1}");
                }
            }

            DateTime stop = DateTime.Now;
            TimeSpan TimeElapsed = stop - start;
            double Time = TimeElapsed.TotalSeconds;

            Console.WriteLine("\nPress any key to go back to main menu");
            Console.ReadKey();
            Helpers.AddToHistory(score,numberOfQuestions, GameType.Subtraction, difficulty, Time);
        }

        internal static void Multiplication()
        {
            Random random = new();
            int min = 0, max = 0;

            DifficultyLevel difficulty = Helpers.Difficulty();

            switch (difficulty)
            {
                case DifficultyLevel.Easy:
                    min = 1;
                    max = 10;
                    break;
                case DifficultyLevel.Medium:
                    min = 5;
                    max = 20;
                    break;
                case DifficultyLevel.Hard:
                    min = 10;
                    max = 50;
                    break;
            };

            int numberOfQuestions = Helpers.NumberOfQuestions();

            Console.WriteLine("Multiplication game");
            Console.WriteLine("--------------------");

            int firstNumber;
            int secondNumber;
            int score = 0;
            string? result;

            DateTime start = DateTime.Now;

            for (int i = 0; i < numberOfQuestions; i++)
            {
                firstNumber = random.Next(min, max);
                secondNumber = random.Next(min, max);
                Console.WriteLine($"{firstNumber} * {secondNumber}");

                result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber * secondNumber)
                {
                    score++;
                    Console.WriteLine($"Correct! Your score is {score} / {i + 1}");
                }
                else
                {
                    Console.WriteLine($"Wrong answer! Your score is {score} / {i + 1}");
                }
            }

            DateTime stop = DateTime.Now;
            TimeSpan TimeElapsed = stop - start;
            double Time = TimeElapsed.TotalSeconds;

            Console.WriteLine("\nPress any key to go back to main menu");
            Console.ReadKey();
            Helpers.AddToHistory(score, numberOfQuestions, GameType.Multiplication, difficulty, Time);
        }

        internal static void Division()
        {
            int min = 0, max = 0;

            DifficultyLevel difficulty = Helpers.Difficulty();

            switch (difficulty)
            {
                case DifficultyLevel.Easy:
                    min = 1;
                    max = 20;
                    break;
                case DifficultyLevel.Medium:
                    min = 2;
                    max = 100;
                    break;
                case DifficultyLevel.Hard:
                    min = 3;
                    max = 200;
                    break;
            };

            int numberOfQuestions = Helpers.NumberOfQuestions();

            Console.WriteLine("Division game");
            Console.WriteLine("-------------");

            int firstNumber;
            int secondNumber;
            int score = 0;
            string? result;

            DateTime start = DateTime.Now;

            for (int i = 0; i < numberOfQuestions; i++)
            {
                int[] divisionNumbers = Helpers.GetDivisionNumbers(min, max);
                firstNumber = divisionNumbers[0];
                secondNumber = divisionNumbers[1];

                Console.WriteLine($"{firstNumber} / {secondNumber}");

                result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber / secondNumber)
                {
                    score++;
                    Console.WriteLine($"Correct! Your score is {score} / {i + 1}");
                }
                else
                {
                    Console.WriteLine($"Wrong answer! Your score is {score} / {i + 1}");
                }
            }

            DateTime stop = DateTime.Now;
            TimeSpan TimeElapsed = stop - start;
            double Time = TimeElapsed.TotalSeconds;

            Console.WriteLine("\nPress any key to go back to main menu");
            Console.ReadKey();
            Helpers.AddToHistory(score, numberOfQuestions, GameType.Division, difficulty, Time);
        }
    }
}
