using System.Diagnostics;

namespace MathGame
{
    internal class Games
    {
        internal void AdditionGame(string message)
        {
            Console.Clear();
            Console.WriteLine($"You are playing: {message}\n");

            Stopwatch timer = new Stopwatch();
            Random random = new Random();

            int correctAnswers = 0;
            int wrongAnswers = 0;
            string gameTime = "";

            int firstNumber = 0;
            int secondNumber = 0;

            int questions = 0;
            string gameLevel = Helpers.Difficulty();

            Console.WriteLine("How many questions do you want the game to be? ");
            int userChoice = Helpers.ParseToInt(Console.ReadLine());

            timer.Start();
            while (questions < userChoice)
            {
                if (gameLevel == "Easy")
                {
                    firstNumber = random.Next(1, 26);
                    secondNumber = random.Next(1, 26);
                }

                if (gameLevel == "Medium")
                {
                    firstNumber = random.Next(1, 51);
                    secondNumber = random.Next(1, 51);
                }

                if (gameLevel == "Difficult")
                {
                    firstNumber = random.Next(1, 101);
                    secondNumber = random.Next(1, 101);
                }

                Console.WriteLine($"{firstNumber} + {secondNumber}");
                int result = Helpers.ParseToInt(Console.ReadLine());

                if (result == firstNumber + secondNumber)
                {
                    Helpers.CorrectAnswer(correctAnswers);
                }
                else
                {
                    Helpers.WrongAnswer(wrongAnswers);
                }

                questions++;
            }
            timer.Stop();

            gameTime = timer.Elapsed.ToString("mm\\:ss");

            Helpers.GameSummery(correctAnswers, wrongAnswers, gameTime);
                     
            Helpers.AddToHistory(correctAnswers, wrongAnswers, "Addition", gameLevel, gameTime);
            Console.Clear();

        }
        internal void SubtractionGame(string message)
        {
            Console.Clear();
            Console.WriteLine($"You are playing: {message}\n");

            Stopwatch timer = new Stopwatch();
            Random random = new Random();

            int correctAnswers = 0;
            int wrongAnswers = 0;
            string gameTime = "";

            int firstNumber = 0;
            int secondNumber = 0;

            int questions = 0;
            string gameLevel = Helpers.Difficulty();

            Console.WriteLine("How many questions do you want the game to be? ");
            int userChoice = Helpers.ParseToInt(Console.ReadLine());

            timer.Start();
            while (questions < userChoice)
            {
                if (gameLevel == "Easy")
                {
                    firstNumber = random.Next(1, 26);
                    secondNumber = random.Next(1, 26);
                }

                if (gameLevel == "Medium")
                {
                    firstNumber = random.Next(1, 51);
                    secondNumber = random.Next(1, 51);
                }

                if (gameLevel == "Difficult")
                {
                    firstNumber = random.Next(1, 101);
                    secondNumber = random.Next(1, 101);
                }

                Console.WriteLine($"{firstNumber} - {secondNumber}");
                int result = Helpers.ParseToInt(Console.ReadLine());

                if (result == firstNumber - secondNumber)
                {
                    Helpers.CorrectAnswer(correctAnswers);
                }
                else
                {
                    Helpers.WrongAnswer(wrongAnswers);
                }

                questions++;
            }
            timer.Stop();

            gameTime = timer.Elapsed.ToString("mm\\:ss");

            Helpers.GameSummery(correctAnswers, wrongAnswers, gameTime);

            Helpers.AddToHistory(correctAnswers, wrongAnswers, "Subtraction", gameLevel, gameTime);
            Console.Clear();
        }
        internal void MultiplicationGame(string message)
        {
            Console.Clear();
            Console.WriteLine($"You are playing: {message}\n");

            Stopwatch timer = new Stopwatch();
            Random random = new Random();

            int correctAnswers = 0;
            int wrongAnswers = 0;
            string gameTime = "";

            int firstNumber = 0;
            int secondNumber = 0;

            int questions = 0;
            string gameLevel = Helpers.Difficulty();

            Console.WriteLine("How many questions do you want the game to be? ");
            int userChoice = Helpers.ParseToInt(Console.ReadLine());

            timer.Start();
            while (questions < userChoice)
            {
                if (gameLevel == "Easy")
                {
                    firstNumber = random.Next(1, 26);
                    secondNumber = random.Next(1, 26);
                }

                if (gameLevel == "Medium")
                {
                    firstNumber = random.Next(1, 51);
                    secondNumber = random.Next(1, 51);
                }

                if (gameLevel == "Difficult")
                {
                    firstNumber = random.Next(1, 101);
                    secondNumber = random.Next(1, 101);
                }

                Console.WriteLine($"{firstNumber} x {secondNumber}");
                int result = Helpers.ParseToInt(Console.ReadLine());

                if (result == firstNumber * secondNumber)
                {
                    Helpers.CorrectAnswer(correctAnswers);
                }
                else
                {
                    Helpers.WrongAnswer(wrongAnswers);
                }

                questions++;
            }
            timer.Stop();

            gameTime = timer.Elapsed.ToString("mm\\:ss");

            Helpers.GameSummery(correctAnswers, wrongAnswers, gameTime);

            Helpers.AddToHistory(correctAnswers, wrongAnswers, "Multiplication", gameLevel, gameTime);
            Console.Clear();
        }
        internal void DivisionGame(string message)
        {
            Console.Clear();
            Console.WriteLine($"You are playing: {message}\n");

            Stopwatch timer = new Stopwatch();
            Random random = new Random();

            int correctAnswers = 0;
            int wrongAnswers = 0;
            string gameTime = "";

            int questions = 0;

            string gameLevel = Helpers.Difficulty();

            Console.WriteLine("How many questions do you want the game to be? ");
            int userChoice = Helpers.ParseToInt(Console.ReadLine());

            timer.Start();
            while (questions < userChoice)
            {
                int firstNumber = random.Next();
                int secondNumber = random.Next();

                if (gameLevel == "Easy")
                {
                    while (firstNumber % secondNumber != 0)
                    {
                        firstNumber = random.Next(1, 26);
                        secondNumber = random.Next(1, 26);
                    }
                }

                if (gameLevel == "Medium")
                {
                    while (firstNumber % secondNumber != 0)
                    {
                        firstNumber = random.Next(1, 51);
                        secondNumber = random.Next(1, 51);
                    }
                }

                if (gameLevel == "Difficult")
                {
                    while (firstNumber % secondNumber != 0)
                    {
                        firstNumber = random.Next(1, 101);
                        secondNumber = random.Next(1, 101);
                    }
                }

                Console.WriteLine($"{firstNumber} / {secondNumber}");
                int result = Helpers.ParseToInt(Console.ReadLine());

                if (result == firstNumber / secondNumber)
                {
                    Helpers.CorrectAnswer(correctAnswers);
                }
                else
                {
                   Helpers.WrongAnswer(wrongAnswers);
                }

                questions++;
            }
            timer.Stop();

            gameTime = timer.Elapsed.ToString("mm\\:ss");

            Helpers.GameSummery(correctAnswers, wrongAnswers, gameTime);

            Helpers.AddToHistory(correctAnswers, wrongAnswers, "Division", gameLevel, gameTime);
            Console.Clear();

        }
        internal void RandomGame(string message)
        {
            Console.Clear();
            Console.WriteLine($"You are playing: {message}\n");

            Stopwatch timer = new Stopwatch();
            Random random = new Random();

            int correctAnswers = 0;
            int wrongAnswers = 0;
            string gameTime = "";

            int firstNumber = 0;
            int secondNumber = 0;

            int questions = 0;
            string gameLevel = Helpers.Difficulty();

            Console.WriteLine("How many questions do you want the game to be? ");
            int userChoice = Helpers.ParseToInt(Console.ReadLine());

            timer.Start();
            while (questions < userChoice)
            {
                if (gameLevel == "Easy")
                {
                    firstNumber = random.Next(1, 26);
                    secondNumber = random.Next(1, 26);
                }

                if (gameLevel == "Medium")
                {
                    firstNumber = random.Next(1, 51);
                    secondNumber = random.Next(1, 51);
                }

                if (gameLevel == "Difficult")
                {
                    firstNumber = random.Next(1, 101);
                    secondNumber = random.Next(1, 101);
                }

                string mathOperator = Helpers.RandomOperator();

                Console.WriteLine($"{firstNumber} {mathOperator} {secondNumber}");
                int result = Helpers.ParseToInt(Console.ReadLine());

                if (mathOperator == "+")
                {
                    if (result == (firstNumber + secondNumber))
                    {
                        Helpers.CorrectAnswer(correctAnswers);
                    }
                    else
                    {
                        Helpers.WrongAnswer(wrongAnswers);
                    }

                    questions++;
                }

                if (mathOperator == "-")
                {
                    if (result == (firstNumber - secondNumber))
                    {
                        Helpers.CorrectAnswer(correctAnswers);
                    }
                    else
                    {
                        Helpers.WrongAnswer(wrongAnswers);
                    }

                    questions++;
                }

                if (mathOperator == "x")
                {
                    if (result == (firstNumber * secondNumber))
                    {
                        Helpers.CorrectAnswer(correctAnswers);
                    }
                    else
                    {
                        Helpers.WrongAnswer(wrongAnswers);
                    }

                    questions++;
                }

                if (mathOperator == "/")
                {
                    if (result == (firstNumber / secondNumber))
                    {
                        Helpers.CorrectAnswer(correctAnswers);
                    }
                    else
                    {
                        Helpers.WrongAnswer(wrongAnswers);
                    }

                    questions++;
                }
            }
            timer.Stop();

            gameTime = timer.Elapsed.ToString("mm\\:ss");

            Helpers.GameSummery(correctAnswers, wrongAnswers, gameTime);
                     
            Helpers.AddToHistory(correctAnswers, wrongAnswers, "Random", gameLevel, gameTime);
            Console.Clear();

        }
    }
}
