using static MathGame.Matija87.Models.Game;

namespace MathGame.Matija87
{
    internal static class GameEngine
    {
        internal static void Addition()
        {
            Random random = new();
            Console.WriteLine("Addition game");
            Console.WriteLine("-------------");

            int firstNumber;
            int secondNumber;
            int score = 0;
            string? result;

            for (int i = 0; i < 5; i++)
            {
                firstNumber = random.Next(1, 10);
                secondNumber = random.Next(1, 10);
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
            Console.WriteLine("\nPress any key to go back to main menu");
            Console.ReadKey();

            Helpers.AddToHistory(score, GameType.Addition);
        }

        internal static void Subtraction()
        {
            Random random = new();
            Console.WriteLine("Subtraction game");
            Console.WriteLine("-----------------");

            int firstNumber;
            int secondNumber;
            int score = 0;
            string? result;

            for (int i = 0; i < 5; i++)
            {
                firstNumber = random.Next(1, 10);
                secondNumber = random.Next(1, 10);
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
            Console.WriteLine("\nPress any key to go back to main menu");
            Console.ReadKey();
            Helpers.AddToHistory(score, GameType.Subtraction);
        }

        internal static void Multiplication()
        {
            Random random = new();
            Console.WriteLine("Multiplication game");
            Console.WriteLine("--------------------");

            int firstNumber;
            int secondNumber;
            int score = 0;
            string? result;

            for (int i = 0; i < 5; i++)
            {
                firstNumber = random.Next(1, 10);
                secondNumber = random.Next(1, 10);
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
            Console.WriteLine("\nPress any key to go back to main menu");
            Console.ReadKey();
            Helpers.AddToHistory(score, GameType.Multiplication);
        }

        internal static void Division()
        {
            Console.WriteLine("Division game");
            Console.WriteLine("-------------");

            int firstNumber;
            int secondNumber;
            int score = 0;
            string? result;

            for (int i = 0; i < 5; i++)
            {
                int[] divisionNumbers = Helpers.GetDivisionNumbers();
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
            Console.WriteLine("\nPress any key to go back to main menu");
            Console.ReadKey();
            Helpers.AddToHistory(score, GameType.Division);
        }

    }
}
