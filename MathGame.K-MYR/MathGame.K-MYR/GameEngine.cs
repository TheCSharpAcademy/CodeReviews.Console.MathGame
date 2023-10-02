using MathGame.K_MYR.Models;

namespace MathGame.K_MYR
{
    internal class GameEngine
    {
        internal void DivisionGame()
        {
            Random random = new Random();
            int score = 0;
            for (int i = 0; i < 5; i++)
            {
                Console.Clear();

                var divisionNumbers = Helpers.GetDivisionNumbers();
                int firstNumber = divisionNumbers[0];
                int secondNumber = divisionNumbers[1];

                Console.WriteLine($"{firstNumber} / {secondNumber}");

                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber / secondNumber)
                {
                    Console.WriteLine("Your answer was correct. Press enter for the next question");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Press enter for the next question");
                    Console.ReadLine();
                }

                if (i == 4)
                    Console.WriteLine($"Gamer over. Your final score is {score}");
            }
            Helpers.AddToHistory(score, GameType.Division);
        }

        internal void MultiplicationGame()
        {
            Random random = new Random();
            int score = 0;
            int firstNumber;
            int secondNumber;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();

                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);

                Console.WriteLine($"{firstNumber} * {secondNumber}");

                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber * secondNumber)
                {
                    Console.WriteLine("Your answer was correct. Press enter for the next question");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Press enter for the next question");
                    Console.ReadLine();
                }

                if (i == 4)
                    Console.WriteLine($"Gamer over. Your final score is {score}");
            }
            Helpers.AddToHistory(score, GameType.Multiplication);
        }

        internal void SubtractionGame()
        {
            Random random = new Random();
            int score = 0;
            int firstNumber;
            int secondNumber;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();

                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);

                Console.WriteLine($"{firstNumber} - {secondNumber}");

                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber - secondNumber)
                {
                    Console.WriteLine("Your answer was correct. Press enter for the next question");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Press enter for the next question");
                    Console.ReadLine();
                }

                if (i == 4)
                    Console.WriteLine($"Gamer over. Your final score is {score}");
            }
            Helpers.AddToHistory(score, GameType.Subtraction);
        }

        internal void AdditionGame()
        {
            Random random = new Random();
            int score = 0;
            int firstNumber;
            int secondNumber;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();

                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);

                Console.WriteLine($"{firstNumber} + {secondNumber}");

                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);
                

                if (int.Parse(result) == firstNumber + secondNumber)
                {
                    Console.WriteLine("Your answer was correct. Press enter for the next question");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Press enter for the next question");
                    Console.ReadLine();
                }

                if (i == 4)
                {
                    Console.WriteLine($"Gamer over. Your final score is {score}. Press enter to go back to the main menu.");
                    Console.ReadLine();
                }
            }
            Helpers.AddToHistory(score, GameType.Addition);
        }
    }
}
