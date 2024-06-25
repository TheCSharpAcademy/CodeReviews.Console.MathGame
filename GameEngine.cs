

using MathGame.Models;
using System;
using System.Diagnostics;
using static System.Formats.Asn1.AsnWriter;

namespace MathGame
{
    internal class GameEngine
    {
        internal void AdditionGame(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Stopwatch timer = new Stopwatch();
            int score = 0;

            int[] difficulty = Helpers.SetDifficulty(GameType.Addition);
            int numberOfQuestions = Helpers.GetNumberOfQuestions();
            string gameDifficulty;
            if (difficulty[2] == 1)
            {
                gameDifficulty = "Easy";
            }
            else if (difficulty[2] == 2)
            {
                gameDifficulty = "Medium";
            }
            else gameDifficulty = "Hard";
            Console.WriteLine($"Game Type: Addition Difficulty: {gameDifficulty}");
            timer.Start();
            for (int i = 0; i < numberOfQuestions; i++)
            {

                if (GetAdditionQuestion(difficulty))
                {
                    score++;
                }
            }
            timer.Stop();
            TimeSpan ts = timer.Elapsed;
            string gameTime = $"Time: {ts.Minutes}min, {ts.Seconds}sec";
            Helpers.AddToHistory(score, GameType.Addition, gameDifficulty, gameTime);
            Console.WriteLine($"You got {score} out of {numberOfQuestions} correct in {ts.Minutes}Minutes and {ts.Seconds}Seconds, good game.");
            Console.ReadLine();
        }

        private bool GetAdditionQuestion(int[] difficulty)
        {
            Random random = new Random();
            int firstNumber;
            int secondNumber;
            firstNumber = random.Next(1, difficulty[0]);
            secondNumber = random.Next(1, difficulty[1]);

            Console.WriteLine($"{firstNumber} + {secondNumber}");
            var result = Console.ReadLine();

            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == firstNumber + secondNumber)
            {
                Console.WriteLine("Your answer was correct, press any key for the next question");
                Console.ReadLine();
                return true;
            }
            else
            {
                Console.WriteLine("Your answer was incorrect, press any key for the next question");
                Console.ReadLine();
                return false;
            };
        }

        internal void SubtractionGame(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Stopwatch timer = new Stopwatch();

            var score = 0;
            int[] difficulty = Helpers.SetDifficulty(GameType.Subtraction);
            string gameDifficulty;
            int numberOfQuestions = Helpers.GetNumberOfQuestions();
            if (difficulty[2] == 1)
            {
                gameDifficulty = "Easy";
            }
            else if (difficulty[2] == 2)
            {
                gameDifficulty = "Medium";
            }
            else gameDifficulty = "Hard";


            Console.WriteLine($"Game Type: Subtraction Difficulty: {gameDifficulty}");
            timer.Start();
            for (int i = 0; i < numberOfQuestions; i++)
            {

                if (GetSubtractionQuestion(difficulty))
                {
                    score++;
                }

            }
            timer.Stop();
            TimeSpan ts = timer.Elapsed;
            string gameTime = $"Time: {ts.Minutes}min, {ts.Seconds}sec";
            Helpers.AddToHistory(score, GameType.Addition, gameDifficulty, gameTime);
            Console.WriteLine($"You got {score} out of  {numberOfQuestions}  correct in n {ts.Minutes}Minutes and {ts.Seconds}Seconds, good game.");
            Helpers.AddToHistory(score, GameType.Subtraction, gameDifficulty, gameTime);
            Console.WriteLine($"You got {score} out of {numberOfQuestions} correct, good game.");
        }

