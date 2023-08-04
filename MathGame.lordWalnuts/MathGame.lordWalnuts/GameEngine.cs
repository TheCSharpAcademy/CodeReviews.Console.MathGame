using MathGame.lordWalnuts.Models;
using System.Diagnostics;

namespace MathGame.lordWalnuts
{
    internal class GameEngine
    {


        internal void DivisionGame(string message)
        {
            var score = 0;
            var difficulty = Helpers.ChooseDifficulty();

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            TimeSpan ts = new TimeSpan();
            for (int i = 0; i < 5; i++)
            {

                Console.Clear();

                Console.WriteLine($"{message}, Difficulty: {difficulty}");

                var divisionNumbers = Helpers.GetDivisionNumbers();
                var firstNumber = divisionNumbers[0];
                var secondNumber = divisionNumbers[1];

                Console.WriteLine($"{firstNumber} / {secondNumber}");

                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

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

                if (i == 4)
                {
                    Console.Clear();
                    stopWatch.Stop();
                    ts = stopWatch.Elapsed;
                    Console.WriteLine($"Game over. Your final score is {score} and took {ts.Seconds} Seconds");
                    Console.WriteLine("Press any key to go back to the main menu.");
                    Console.ReadLine();
                }


            }


            Helpers.AddToHistory(score, GameType.Division, difficulty, $"{ts.Seconds}s");
        }

        internal void MultiplicationGame(string message)
        {
            var difficulty = Helpers.ChooseDifficulty();


            var random = new Random();
            var score = 0;

            int firstNumber;
            int secondNumber;

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            TimeSpan ts = new TimeSpan();



            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine($"{message}, Difficulty: {difficulty}");

                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);

                Console.WriteLine($"{firstNumber} * {secondNumber}");

                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

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

                if (i == 4)
                {
                    Console.Clear();
                    stopWatch.Stop();
                    ts = stopWatch.Elapsed;
                    Console.WriteLine($"Game over. Your final score is {score} and took {ts.Seconds} Seconds");
                    Console.WriteLine("Press any key to go back to the main menu.");
                    Console.ReadLine();
                }
            }

            Helpers.AddToHistory(score, GameType.Multiplication, difficulty, $"{ts.Seconds}s");
        }

        internal void SubtractionGame(string message)
        {
            var difficulty = Helpers.ChooseDifficulty();

            var random = new Random();
            var score = 0;

            int firstNumber;
            int secondNumber;

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            TimeSpan ts = new TimeSpan();


            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine($"{message}, Difficulty: {difficulty}");

                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);

                Console.WriteLine($"{firstNumber} - {secondNumber}");

                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

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

                if (i == 4)
                {
                    Console.Clear();
                    stopWatch.Stop();
                    ts = stopWatch.Elapsed;
                    Console.WriteLine($"Game over. Your final score is {score} and took {ts.Seconds} Seconds");
                    Console.WriteLine("Press any key to go back to the main menu.");
                    Console.ReadLine();
                }
            }

            Helpers.AddToHistory(score, GameType.Subtraction, difficulty, $"{ts.Seconds}s");
        }

        internal void AdditionGame(string message)
        {
            var difficulty = Helpers.ChooseDifficulty();

            var random = new Random();
            var score = 0;

            int firstNumber;
            int secondNumber;

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            TimeSpan ts = new TimeSpan();


            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine($"{message}, Difficulty: {difficulty}");

                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);

                Console.WriteLine($"{firstNumber} + {secondNumber}");

                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);


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

                if (i == 4)
                {
                    Console.Clear();
                    stopWatch.Stop();
                    ts = stopWatch.Elapsed;
                    Console.WriteLine($"Game over. Your final score is {score} and took {ts.Seconds} Seconds");
                    Console.WriteLine("Press any key to go back to the main menu.");
                    Console.ReadLine();
                }


            }

            Helpers.AddToHistory(score, GameType.Addition, difficulty, $"{ts.Seconds}s");
        }
    }
}
