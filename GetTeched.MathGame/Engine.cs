using System.Diagnostics;

namespace CSharp_Study_ConsoleMathGame
{
    internal class Engine
    {

        int firstNumber = 0;
        int secondNumber = 0;
        int score = 0;

        internal void AdditionGame(string name, string difficulty, int questions = 5, bool randomGame = false)
        {
            score = 0;
            long startTime = Stopwatch.GetTimestamp();
            string elapsedTime = "0.00";

            for (int i = 0; i <= questions - 1; i++)
            {
                Console.Clear();
                firstNumber = Helper.RandomNumber(difficulty);
                secondNumber = Helper.RandomNumber(difficulty);

                Console.WriteLine($"What is {firstNumber} + {secondNumber}?");
                string result = Console.ReadLine();
                result = Helper.NumberInputValidation(result);

                if (int.Parse(result) == firstNumber + secondNumber)
                {
                    Console.WriteLine("Correct");
                    score += 1;

                }
                else
                {
                    Console.WriteLine("Incorrect");
                }
                System.Threading.Thread.Sleep(300);
            }
            if (randomGame == false)
            {
                TimeSpan endTime = Stopwatch.GetElapsedTime(startTime);
                elapsedTime = endTime.ToString(@"m\:ss");
                Helper.AddGames(score, GameType.Addition, elapsedTime, name);
                Console.WriteLine($"You completed this Addition Math Game in {elapsedTime} with a total score of {score} pts.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();

            }


        }

        internal void SubtractionGame(string name, string difficulty, int questions = 5, bool randomGame = false)
        {
            score = 0;
            long startTime = Stopwatch.GetTimestamp();
            string elapsedTime = "0.00";
            for (int i = 0; i <= questions - 1; i++)
            {
                Console.Clear();
                firstNumber = Helper.RandomNumber(difficulty);
                secondNumber = Helper.RandomNumber(difficulty);

                Console.WriteLine($"What is {firstNumber} - {secondNumber}?");
                string result = Console.ReadLine();
                result = Helper.NumberInputValidation(result);

                if (int.Parse(result) == firstNumber - secondNumber)
                {
                    Console.WriteLine("Correct");
                    score += 1;

                }
                else
                {
                    Console.WriteLine("Incorrect");
                }
                System.Threading.Thread.Sleep(300);
            }
            if (randomGame == false)
            {
                TimeSpan endTime = Stopwatch.GetElapsedTime(startTime);
                elapsedTime = endTime.ToString(@"m\:ss");
                Helper.AddGames(score, GameType.Subtraction, elapsedTime, name);
                Console.WriteLine($"You completed this Subtraction Math Game in {elapsedTime} with a total score of {score} pts.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
            }


        }

        internal void MultiplicationGame(string name, string difficulty, int questions = 5, bool randomGame = false)
        {
            score = 0;
            long startTime = Stopwatch.GetTimestamp();
            string elapsedTime = "0.00";
            for (int i = 0; i <= questions - 1; i++)
            {
                Console.Clear();
                firstNumber = Helper.RandomNumber(difficulty);
                secondNumber = Helper.RandomNumber(difficulty);

                Console.WriteLine($"What is {firstNumber} X {secondNumber}?");
                string result = Console.ReadLine();
                result = Helper.NumberInputValidation(result);

                if (int.Parse(result) == firstNumber * secondNumber)
                {
                    Console.WriteLine("Correct");
                    score += 1;

                }
                else
                {
                    Console.WriteLine("Incorrect");
                }
                System.Threading.Thread.Sleep(300);
            }
            if (randomGame == false)
            {
                TimeSpan endTime = Stopwatch.GetElapsedTime(startTime);
                elapsedTime = endTime.ToString(@"m\:ss");
                Helper.AddGames(score, GameType.Multiplication, elapsedTime, name);
                Console.WriteLine($"You completed this Multiplication Math Game in {elapsedTime} with a total score of {score} pts.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
            }


        }

        internal void DivisionGame(string name, string difficulty, int questions = 5, bool randomGame = false)
        {
            score = 0;
            long startTime = Stopwatch.GetTimestamp();
            string elapsedTime = "0.00";
            for (int i = 0; i <= questions - 1; i++)
            {
                int[] divisionNumber = Helper.DivisionPossible(difficulty);
                firstNumber = divisionNumber[0];
                secondNumber = divisionNumber[1];
                Console.Clear();

                Console.WriteLine($"What is {firstNumber} / {secondNumber}?");
                string result = Console.ReadLine();
                result = Helper.NumberInputValidation(result);

                if (int.Parse(result) == firstNumber / secondNumber)
                {
                    Console.WriteLine("Correct");
                    score += 1;

                }
                else
                {
                    Console.WriteLine("Incorrect");
                }
                System.Threading.Thread.Sleep(300);
            }
            if (randomGame == false)
            {
                TimeSpan endTime = Stopwatch.GetElapsedTime(startTime);
                elapsedTime = endTime.ToString(@"m\:ss");
                Helper.AddGames(score, GameType.Division, elapsedTime, name);
                Console.WriteLine($"You completed this Division Math Game in {elapsedTime} with a total score of {score} pts.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
            }


        }

        internal void RandomGameSelection(string name, string difficulty, int questions = 5)
        {
            Random random = new();
            score = 0;
            long startTime = Stopwatch.GetTimestamp();
            string elapsedTime = "0.00";


            for (int i = 0; i <= questions - 1; i++)
            {
                int selection = random.Next(1, 4);
                switch (selection.ToString())
                {
                    case "1":
                        AdditionGame(name, difficulty, 1, true);
                        break;
                    case "2":
                        SubtractionGame(name, difficulty, 1, true);
                        break;
                    case "3":
                        MultiplicationGame(name, difficulty, 1, true);
                        break;
                    case "4":
                        DivisionGame(name, difficulty, 1, true);
                        break;
                }
            }
            TimeSpan endTime = Stopwatch.GetElapsedTime(startTime);
            elapsedTime = endTime.ToString(@"m\:ss");
            Helper.AddGames(score, GameType.Random, elapsedTime, name);
            Console.WriteLine($"You completed this Random Math Game in {elapsedTime} with a total score of {score} pts.");
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();

        }
    }
}
