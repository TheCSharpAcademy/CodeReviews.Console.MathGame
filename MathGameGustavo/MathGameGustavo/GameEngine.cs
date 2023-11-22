using MathGameGustavo.Models;
using System.Diagnostics;

namespace MathGameGustavo
{
    internal class GameEngine
    {
        Helpers helpers = new Helpers();

        Stopwatch stopwatch = new Stopwatch();
  
        internal void AdditionGame(string message)  
        {
            Console.Clear();
            Console.WriteLine(message);

            var random = new Random();
            int score = 0;
            int firstNumber;
            int secondNumber;

            string difficultyLevel = helpers.DifficultyMenu();
            string numberOfQuestions = helpers.QuestionNumber();

            stopwatch.Start();

            for (int i = 0; i < int.Parse(numberOfQuestions); i++)
            {
                int[] difficulty = helpers.DifficultyNumberGen(difficultyLevel);
                firstNumber = difficulty[0];
                secondNumber = difficulty[1];

                Console.WriteLine($"{firstNumber} + {secondNumber} ?");
                int result = firstNumber + secondNumber;
                string answer = Console.ReadLine();
                answer = helpers.ValidateAnswer(answer);

                if (int.Parse(answer) == result)
                {
                    Console.WriteLine("Correct!\n");
                    score++;
                }
                else
                {
                    Console.WriteLine($"Incorrect, The answer was {result}!\n");
                }
            }
            stopwatch.Stop();
            long timePassed = stopwatch.ElapsedMilliseconds / 1000;
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine($"The game has ended.\nYour final score is {score}!\n");
            Console.WriteLine($"Elapsed time: {timePassed} Seconds");
            helpers.AddToHistory(score, GameType.Addition, int.Parse(numberOfQuestions), timePassed);
            Console.ReadLine();
        }

        internal void SubtractionGame(string message)
        {
            Console.Clear();
            Console.WriteLine(message);

            var random = new Random();
            int score = 0;
            int firstNumber;
            int secondNumber;

            string difficultyLevel = helpers.DifficultyMenu();
            string numberOfQuestions = helpers.QuestionNumber();

            stopwatch.Start();

            for (int i = 0; i < int.Parse(numberOfQuestions); i++)
            {
                int[] difficulty = helpers.DifficultyNumberGen(difficultyLevel);
                firstNumber = difficulty[0];
                secondNumber = difficulty[1];

                Console.WriteLine($"{firstNumber} - {secondNumber} ?");
                int result = firstNumber - secondNumber;
                string answer = Console.ReadLine();
                answer = helpers.ValidateAnswer(answer);

                if (int.Parse(answer) == result)
                {
                    Console.WriteLine("Correct!\n");
                    score++;
                }
                else
                {
                    Console.WriteLine($"Incorrect, The answer was {result}!\n");
                }
            }
            stopwatch.Stop();
            long timePassed = stopwatch.ElapsedMilliseconds / 1000;

            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine($"The game has ended.\nYour final score is {score}!\n");
            Console.WriteLine($"Elapsed time: {timePassed} Seconds");
            helpers.AddToHistory(score, GameType.Subtraction, int.Parse(numberOfQuestions), timePassed);
            Console.ReadLine();
        }

        internal void MultiplicationGame(string message)
        {
            Console.Clear();
            Console.WriteLine(message);

            var random = new Random();
            int score = 0;
            int firstNumber;
            int secondNumber;

            string difficultyLevel = helpers.DifficultyMenu();
            string numberOfQuestions = helpers.QuestionNumber();

            stopwatch.Start();

            for (int i = 0; i < int.Parse(numberOfQuestions); i++)
            {
                int[] difficulty = helpers.DifficultyNumberGen(difficultyLevel);
                firstNumber = difficulty[0];
                secondNumber = difficulty[1];

                Console.WriteLine($"{firstNumber} X {secondNumber} ?");
                int result = firstNumber * secondNumber;
                string answer = Console.ReadLine();
                answer = helpers.ValidateAnswer(answer);

                if (int.Parse(answer) == result)
                {
                    Console.WriteLine("Correct!\n");
                    score++;
                }
                else
                {
                    Console.WriteLine($"Incorrect, The answer was {result}!\n");
                }
            }
            stopwatch.Stop();
            long timePassed = stopwatch.ElapsedMilliseconds / 1000;

            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine($"The game has ended.\nYour final score is {score}!\n");
            Console.WriteLine($"Elapsed time: {timePassed} Seconds");
            helpers.AddToHistory(score, GameType.Multiplication, int.Parse(numberOfQuestions), timePassed);
            Console.ReadLine();
        }

