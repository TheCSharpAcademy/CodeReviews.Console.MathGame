using System.Diagnostics;

namespace MathGame_
{
    internal class GameEngine
    {
        Stopwatch stopWatch = new Stopwatch();

        internal void RandomGame(string message, string diffText, int difficulty, int numOfQuestions)
        {
            Console.Clear();
            Console.WriteLine("Press [enter] to begin..");
            Console.ReadLine();
            stopWatch.Start();
            message += $" ({diffText}) [{numOfQuestions} Questions]";
            Console.WriteLine(message);
            Console.WriteLine("-------------------------");

            var score = 0;

            int[] divisionNumbers = Helpers.GetDivisionNumbers(difficulty * 10);
            
            for (int i = 0; i < numOfQuestions; i++)
            {
                var divNum1 = divisionNumbers[0];
                var divNum2 = divisionNumbers[1];

                Random random = new Random();
                var operation = random.Next(1, 5);
                var num1 = random.Next(11 + difficulty);
                var num2 = random.Next(11 + difficulty);

                if (operation == 1)
                {
                    Console.Write($"{num1} + {num2} = ");

                    var ans = Console.ReadLine();
                    ans = Helpers.ValidateAns(ans);

                    if (int.Parse(ans) == num1 + num2)
                    {
                        Console.WriteLine("Correct!\n");
                        score++;
                    }

                    else
                    {
                        Console.WriteLine("Incorrect!\n");
                    }
                }

                else if (operation == 2)
                {
                    Console.Write($"{num1} - {num2} = ");

                    var ans = Console.ReadLine();
                    ans = Helpers.ValidateAns(ans);

                    if (int.Parse(ans) == num1 - num2)
                    {
                        Console.WriteLine("Correct!\n");
                        score++;
                    }

                    else
                    {
                        Console.WriteLine("Incorrect!\n");
                    }
                        
                }

                else if (operation == 3)
                {
                    Console.Write($"{num1} * {num2} = ");

                    var ans = Console.ReadLine();
                    ans = Helpers.ValidateAns(ans);

                    if (int.Parse(ans) == num1 * num2)
                    {
                        Console.WriteLine("Correct!\n");
                        score++;
                    }

                    else
                        Console.WriteLine("Incorrect!\n");
                }

                else
                {
                    Console.Write($"{divNum1} / {divNum2} = ");

                    var ans = Console.ReadLine();
                    ans = Helpers.ValidateAns(ans);

                    if (int.Parse(ans) == divNum1 / divNum2)
                    {
                        Console.WriteLine("Correct!\n");
                        score++;
                    }

                    else
                        Console.WriteLine("Incorrect!\n");
                }
                
                divisionNumbers = Helpers.GetDivisionNumbers(difficulty * 10);

            }
            stopWatch.Stop();
            Helpers.AddToHistory(score, message, stopWatch.ElapsedMilliseconds / 1000);
            stopWatch.Reset();

            Console.WriteLine($"Your final score is {score}");
            Console.WriteLine("Press [enter] to return to Main Menu..");
            Console.ReadLine();
        }
        
        internal void DivisionGame(string message, string diffText, int difficulty, int numOfQuestions)
        {
            Console.Clear();
            Console.WriteLine("Press [enter] to begin..");
            Console.ReadLine();
            stopWatch.Start();
            message += $" ({diffText}) [{numOfQuestions} Questions]";
            Console.WriteLine(message);
            Console.WriteLine("-------------------------");
            int[] divisionNumbers = Helpers.GetDivisionNumbers(difficulty * 10);

            var score = 0;

            for (int i = 0; i < numOfQuestions; i++)
            {
                var num1 = divisionNumbers[0];
                var num2 = divisionNumbers[1];

                Console.Write($"{num1} / {num2} = ");

                var ans = Console.ReadLine();
                ans = Helpers.ValidateAns(ans);

                if (int.Parse(ans) == num1 / num2)
                {
                    Console.WriteLine("Correct!\n");
                    score++;
                }

                else
                    Console.WriteLine("Incorrect!\n");

                divisionNumbers = Helpers.GetDivisionNumbers(difficulty * 10);

            }
            stopWatch.Stop();
            Helpers.AddToHistory(score, message, stopWatch.ElapsedMilliseconds / 1000);
            stopWatch.Reset();

            Console.WriteLine($"Your final score is {score}");
            Console.WriteLine("Press [enter] to return to Main Menu..");
            Console.ReadLine();
        }

