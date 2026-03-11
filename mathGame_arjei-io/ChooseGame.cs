using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MathGame
{
    internal class ChooseGame
    {
        internal void AdditionGame(string difficulty)
        {
            int score = 0;
            Random random = new Random();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            for (int i = 0; i < 5; i++)
            {
                int num1 = random.Next(0, 10);
                int num2 = random.Next(0, 10);

                if (difficulty.Trim().ToLower().Equals("hard"))
                {
                    num1 = random.Next(10, 100);
                    num2 = random.Next(10, 100);
                }

                Console.Clear();
                Console.WriteLine($"What's {num1} + {num2}");
                var result = Console.ReadLine();

                while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
                {
                    Console.WriteLine("Please enter an integer");
                    result = Console.ReadLine();
                }

                if (int.Parse(result) == num1 + num2)
                {
                    score++;
                    Console.WriteLine("Correct! Press 'enter' to continue");
                    Console.ReadLine();
                }
                else if (int.Parse(result) != num1 + num2)
                {
                    Console.WriteLine("Incorrect! Press 'enter' to continue");
                    result = Console.ReadLine();
                }

                if (i == 4)
                {
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0}", ts.Seconds);
                    Console.Clear();
                    Console.WriteLine("Thanks for playing.");
                    Console.WriteLine($"Completion time: {elapsedTime} seconds - Score: {score}");
                    Console.WriteLine("Press 'enter' to return to menu");
                    Console.ReadLine();
                    Helpers.AddToList(score, difficulty, GameType.Addition, elapsedTime);
                }
            }
        }

        internal void SubtractionGame(string difficulty)
        {
            int score = 0;
            Random random = new Random();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();



            for (int i = 0; i < 5; i++)
            {
                int num1 = random.Next(0, 10);
                int num2 = random.Next(0, 10);

                if (difficulty.Trim().ToLower().Equals("hard"))
                {
                    num1 = random.Next(10, 100);
                    num2 = random.Next(10, 100);
                }

                Console.Clear();
                Console.WriteLine($"What's {num1} - {num2}");
                var result = Console.ReadLine();

                while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
                {
                    Console.WriteLine("Please enter an integer");
                    result = Console.ReadLine();
                }

                if (int.Parse(result) == num1 - num2)
                {
                    score++;
                    Console.WriteLine("Correct! Press 'enter' to continue");
                    Console.ReadLine();
                }
                else if (int.Parse(result) != num1 - num2)
                {
                    Console.WriteLine("Incorrect! Press 'enter' to continue");
                    result = Console.ReadLine();
                }

                if (i == 4)
                {
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0}", ts.Seconds);
                    Console.Clear();
                    Console.WriteLine("Thanks for playing.");
                    Console.WriteLine($"Completion time: {elapsedTime} seconds - Score: {score}");
                    Console.WriteLine("Press 'enter' to return to menu");
                    Console.ReadLine();
                    Helpers.AddToList(score, difficulty, GameType.Subtraction, elapsedTime);
                }
            }
        }

        internal void DivisionGame(string difficulty)
        {
            int score = 0;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                int num1 = random.Next(1, 100);
                int num2 = random.Next(1, 100);

                if (difficulty.Trim().ToLower().Equals("hard"))
                {
                    num1 = random.Next(10, 100);
                    num2 = random.Next(10, 100);
                }



                while (num1 % num2 != 0)
                {
                    num1 = random.Next(1, 100);
                    num2 = random.Next(1, 100);

                    if (difficulty.Trim().ToLower().Equals("hard"))
                    {
                        num1 = random.Next(100, 1000);
                        num2 = random.Next(100, 1000);
                    }
                }

                int validNum1 = num1;
                int validNum2 = num2;

                Console.Clear();
                Console.WriteLine($"What's {validNum1} / {validNum2}");
                var result = Console.ReadLine();

                while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
                {
                    Console.WriteLine("Please enter an integer");
                    result = Console.ReadLine();
                }

                if (int.Parse(result) == validNum1 / validNum2)
                {
                    score++;
                    Console.WriteLine("Correct! Press 'enter' to continue");
                    Console.ReadLine();
                }
                else if (int.Parse(result) != validNum1 / validNum2)
                {
                    Console.WriteLine("Incorrect! Press 'enter' to continue");
                    result = Console.ReadLine();
                }

                if (i == 4)
                {
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0}", ts.Seconds);
                    Console.Clear();
                    Console.WriteLine("Thanks for playing.");
                    Console.WriteLine($"Completion time: {elapsedTime} seconds - Score: {score}");
                    Console.WriteLine("Press 'enter' to return to menu");
                    Console.ReadLine();
                    Helpers.AddToList(score, difficulty, GameType.Division, elapsedTime);
                }
            }

        }

        internal void MultiplyGame(string difficulty)
        {
            int score = 0;
            Random random = new Random();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            for (int i = 0; i < 5; i++)
            {
                int num1 = random.Next(0, 9);
                int num2 = random.Next(0, 9);

                if (difficulty.Trim().ToLower().Equals("hard"))
                {
                    num1 = random.Next(10, 100);
                    num2 = random.Next(10, 100);
                }

                Console.Clear();
                Console.WriteLine($"What's {num1} * {num2}");
                var result = Console.ReadLine();

                while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
                {
                    Console.WriteLine("Please enter an integer");
                    result = Console.ReadLine();
                }

                if (int.Parse(result) == num1 * num2)
                {
                    score++;
                    Console.WriteLine("Correct! Press 'enter' to continue");
                    Console.ReadLine();
                }
                else if (int.Parse(result) != num1 * num2)
                {
                    Console.WriteLine("Incorrect! Press 'enter' to continue");
                    result = Console.ReadLine();
                }

                if (i == 4)
                {
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0}", ts.Seconds);
                    Console.Clear();
                    Console.WriteLine("Thanks for playing.");
                    Console.WriteLine($"Completion time: {elapsedTime} seconds - Score:  {score}");
                    Console.WriteLine("Press 'enter' to return to menu");
                    Console.ReadLine();
                    Helpers.AddToList(score, difficulty, GameType.Multiplication, elapsedTime);
                }
            }
            
        }

        internal void RandomGame(string difficulty)
        {
            int score = 0;
            Random random = new Random();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            for (int i = 0; i < 5; i++)
            {
                int operationNum = random.Next(1, 5);
                int num1 = random.Next(0, 10);
                int num2 = random.Next(0, 10);

                if (difficulty.Trim().ToLower().Equals("hard"))
                {
                    num1 = random.Next(10, 100);
                    num2 = random.Next(10, 100);
                }

                switch (operationNum)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine($"What's {num1} + {num2}");
                        var result = Console.ReadLine();

                        while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
                        {
                            Console.WriteLine("Please enter an integer");
                            result = Console.ReadLine();
                        }

                        if (int.Parse(result) == num1 + num2)
                        {
                            score++;
                            Console.WriteLine("Correct! Press 'enter' to continue");
                            Console.ReadLine();
                        }
                        else if (int.Parse(result) != num1 + num2)
                        {
                            Console.WriteLine("Incorrect! Press 'enter' to continue");
                            result = Console.ReadLine();
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine($"What's {num1} - {num2}");
                        result = Console.ReadLine();

                        while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
                        {
                            Console.WriteLine("Please enter an integer");
                            result = Console.ReadLine();
                        }

                        if (int.Parse(result) == num1 - num2)
                        {
                            score++;
                            Console.WriteLine("Correct! Press 'enter' to continue");
                            Console.ReadLine();
                        }
                        else if (int.Parse(result) != num1 - num2)
                        {
                            Console.WriteLine("Incorrect! Press 'enter' to continue");
                            result = Console.ReadLine();
                        }
                        break;
                    case 3:
                        while (num1 % num2 != 0)
                        {
                            num1 = random.Next(1, 100);
                            num2 = random.Next(1, 100);

                            if (difficulty.Trim().ToLower().Equals("hard"))
                            {
                                num1 = random.Next(100, 1000);
                                num2 = random.Next(100, 1000);
                            }
                        }

                        int validNum1 = num1;
                        int validNum2 = num2;

                        Console.Clear();
                        Console.WriteLine($"What's {validNum1} / {validNum2}");
                        result = Console.ReadLine();

                        while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
                        {
                            Console.WriteLine("Please enter an integer");
                            result = Console.ReadLine();
                        }

                        if (int.Parse(result) == validNum1 / validNum2)
                        {
                            score++;
                            Console.WriteLine("Correct! Press 'enter' to continue");
                            Console.ReadLine();
                        }
                        else if (int.Parse(result) != validNum1 / validNum2)
                        {
                            Console.WriteLine("Incorrect! Press 'enter' to continue");
                            result = Console.ReadLine();
                        }
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine($"What's {num1} * {num2}");
                        result = Console.ReadLine();

                        while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
                        {
                            Console.WriteLine("Please enter an integer");
                            result = Console.ReadLine();
                        }

                        if (int.Parse(result) == num1 * num2)
                        {
                            score++;
                            Console.WriteLine("Correct! Press 'enter' to continue");
                            Console.ReadLine();
                        }
                        else if (int.Parse(result) != num1 * num2)
                        {
                            Console.WriteLine("Incorrect! Press 'enter' to continue");
                            result = Console.ReadLine();
                        }
                        break;
                    default:
                        Console.WriteLine("No valid number");
                        break;
                }
                if (i == 4)
                {
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0}", ts.Seconds);
                    Console.Clear();
                    Console.WriteLine("Thanks for playing.");
                    Console.WriteLine($"Completion time: {elapsedTime} seconds - Score:  {score}");
                    Console.WriteLine("Press 'enter' to return to menu");
                    Console.ReadLine();
                    Helpers.AddToList(score, difficulty, GameType.Random, elapsedTime);
                }
            }
            Console.WriteLine("Random Game");
        }
    }
}