        internal void DivisionGame(string message)
        {
            Console.Clear();
            int score = 0;
            string numberOfQuestions = helpers.QuestionNumber();

            stopwatch.Start();

            for (int i = 0; i < int.Parse(numberOfQuestions); i++)
            {
                int[] divisionNumbers = helpers.GetDivisionNumbers();
                int firstNumber = divisionNumbers[0];
                int secondNumber = divisionNumbers[1];
                Console.WriteLine($"{firstNumber} / {secondNumber}");
                int result = firstNumber / secondNumber;
                string answer = Console.ReadLine();
                answer = helpers.ValidateAnswer(answer);

                if (int.Parse(answer) == result)
                {
                    Console.WriteLine("Correct!\n");
                    score++;
                }
                else
                {
                    Console.WriteLine($"Incorrect, The answer was {result}!\n");
                }
            }
            stopwatch.Stop();
            long timePassed = stopwatch.ElapsedMilliseconds / 1000;

            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine($"The game has ended.\nYour final score is {score}!\n");
            Console.WriteLine($"Elapsed time: {timePassed} Seconds");
            helpers.AddToHistory(score, GameType.Division, int.Parse(numberOfQuestions), timePassed);
            Console.ReadLine();
        }

        internal void RandomGame(string message)
        {
            Console.Clear();
            Console.WriteLine(message);

            var random = new Random();
            int score = 0;
            int firstNumber;
            int secondNumber;

            string difficultyLevel = helpers.DifficultyMenu();
            string numberOfQuestions = helpers.QuestionNumber();

            stopwatch.Start();

            for (int i = 0; i < int.Parse(numberOfQuestions); i++)
            {
                int gameType = random.Next(0, 4);

                if (gameType == 0)
                {
                    int[] difficulty = helpers.DifficultyNumberGen(difficultyLevel);
                    firstNumber = difficulty[0];
                    secondNumber = difficulty[1];

                    Console.WriteLine($"{firstNumber} + {secondNumber} ?");
                    int result = firstNumber + secondNumber;
                    string answer = Console.ReadLine();
                    answer = helpers.ValidateAnswer(answer);

                    if (int.Parse(answer) == result)
                    {
                        Console.WriteLine("Correct!\n");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine($"Incorrect, The answer was {result}!\n");
                    }
                } else if(gameType == 1)
                {
                    int[] difficulty = helpers.DifficultyNumberGen(difficultyLevel);
                    firstNumber = difficulty[0];
                    secondNumber = difficulty[1];

                    Console.WriteLine($"{firstNumber} - {secondNumber} ?");
                    int result = firstNumber - secondNumber;
                    string answer = Console.ReadLine();
                    answer = helpers.ValidateAnswer(answer);

                    if (int.Parse(answer) == result)
                    {
                        Console.WriteLine("Correct!\n");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine($"Incorrect, The answer was {result}!\n");
                    }
                } else if (gameType == 2)
                {
                    int[] difficulty = helpers.DifficultyNumberGen(difficultyLevel);
                    firstNumber = difficulty[0];
                    secondNumber = difficulty[1];

                    Console.WriteLine($"{firstNumber} X {secondNumber} ?");
                    int result = firstNumber * secondNumber;
                    string answer = Console.ReadLine();
                    answer = helpers.ValidateAnswer(answer);

                    if (int.Parse(answer) == result)
                    {
                        Console.WriteLine("Correct!\n");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine($"Incorrect, The answer was {result}!\n");
                    }
                } else if( gameType == 3)
                {
                    int[] divisionNumbers = helpers.GetDivisionNumbers();
                    firstNumber = divisionNumbers[0];
                    secondNumber = divisionNumbers[1];
                    Console.WriteLine($"{firstNumber} / {secondNumber}");
                    int result = firstNumber / secondNumber;
                    string answer = Console.ReadLine();
                    answer = helpers.ValidateAnswer(answer);

                    if (int.Parse(answer) == result)
                    {
                        Console.WriteLine("Correct!\n");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine($"Incorrect, The answer was {result}!\n");
                    }
                }
            }
            stopwatch.Stop();
            long timePassed = stopwatch.ElapsedMilliseconds / 1000;
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine($"The game has ended.\nYour final score is {score}!\n");
            Console.WriteLine($"Elapsed time: {timePassed} Seconds");
            helpers.AddToHistory(score, GameType.Random, int.Parse(numberOfQuestions), timePassed);
            Console.ReadLine();
        }
    }
}