        internal void MultiplicationGame(string message, string diffText, int difficulty, int numOfQuestions)
        {
            Console.Clear();
            Console.WriteLine("Press [enter] to begin..");
            Console.ReadLine();
            stopWatch.Start();
            message += $" ({diffText}) [{numOfQuestions} Questions]";
            Console.WriteLine(message);
            Console.WriteLine("-------------------------");

            Random random = new Random();

            var score = 0;

            for (int i = 0; i < numOfQuestions; i++)
            {
                var num1 = random.Next(11 + difficulty);
                var num2 = random.Next(11 + difficulty);

                Console.Write($"{num1} * {num2} = ");

                var ans = Console.ReadLine();
                ans = Helpers.ValidateAns(ans);

                if (int.Parse(ans) == num1 * num2)
                {
                    Console.WriteLine("Correct!\n");
                    score++;
                }

                else
                    Console.WriteLine("Incorrect!\n");
            }

            stopWatch.Stop();
            Helpers.AddToHistory(score, message, stopWatch.ElapsedMilliseconds / 1000);
            stopWatch.Reset();

            Console.WriteLine($"Your final score is {score}");
            Console.WriteLine("Press [enter] to return to Main Menu..");
            Console.ReadLine();
        }

        internal void SubtractionGame(string message, string diffText, int difficulty, int numOfQuestions)
        {
            Console.Clear();
            Console.WriteLine("Press [enter] to begin..");
            Console.ReadLine();
            stopWatch.Start();
            message += $" ({diffText}) [{numOfQuestions} Questions]";
            Console.WriteLine(message);
            Console.WriteLine("-------------------------");

            Random random = new Random();

            var score = 0;

            for (int i = 0; i < numOfQuestions; i++)
            {
                var num1 = random.Next(11 + difficulty);
                var num2 = random.Next(11 + difficulty);

                Console.Write($"{num1} - {num2} = ");

                var ans = Console.ReadLine();
                ans = Helpers.ValidateAns(ans);

                if (int.Parse(ans) == num1 - num2)
                {
                    Console.WriteLine("Correct!\n");
                    score++;
                }

                else
                    Console.WriteLine("Incorrect!\n");
            }

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Helpers.AddToHistory(score, message, stopWatch.ElapsedMilliseconds / 1000);
            stopWatch.Reset();

            Console.WriteLine($"Your final score is {score}");
            Console.WriteLine("Press [enter] to return to Main Menu..");
            Console.ReadLine();
        }

        internal void AdditionGame(string message, string diffText, int difficulty, int numOfQuestions)
        {
            Console.Clear();
            Console.WriteLine("Press [enter] to begin..");
            Console.ReadLine();
            stopWatch.Start();
            message += $" ({diffText}) [{numOfQuestions} Questions]";
            Console.WriteLine(message);
            Console.WriteLine("-------------------------");

            Random random = new Random();

            var score = 0;

            for (int i = 0; i < numOfQuestions; i++)
            {
                var num1 = random.Next(11 + difficulty);
                var num2 = random.Next(11 + difficulty);

                Console.Write($"{num1} + {num2} = ");

                var ans = Console.ReadLine();
                ans = Helpers.ValidateAns(ans);

                if (int.Parse(ans) == num1 + num2)
                {
                    Console.WriteLine("Correct!\n");
                    score++;
                }

                else
                    Console.WriteLine("Incorrect!\n");
            }

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Helpers.AddToHistory(score, message, stopWatch.ElapsedMilliseconds / 1000);
            stopWatch.Reset();

            Console.WriteLine($"Your final score is {score}");
            Console.WriteLine("Press [enter] to return to Main Menu..");
            Console.ReadLine();
        }

        private int numberOfQuestions(string difficulty)
        {
            if (difficulty == "Medium")
                return 2;
            else if (difficulty == "Hard")
                return 3;

            return 1;
        }
    }
}
