using BasicMathsProject.Models;

namespace BasicMathsProject
{
    internal class GameEngine
    {
        internal void AdditionGame()
        {
            Console.Clear();
            Console.WriteLine("Addition game selected");

            int score = 0;

            for (int i = 0; i < 5; i++)
            {
                var (firstNumber, secondNumber) = Helpers.GameNumbers();

                Console.WriteLine($"{firstNumber} + {secondNumber}");
                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber + secondNumber)
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine($"Incorrect!");
                }
                if (i != 4)
                {
                    Console.WriteLine($"Press return for the next question");
                    Console.ReadLine();
                }

                if (i == 4)
                {
                    Console.WriteLine($"\nFinished! Your final score was {score}.\nPress enter to return to the main menu");
                    Console.ReadLine();
                }
            }
            Helpers.AddToHistory(score, GameType.Addition);
        }

        internal void SubtractionGame()
        {
            Console.Clear();
            Console.WriteLine("Subtraction game selected");

            int score = 0;

            for (int i = 0; i < 5; i++)
            {
                var (firstNumber, secondNumber) = Helpers.GameNumbers();

                Console.WriteLine($"{firstNumber} - {secondNumber}");
                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber - secondNumber)
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine($"Incorrect!");
                }
                if (i != 4)
                {
                    Console.WriteLine($"Press return for the next question");
                    Console.ReadLine();
                }

                if (i == 4)
                {
                    Console.WriteLine($"\nFinished! Your final score was {score}.\nPress enter to return to the main menu");
                    Console.ReadLine();
                }
            }
            Helpers.AddToHistory(score, GameType.Subtraction);
        }

        internal void MultiplicationGame()
        {
            Console.Clear();
            Console.WriteLine("Multiplication game selected");

            int score = 0;


            for (int i = 0; i < 5; i++)
            {

                var (firstNumber, secondNumber) = Helpers.GameNumbers();

                Console.WriteLine($"{firstNumber} * {secondNumber}");
                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber * secondNumber)
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine($"Incorrect!");
                }
                if (i != 4)
                {
                    Console.WriteLine($"Press return for the next question");
                    Console.ReadLine();
                }

                if (i == 4)
                {
                    Console.WriteLine($"\nFinished! Your final score was {score}.\nPress enter to return to the main menu");
                    Console.ReadLine();
                }
            }
            Helpers.AddToHistory(score, GameType.Multiplication);
        }

        internal void DivisionGame()
        {
            var score = 0;
            Console.Clear();
            Console.WriteLine("Division game selected");
            for (int i = 0; i < 5; i++)
            {
                var (firstNumber, secondNumber) = Helpers.GetDivisionNumbers();

                Console.WriteLine($"{firstNumber} / {secondNumber}");
                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber / secondNumber)
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine($"Incorrect!");
                }
                if (i != 4)
                {
                    Console.WriteLine($"Press return for the next question");
                    Console.ReadLine();
                }

                if (i == 4)
                {
                    Console.WriteLine($"\nFinished! Your final score was {score}.\nPress enter to return to the main menu");
                    Console.ReadLine();
                }
            }
            Helpers.AddToHistory(score, GameType.Division);
        }
    }
}
