using SimpleMathGame.Models;

namespace SimpleMathGame
{
    internal class GameEngine
    {
        //gameplay variables
        int amountOfQuestions = 5;
        int score = 0;

        internal void DivisionGame(string message)  
        {
            for (int i = 0; i < amountOfQuestions; i++)
            {
                Console.Clear();
                Console.WriteLine(message);

                int[] divisionNumbers = Helpers.GetDivisionNumbers();
                int firstNumber = divisionNumbers[0];
                int secondNumber = divisionNumbers[1];

                Console.WriteLine($"{firstNumber} / {secondNumber}");
                string? result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber / secondNumber)
                {
                    Console.WriteLine($"Correct :)");
                    score++;
                    Thread.Sleep(500);
                }
                else
                {
                    Console.WriteLine($"Not really :(");
                    Thread.Sleep(500);
                }

                if (i == amountOfQuestions - 1)
                {
                    Console.Clear();
                    Console.WriteLine($"Your final score is {score} / {amountOfQuestions}");
                }
            }

            Helpers.AddToHistory(score, GameType.Division, amountOfQuestions);
            Helpers.ClickToContinue();
        }
        internal void MultiplicationGame(string message)
        {
            Random random = new Random();

            int firstNumber;
            int secondNumber;

            for (int i = 0; i < amountOfQuestions; i++)
            {
                Console.Clear();
                Console.WriteLine(message);

                firstNumber = random.Next(0, 9);
                secondNumber = random.Next(0, 9);

                Console.WriteLine($"{firstNumber} * {secondNumber}");
                string? result = Console.ReadLine();

                if (int.Parse(result) == firstNumber * secondNumber)
                {
                    Console.WriteLine($"Correct :)");
                    score++;
                    Thread.Sleep(500);

                }
                else
                {
                    Console.WriteLine($"Not really :(");
                    Thread.Sleep(500);
                }

                if (i == amountOfQuestions - 1)
                {
                    Console.Clear();
                    Console.WriteLine($"Your final score is {score} / {amountOfQuestions}");
                }
            }

            Helpers.AddToHistory(score, GameType.Multiplication, amountOfQuestions);
            Helpers.ClickToContinue();
        }
        internal void AdditionGame(string message)
        {
            Random random = new Random();

            int firstNumber;
            int secondNumber;

            for (int i = 0; i < amountOfQuestions; i++)
            {
                Console.Clear();
                Console.WriteLine(message);

                firstNumber = random.Next(0, 9);
                secondNumber = random.Next(0, 9);

                Console.WriteLine($"{firstNumber} + {secondNumber}");
                string? result = Console.ReadLine();

                if (int.Parse(result) == firstNumber + secondNumber)
                {
                    Console.WriteLine($"Correct :)");
                    score++;
                    Thread.Sleep(500);
                }
                else
                {
                    Console.WriteLine($"Not really :(");
                    Thread.Sleep(500);
                }

                if (i == amountOfQuestions - 1)
                {
                    Console.Clear();
                    Console.WriteLine($"Your final score is {score} / {amountOfQuestions}");
                }
            }

            Helpers.AddToHistory(score, GameType.Addition, amountOfQuestions);
            Helpers.ClickToContinue();
        }
        internal void SubtractionGame(string message)
        {
            Random random = new Random();

            int firstNumber;
            int secondNumber;

            for (int i = 0; i < amountOfQuestions; i++)
            {
                Console.Clear();
                Console.WriteLine(message);

                firstNumber = random.Next(0, 9);
                secondNumber = random.Next(0, 9);

                Console.WriteLine($"{firstNumber} - {secondNumber}");
                string? result = Console.ReadLine();

                if (int.Parse(result) == firstNumber - secondNumber)
                {
                    Console.WriteLine($"Correct :)");
                    score++;
                    Thread.Sleep(500);
                }
                else
                {
                    Console.WriteLine($"Not really :(");
                    Thread.Sleep(500);
                }

                if (i == amountOfQuestions - 1)
                {
                    Console.Clear();
                    Console.WriteLine($"Your final score is {score} / {amountOfQuestions}");
                }
            }

            Helpers.AddToHistory(score, GameType.Subtraction, amountOfQuestions);
            Helpers.ClickToContinue();
        }
    }
}
