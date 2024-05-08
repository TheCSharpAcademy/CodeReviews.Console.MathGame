using MathGame.models;
using System.Diagnostics;

namespace MathGame
{
    internal class GameEngine
    {
        static TimeSpan time;
        static Stopwatch stopwatch = new Stopwatch();

        internal void AdditionGame(string message)
        {
            Random random = new Random();

            int score = 0;

            int num1 = 0;
            int num2 = 0;
            Console.WriteLine("how many questions do you want?");
            var input = Console.ReadLine();
            int questionCount = Helpers.ExceptionHandledInt32Parse(input);

            Console.WriteLine("enter difficulty: \n1 - easy. numbers 1-10 \n2 - medium. numbers 1-20 \n3 - hard. numbers 10-50. \n4 - you're just being ridiculous now.");
            input = Console.ReadLine();
            int difficulty = Helpers.ExceptionHandledInt32Parse(input);
            for (int i = 0; i < questionCount; i++)
            {
                Console.Clear();
                Console.WriteLine(message);
                switch (difficulty)
                {
                    case 1:
                        num1 = random.Next(1, 10);
                        num2 = random.Next(1, 10);
                        break;
                    case 2:
                        num1 = random.Next(1, 20);
                        num2 = random.Next(1, 20);
                        break;
                    case 3:
                        num1 = random.Next(10, 50);
                        num2 = random.Next(10, 50);
                        break;
                    case 4:
                        num1 = random.Next(1, 1000);
                        num2 = random.Next(1, 1000);
                        break;
                    default:
                        Console.WriteLine("invalid input. starting on easy.");
                        num1 = random.Next(1, 10);
                        num2 = random.Next(1, 10);
                        break;
                }
                

                Console.WriteLine($"{num1} + {num2}");
                stopwatch.Start();
                input = Console.ReadLine();
                int answer = Helpers.ExceptionHandledInt32Parse(input);

                if (answer == num1 + num2)
                {
                    Console.WriteLine("Correct! type any key to continue.");
                    Console.ReadLine();
                    score += 1;
                }
                else
                {
                    Console.WriteLine($"Incorrect. type any key to continue.");
                    Console.ReadLine();
                }

                if (i == questionCount - 1)
                {
                    stopwatch.Stop();
                    time = stopwatch.Elapsed;
                    Console.WriteLine($"Game over. your final score is: {score}. you took {time}. enter any key to return to menu");
                    Console.ReadLine();
                }
            }

            Helpers.AddToHistory(score, GameType.Addition, time);
            Console.Clear();
        }

        internal void SubtractionGame(string message)
        {
            Random random = new Random();

            int score = 0;

            int num1;
            int num2;

            Console.WriteLine("how many questions do you want?");
            var input = Console.ReadLine();
            int questionCount = Helpers.ExceptionHandledInt32Parse(input);

            Console.WriteLine("enter difficulty: \n1 - easy. numbers 1-10 \n2 - medium. numbers 1-20 \n3 - hard. numbers 10-50. \n4 - you're just being ridiculous now.");
            input = Console.ReadLine();
            int difficulty = Helpers.ExceptionHandledInt32Parse(input);

            for (int i = 0; i < questionCount; i++)
            {
                Console.Clear();
                Console.WriteLine(message);
                switch (difficulty)
                {
                    case 1:
                        num1 = random.Next(1, 10);
                        num2 = random.Next(1, 10);
                        break;
                    case 2:
                        num1 = random.Next(1, 20);
                        num2 = random.Next(1, 20);
                        break;
                    case 3:
                        num1 = random.Next(10, 50);
                        num2 = random.Next(10, 50);
                        break;
                    case 4:
                        num1 = random.Next(1, 1000);
                        num2 = random.Next(1, 1000);
                        break;
                    default:
                        Console.WriteLine("invalid input. starting on easy.");
                        num1 = random.Next(1, 10);
                        num2 = random.Next(1, 10);
                        break;
                }

                Console.WriteLine($"{num1} - {num2}");

                stopwatch.Start();

                input = Console.ReadLine();
                int answer = Helpers.ExceptionHandledInt32Parse(input);

                if (answer == num1 - num2)
                {
                    Console.WriteLine("Correct! type any key to continue.");
                    Console.ReadLine();
                    score += 1;
                }
                else
                {
                    Console.WriteLine($"Incorrect. type any key to continue.");
                    Console.ReadLine();
                }

                if (i == Convert.ToInt32(questionCount) - 1)
                {
                    stopwatch.Stop();
                    time = stopwatch.Elapsed;
                    Console.WriteLine($"Game over. your final score is: {score}. you took {time}. enter any key to reutrn to mwnu");
                    Console.ReadLine();
                }

            }

            Helpers.AddToHistory(score, GameType.Subtraction, time);

            Console.Clear();
        }

