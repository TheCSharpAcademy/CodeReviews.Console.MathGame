using MathGame.Models;

namespace MathGame
{
    internal class Games
    {

        public int score = 0;

        internal void AdditionGame(int questionAmount)
        {
            Console.Clear();
            Console.WriteLine("Addition game selected");
            Thread.Sleep(500);
            Console.Clear();

            var random = new Random();
            int tempScore = 0;

            for (int i = 0; i < questionAmount; i++)
            {
                int num1 = random.Next(1, 9);
                int num2 = random.Next(1, 9);
                int result = 0;
                string? input;
                bool validAnswer = false;

                do
                {
                    Console.Write($"Question {i + 1} of {questionAmount} : ");
                    Console.WriteLine($"{num1} + {num2}");
                    Console.Write("Answer: ");
                    input = Console.ReadLine();
                    Console.Clear();

                    if (int.TryParse(input, out result))
                    {
                        validAnswer = true;
                    }
                    else
                    {
                        validAnswer = false;
                        Console.WriteLine("Please type a valid number");
                    }
                } while (!validAnswer);

                if (result == num1 + num2)
                {
                    Console.WriteLine("That is correct!\n");
                    Thread.Sleep(500);
                    Console.Clear();
                    score++;
                    tempScore++;
                }
                else
                {
                    Console.WriteLine("That is incorrect :(\n");
                    Thread.Sleep(500);
                    Console.Clear();
                }
            }

            Console.WriteLine($"You got {tempScore} correct out of {questionAmount} questions!");
            Console.WriteLine($"Your current total score is: {score}");

            Helpers.AddToHistory(tempScore, questionAmount, GameType.Addition);

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadLine();
        }

        internal void SubtractionGame(int questionAmount)
        {
            Console.Clear();
            Console.WriteLine("Subtraction game selected");
            Thread.Sleep(500);
            Console.Clear();

            var random = new Random();
            int tempScore = 0;

            for (int i = 0; i < questionAmount; i++)
            {
                int num1 = random.Next(1, 9);
                int num2 = random.Next(1, 9);
                int result = 0;
                string? input;
                bool validAnswer = false;

                do
                {
                    Console.Write($"Question {i + 1} of {questionAmount} : ");
                    Console.WriteLine($"{num1} - {num2}");
                    Console.Write("Answer: ");
                    input = Console.ReadLine();
                    Console.Clear();

                    if (int.TryParse(input, out result))
                    {
                        validAnswer = true;
                    }
                    else
                    {
                        validAnswer = false;
                        Console.WriteLine("Please type a valid number");
                    }
                } while (!validAnswer);

                if (result == num1 - num2)
                {
                    Console.WriteLine("That is correct!\n");
                    Thread.Sleep(500);
                    Console.Clear();
                    score++;
                    tempScore++;
                }
                else
                {
                    Console.WriteLine("That is incorrect :(\n");
                    Thread.Sleep(500);
                    Console.Clear();
                }
            }

            Console.WriteLine($"You got {tempScore} correct out of {questionAmount} questions!");
            Console.WriteLine($"Your current total score is: {score}");

            Helpers.AddToHistory(tempScore, questionAmount, GameType.Subtraction);

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadLine();
        }

        internal void MultiplicationGame(int questionAmount)
        {
            Console.Clear();
            Console.WriteLine("Multiplication game selected");
            Thread.Sleep(500);
            Console.Clear();

            var random = new Random();
            int tempScore = 0;

            for (int i = 0; i < questionAmount; i++)
            {
                int num1 = random.Next(1, 9);
                int num2 = random.Next(1, 9);
                int result = 0;
                string? input;
                bool validAnswer = false;

                do
                {
                    Console.Write($"Question {i + 1} of {questionAmount} : ");
                    Console.WriteLine($"{num1} x {num2}");
                    Console.Write("Answer: ");
                    input = Console.ReadLine();
                    Console.Clear();

                    if (int.TryParse(input, out result))
                    {
                        validAnswer = true;
                    }
                    else
                    {
                        validAnswer = false;
                        Console.WriteLine("Please type a valid number");
                    }
                } while (!validAnswer);

                if (result == num1 * num2)
                {
                    Console.WriteLine("That is correct!\n");
                    Thread.Sleep(500);
                    Console.Clear();
                    score++;
                    tempScore++;
                }
                else
                {
                    Console.WriteLine("That is incorrect :(\n");
                    Thread.Sleep(500);
                    Console.Clear();
                }
            }

            Console.WriteLine($"You got {tempScore} correct out of {questionAmount} questions!");
            Console.WriteLine($"Your current total score is: {score}");

            Helpers.AddToHistory(tempScore, questionAmount, GameType.Multiplication);

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadLine();
        }

        internal void DivisionGame(int questionAmount)
        {
            Console.Clear();
            Console.WriteLine("Division game selected");
            Thread.Sleep(500);
            Console.Clear();

            var random = new Random();
            int tempScore = 0;

            for (int i = 0; i < questionAmount; i++)
            {
                int num1 = random.Next(0, 101);
                int num2 = random.Next(0, 101);
                int result = 0;
                string? input;
                bool validAnswer = false;

                do
                {
                    if (num2 != 0 && num1 % num2 == 0)
                    {
                        validAnswer = true;
                    }
                    else
                    {
                        num1 = random.Next(0, 101);
                        num2 = random.Next(0, 101);
                    }
                }
                while (!validAnswer);

                do
                {
                    Console.Write($"Question {i + 1} of {questionAmount} : ");
                    Console.WriteLine($"{num1} / {num2}");
                    Console.Write("Answer: ");
                    input = Console.ReadLine();
                    Console.Clear();
                    if (int.TryParse(input, out result))
                    {
                        validAnswer = true;
                    }
                    else
                    {
                        validAnswer = false;
                        Console.WriteLine("Please type a valid number");
                    }
                } while (!validAnswer);

                if (result == num1 / num2)
                {
                    Console.WriteLine("That is correct!\n");
                    Thread.Sleep(500);
                    Console.Clear();
                    score++;
                    tempScore++;
                }
                else
                {
                    Console.WriteLine("That is incorrect :(\n");
                    Thread.Sleep(500);
                    Console.Clear();
                }
            }

            Console.WriteLine($"You got {tempScore} correct out of {questionAmount} questions!");
            Console.WriteLine($"Your current total score is: {score}");

            Helpers.AddToHistory(tempScore, questionAmount, GameType.Division);

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadLine();
        }

    }
}
