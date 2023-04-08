using System.Diagnostics;

namespace Math_Game
{
    internal class GameEngine
    {
        internal static void divisionGame(string message)
        {
            Console.WriteLine(message);
            var timer = new Stopwatch();
            var random = new Random();
            var score = 0;
            var difficulty = Helpers.Difficulty();
            var count = Helpers.NumberOfQuestions();

            for (int i = 0; i < count; i++)
            {
                if (i == 0)
                {
                    timer.Start();
                }
                Console.Clear();
                Console.WriteLine(message);
                if (difficulty == "e")
                {
                    var divisionNumbers = Helpers.GetDivisionNumbers();
                    var firstNumber = divisionNumbers[0];
                    var secondNumber = divisionNumbers[1];
                    Console.WriteLine($"{firstNumber} / {secondNumber}");
                    var result = Console.ReadLine();
                    if (int.Parse(result) == firstNumber / secondNumber)
                    {
                        Console.WriteLine("Your answer was correct! Type any key for the next question");
                        score++;
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                        Console.ReadLine();
                    }
                    if (i == count - 1)
                    {
                        Console.WriteLine($"Game over. Your final score is {score}. Press a button to go back to menu");
                        Console.ReadLine();
                    }
                }
                else
                {
                    var divisionNumbers = Helpers.GetDivisionNumbersHard();
                    var firstNumber = divisionNumbers[0];
                    var secondNumber = divisionNumbers[1];
                    Console.WriteLine($"{firstNumber} / {secondNumber}");
                    var result = Console.ReadLine();

                    if (int.Parse(result) == firstNumber / secondNumber)
                    {
                        Console.WriteLine("Your answer was correct! Type any key for the next question");
                        score++;
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                        Console.ReadLine();
                    }
                    if (i == count - 1)
                    {
                        Console.WriteLine($"Game over. Your final score is {score}. Press a button to go back to menu");
                        Console.ReadLine();
                    }
                }
            }

            Helpers.AddToHistory(score, "Division");
        }

        internal static void multiplicationGame(string message)
        {
            {
                Console.WriteLine(message);
                var timer = new Stopwatch();
                TimeSpan timeTaken = timer.Elapsed;
                var random = new Random();
                var score = 0;
                int firstNumber;
                int secondNumber;
                var difficulty = Helpers.Difficulty();
                var count = Helpers.NumberOfQuestions();

                for (int i = 0; i < count; i++)
                {
                    if (i == 0)
                    {
                        timer.Start();
                    }
                    Console.Clear();
                    Console.WriteLine(message);

                    if (difficulty == "e")
                    {
                        firstNumber = random.Next(1, 9);
                        secondNumber = random.Next(1, 9);
                    }
                    else
                    {
                        firstNumber = random.Next(25, 125);
                        secondNumber = random.Next(25, 125);
                    }

                    Console.WriteLine($"{firstNumber} * {secondNumber}");
                    var result = Console.ReadLine();

                    if (int.Parse(result) == firstNumber * secondNumber)
                    {
                        Console.WriteLine("Your answer was correct! Type any key for the next question");
                        score++;
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                        Console.ReadLine();
                    }
                    if (i == count - 1)
                    {
                        timer.Stop();
                        Console.WriteLine($"Game over. Your final score is {score} and it took you {timer.Elapsed.ToString(@"m\:ss\.fff")} to complete. Press a button to go back to menu");
                        Console.ReadLine();
                    }
                }
                Helpers.AddToHistory(score, "Multiplication");
            }
        }

        internal static void subtractionGame(string message)
        {
            {
                Console.WriteLine(message);
                var timer = new Stopwatch();
                TimeSpan timeTaken = timer.Elapsed;
                var random = new Random();
                var score = 0;
                int firstNumber;
                int secondNumber;
                var difficulty = Helpers.Difficulty();
                var count = Helpers.NumberOfQuestions();

                for (int i = 0; i < count; i++)
                {
                    if (i == 0)
                    {
                        timer.Start();
                    }
                    Console.Clear();
                    Console.WriteLine(message);

                    if (difficulty == "e")
                    {
                        firstNumber = random.Next(1, 9);
                        secondNumber = random.Next(1, 9);
                    }
                    else
                    {
                        firstNumber = random.Next(25, 125);
                        secondNumber = random.Next(25, 125);
                    }


                    Console.WriteLine($"{firstNumber} - {secondNumber}");
                    var result = Console.ReadLine();

                    if (int.Parse(result) == firstNumber - secondNumber)
                    {
                        Console.WriteLine("Your answer was correct! Type any key for the next question");
                        score++;
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                        Console.ReadLine();
                    }
                    if (i == count - 1)
                    {
                        timer.Stop();
                        Console.WriteLine($"Game over. Your final score is {score} and it took you {timer.Elapsed.ToString(@"m\:ss\.fff")} to complete. Press a button to go back to menu");
                        Console.ReadLine();
                    }
                }
                Helpers.AddToHistory(score, "Subtraction");
            }
        }

        internal static void additionGame(string message)
        {
            Console.WriteLine(message);


            var timer = new Stopwatch();
            var random = new Random();
            var score = 0;
            int firstNumber;
            int secondNumber;
            var difficulty = Helpers.Difficulty();
            var count = Helpers.NumberOfQuestions();


            for (int i = 0; i < count; i++)
            {
                if (i == 0)
                {
                    timer.Start();
                }
                Console.Clear();
                Console.WriteLine(message);
                ;

                if (difficulty == "e")
                {
                    firstNumber = random.Next(1, 9);
                    secondNumber = random.Next(1, 9);
                }
                else
                {
                    firstNumber = random.Next(25, 125);
                    secondNumber = random.Next(25, 125);
                }
                Console.WriteLine($"{firstNumber} + {secondNumber}");
                var result = Console.ReadLine();

                if (int.Parse(result) == firstNumber + secondNumber)
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                    Console.ReadLine();
                }
                if (i == count - 1)
                {
                    timer.Stop();
                    Console.WriteLine($"Game over. Your final score is {score} and it took you {timer.Elapsed.ToString(@"m\:ss\.fff")} to complete. Press a button to go back to menu");
                    Console.ReadLine();
                }
            }
            Helpers.AddToHistory(score, "Addition");
        }
    }
}