        internal void MultiplicationGame(string message)
        {
            Random random = new Random();

            int score = 0;

            int num1;
            int num2;

            Console.WriteLine("how many questions do you want?");
            var input = Console.ReadLine();
            int questionCount = Helpers.ExceptionHandledInt32Parse(input);

            Console.WriteLine("enter difficulty: \n1 - easy. numbers 1-10 \n2 - medium. numbers 1-20 \n3 - hard. numbers 10-50. \n4 - you're just being ridiculous now.");

            input = Console.ReadLine();
            int difficulty = Helpers.ExceptionHandledInt32Parse(input);

            for (int i = 0; i < questionCount; i++)
            {
                Console.Clear();
                Console.WriteLine(message);
                switch (difficulty)
                {
                    case 1:
                        num1 = random.Next(1, 10);
                        num2 = random.Next(1, 10);
                        break;
                    case 2:
                        num1 = random.Next(1, 20);
                        num2 = random.Next(1, 20);
                        break;
                    case 3:
                        num1 = random.Next(10, 50);
                        num2 = random.Next(10, 50);
                        break;
                    case 4:
                        num1 = random.Next(1, 1000);
                        num2 = random.Next(1, 1000);
                        break;
                    default:
                        Console.WriteLine("invalid input. starting on easy.");
                        num1 = random.Next(1, 10);
                        num2 = random.Next(1, 10);
                        break;
                }

                Console.WriteLine($"{num1} x {num2}");

                stopwatch.Start();

                input = Console.ReadLine();
                int answer = Helpers.ExceptionHandledInt32Parse(input);

                if (answer == num1 * num2)
                {
                    Console.WriteLine("Correct! type any key to continue.");
                    Console.ReadLine();
                    score += 1;
                }
                else
                {
                    Console.WriteLine($"Incorrect. type any key to continue.");
                    Console.ReadLine();
                }

                if (i == questionCount - 1)
                {
                    stopwatch.Stop();
                    time = stopwatch.Elapsed;
                    Console.WriteLine($"Game over. your final score is: {score}. you took {time}. enter any key to reutrn to mwnu");
                    Console.ReadLine();
                }
            }

            Helpers.AddToHistory(score, GameType.Multiplication, time);
            Console.Clear();
        }

        internal void DivisionGame(string message)
        {

            int score = 0;
            Console.WriteLine("how many questions do you want?");
            var input = Console.ReadLine();
            int questionCount = Helpers.ExceptionHandledInt32Parse(input);

            Console.WriteLine("enter difficulty: \n1 - easy. numbers 1-20 \n2 - medium. numbers 1-50 \n3 - hard. numbers 1-100. \n4 - you're just being ridiculous now.");
            input = Console.ReadLine();
            int difficulty = Helpers.ExceptionHandledInt32Parse(input);

            for (int i = 0; i < questionCount; i++)
            {
                Console.Clear();
                Console.WriteLine(message);

                int[] divisionNumbers = Helpers.GetDivisionNumbers(difficulty);
                int firstNumber = divisionNumbers[0];
                int secondNumber = divisionNumbers[1];

                Console.WriteLine($"{firstNumber} / {secondNumber}");
                stopwatch.Start();
                int result = Convert.ToInt32(Console.ReadLine());

                if (result == firstNumber / secondNumber)
                {
                    Console.WriteLine("Correct! type any key to continue.");
                    Console.ReadLine();
                    score += 1;
                }
                else
                {
                    Console.WriteLine($"Incorrect. type any key to continue.");
                    Console.ReadLine();
                }

                if (i == questionCount - 1)
                {
                    stopwatch.Stop();
                    time = stopwatch.Elapsed;
                    Console.WriteLine($"Game over. your final score is: {score}. you took {time}. enter any key to reutrn to mwnu");
                    Console.ReadLine();
                }

            }

            Helpers.AddToHistory(score, GameType.Division, time);
            Console.Clear();
        }

        internal void RandomGame(string message)
        {
            Random random = new Random();
            int score = 0;
            Console.WriteLine("How many question do you want");
            var input = Console.ReadLine();
            int questionsCount = Helpers.ExceptionHandledInt32Parse(input);

            for (int i = 0; i < questionsCount; i++)
            {
                char[] operators = { '+', '-', '*', '/' };

                int randomOperatorIndex = random.Next(0, operators.Length);

                int num1 = random.Next(1, 40);
                int num2 = random.Next(1, 40);
                bool inadequateNumbers = false;

                if (randomOperatorIndex == 3 && num1 % num2 != 0)
                {
                    inadequateNumbers = true;

                    while (inadequateNumbers)
                    {
                        num1 = random.Next(1, 40);
                        num2 = random.Next(1, 40);
                        if (num1 % num2 == 0)
                        {
                            inadequateNumbers = false;
                        }
                    }
                }
                else if(randomOperatorIndex == 2)
                {
                    num1 = random.Next(1, 10);
                    num2 = random.Next(1, 10);
                }
                Console.Clear();
                Console.WriteLine($"{num1}{operators[randomOperatorIndex]}{num2}");
                input = Console.ReadLine();
                int answer = Helpers.ExceptionHandledInt32Parse(input);

                switch (randomOperatorIndex)
                {
                    case 0:
                        if (answer == num1 + num2)
                        {
                            Console.WriteLine("Correct. enter any key to continue.");
                            score++;
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("incorrect. enter any key to continue");
                            score++;
                            Console.ReadLine();
                        }
                        break;
                    case 1:
                        if (answer == num1 - num2)
                        {
                            Console.WriteLine("Correct. enter any key to continue.");
                            score++;
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("incorrect. enter any key to continue");
                            score++;
                            Console.ReadLine();
                        }
                        break;
                    case 2:
                        if (answer == num1 * num2)
                        {
                            Console.WriteLine("Correct. enter any key to continue.");
                            score++;
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("incorrect. enter any key to continue");
                            score++;
                            Console.ReadLine();
                        }
                        break;
                    case 3:
                        if (answer == num1 / num2)
                        {
                            Console.WriteLine("Correct. enter any key to continue.");
                            score++;
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("incorrect. enter any key to continue");
                            score++;
                            Console.ReadLine();
                        }
                        break;
                }
     
                if(i == questionsCount - 1)
                {
                    Helpers.AddToHistory(score, GameType.Random, time);
                    Console.Clear();
                }
            }
        }
            
    }
}