        private bool GetSubtractionQuestion(int[] difficulty)
        {
            var random = new Random();
            int firstNumber;
            int secondNumber;
            firstNumber = random.Next(0, difficulty[0]);
            secondNumber = random.Next(0, difficulty[1]);

            Console.WriteLine($"{firstNumber} - {secondNumber}");
            var result = Console.ReadLine();

            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == firstNumber - secondNumber)
            {
                Console.WriteLine("Your answer was correct, press any key for the next question");
                Console.ReadLine();
                return true;
            }
            else
            {
                Console.WriteLine("Your answer was incorrect, press any key for the next question");
                Console.ReadLine();
                return false;
            }
        }

        internal void MultiplicationGame(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Stopwatch timer = new Stopwatch();


            var score = 0;
            int[] difficulty = Helpers.SetDifficulty(GameType.Multiplication);
            int numberOfQuestions = Helpers.GetNumberOfQuestions();
            string gameDifficulty;
            if (difficulty[2] == 1)
            {
                gameDifficulty = "Easy";
            }
            else if (difficulty[2] == 2)
            {
                gameDifficulty = "Medium";
            }
            else gameDifficulty = "Hard";

            Console.WriteLine($"Game Type: Multiplication Difficulty: {gameDifficulty}");
            timer.Start();
            for (int i = 0; i < numberOfQuestions; i++)
            {
                if (GetMultiplicationQuestion(difficulty))
                {
                    score++;
                }
            }
            timer.Stop();
            TimeSpan ts = timer.Elapsed;
            string gameTime = $"Time: {ts.Minutes}min, {ts.Seconds}sec";
            Helpers.AddToHistory(score, GameType.Multiplication, gameDifficulty, gameTime);
            Console.WriteLine($"You got {score} out of {numberOfQuestions} correct in {ts.Minutes}Minutes and {ts.Seconds}Seconds, good game.");

        }

        private bool GetMultiplicationQuestion(int[] difficulty)
        {
            var random = new Random();
            int firstNumber;
            int secondNumber;
            firstNumber = random.Next(0, difficulty[0]);
            secondNumber = random.Next(0, difficulty[1]);

            Console.WriteLine($"{firstNumber} x {secondNumber}");
            var result = Console.ReadLine();

            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == firstNumber * secondNumber)
            {
                Console.WriteLine("Your answer was correct, press any key for the next question");
                Console.ReadLine();
                return true;
            }
            else
            {
                Console.WriteLine("Your answer was incorrect, press any key for the next question");
                Console.ReadLine();
                return false;
            }
        }

        internal void DivisionGame(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Stopwatch timer = new Stopwatch();

            var score = 0;

            int[] difficulty = Helpers.SetDifficulty(GameType.Division);
            int numberOfQuestions = Helpers.GetNumberOfQuestions();
            string gameDifficulty;
            if (difficulty[2] == 1)
            {
                gameDifficulty = "Easy";
            }
            else if (difficulty[2] == 2)
            {
                gameDifficulty = "Medium";
            }
            else gameDifficulty = "Hard";

            Console.WriteLine($"Game Type: Division Difficulty: {gameDifficulty}");
            timer.Start();
            for (int i = 0; i < numberOfQuestions; i++)
            {
                if (GetDivisionQuestion(difficulty))
                {
                    score++;
                }

            }
            timer.Stop();
            TimeSpan ts = timer.Elapsed;
            string gameTime = $"Time: {ts.Minutes}min, {ts.Seconds}sec";
            Helpers.AddToHistory(score, GameType.Division, gameDifficulty, gameTime);
            Console.WriteLine($"You got {score} out of {numberOfQuestions} correct in {ts.Minutes}Minutes and {ts.Seconds}Seconds, good game.");
        }

        private bool GetDivisionQuestion(int[] difficulty)
        {
            Random random = new Random();

            var divisionNumbers = Helpers.GetDivisionNumbers(difficulty[2]);
            var firstNumber = divisionNumbers[0];
            var secondNumber = divisionNumbers[1];

            Console.WriteLine($"{firstNumber} / {secondNumber}");
            var result = Console.ReadLine();

            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == firstNumber / secondNumber)
            {
                Console.WriteLine("Your answer was correct, press any key for the next question");
                Console.ReadLine();
                return true;
            }
            else
            {
                Console.WriteLine("Your answer was incorrect, press any key for the next question");
                Console.ReadLine();
                return false;
            }
        }

        internal void RandomGame(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Stopwatch timer = new Stopwatch();
            Random random = new Random();

            var score = 0;
            int[] difficulty = Helpers.SetDifficulty(GameType.Random);
            int numberOfQuestions = Helpers.GetNumberOfQuestions();
            string gameDifficulty;
            if (difficulty[2] == 1)
            {
                gameDifficulty = "Easy";
            }
            else if (difficulty[2] == 2)
            {
                gameDifficulty = "Medium";
            }
            else gameDifficulty = "Hard";

            Console.WriteLine($"Game Type: Random Difficulty: {gameDifficulty}");
            timer.Start();
            for (int i = 0; i < numberOfQuestions; i++)
            {
                int mode = random.Next(0,4);
                switch (mode)
                {
                    case 0:
                        if (GetAdditionQuestion(difficulty))
                        {
                            score++;
                        }
                        break;
                    case 1:
                        if (GetSubtractionQuestion(difficulty))
                        {
                            score++;
                        }
                        break;
                    case 2:
                        if (GetMultiplicationQuestion(difficulty))
                        {
                            score++;
                        }
                        break;
                    case 3:
                        if (GetDivisionQuestion(difficulty))
                        {
                            score++;
                        }
                        break;
                }
            }
            timer.Stop();
            TimeSpan ts = timer.Elapsed;
            string gameTime = $"Time: {ts.Minutes}min, {ts.Seconds}sec";
            Helpers.AddToHistory(score, GameType.Random, gameDifficulty, gameTime);
            Console.WriteLine($"You got {score} out of {numberOfQuestions} correct in {ts.Minutes}Minutes and {ts.Seconds}Seconds, good game.");

        }
    }
}
