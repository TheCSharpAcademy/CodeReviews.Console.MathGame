using MathGame.Models;
using System;
using System.Diagnostics;
using System.Security.AccessControl;

namespace MathGame
{
    internal class GameEngine
    {
        // Pass numQuestions and mathNums as arguments so user can select random game without being asked for numQuestions and difficulty for each question
        internal int AdditionGame(string message, int numQuestions, int[] mathNums, bool gameOverMessage = true)
        {
            if (gameOverMessage) Console.Clear();
            Console.WriteLine(message);

            // Initialize variables for generating addition numbers
            var random = new Random();
            var score = 0;
            int firstNumber;
            int secondNumber;
            // Create stopwatch to time how long it takes user to answer questions
            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < numQuestions; i++)
            {
                // Set first/second numbers based on nums returned from difficulty selected
                firstNumber = random.Next(mathNums[0], mathNums[1]);
                secondNumber = random.Next(mathNums[0], mathNums[1]);

                Console.WriteLine($"{firstNumber} + {secondNumber}");
                var result = Console.ReadLine();
                // Make sure user enters a number
                result = Helpers.ValidateResult(result);

                // Print message based on whether guess is correct or not
                if (int.Parse(result) == firstNumber + secondNumber)
                {
                    Console.WriteLine("That's the correct answer! Press enter for the next question.");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Incorrect answer. The correct answer was " + (firstNumber + secondNumber) + ".\nPress enter for the next question.");
                    Console.ReadLine();
                }
                Console.WriteLine("-------------------------------------------------------------------");
            }
            // If gameOverMessage is true, add the game, score, difficulty to game history
            // mathNums[2] contains the int that corresponds to the difficulty enum
            stopwatch.Stop(); // Stop the stopwatch
            if (gameOverMessage)
            {
                int secondsTaken = (int)Math.Floor(stopwatch.Elapsed.TotalSeconds);
                Helpers.AddToHistory(score, GameType.Addition, (GameDifficulty)mathNums[2], secondsTaken);
                Console.WriteLine($"You answered in {secondsTaken} seconds"); // Display time taken to answer question in seconds
                Console.WriteLine($"Game over. Your final score is {score}. Press enter to return to the main menu.");
                Console.ReadLine();
            }
            return score;
        }

        internal int SubtractionGame(string message, int numQuestions, int[] mathNums, bool gameOverMessage = true)
        {
            if (gameOverMessage) Console.Clear();
            Console.WriteLine(message);

            var random = new Random();
            var score = 0;
            int firstNumber;
            int secondNumber;
            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < numQuestions; i++)
            {
                firstNumber = random.Next(mathNums[0], mathNums[1]);
                secondNumber = random.Next(mathNums[0], mathNums[1]);

                Console.WriteLine($"{firstNumber} - {secondNumber}");
                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber - secondNumber)
                {
                    Console.WriteLine("That's the correct answer! Press enter for the next question.");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Incorrect answer. The correct answer was " + (firstNumber - secondNumber) + ".\nPress enter for the next question.");
                    Console.ReadLine();
                }
            }
            stopwatch.Stop();

            if (gameOverMessage)
            {
                int secondsTaken = (int)Math.Floor(stopwatch.Elapsed.TotalSeconds);
                Helpers.AddToHistory(score, GameType.Subtraction, (GameDifficulty)mathNums[2], secondsTaken);
                Console.WriteLine($"You answered in {secondsTaken} seconds");
                Console.WriteLine($"Game over. Your final score is {score}. Press enter to return to the main menu.");
                Console.ReadLine();
            }
            return score;
        }

        internal int MultiplicationGame(string message, int numQuestions, int[] mathNums, bool gameOverMessage = true)
        {
            if (gameOverMessage) Console.Clear();
            Console.WriteLine(message);

            var random = new Random();
            var score = 0;
            int firstNumber;
            int secondNumber;
            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < numQuestions; i++)
            {
                firstNumber = random.Next(mathNums[0], mathNums[1]);
                secondNumber = random.Next(mathNums[0], mathNums[1]);

                Console.WriteLine($"{firstNumber} * {secondNumber}");
                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber * secondNumber)
                {
                    Console.WriteLine("That's the correct answer! Press enter for the next question.");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Incorrect answer. The correct answer was " + (firstNumber * secondNumber) + ".\nPress enter for the next question.");
                    Console.ReadLine();
                }
            }
            stopwatch.Stop();

            if (gameOverMessage)
            {
                int secondsTaken = (int)Math.Floor(stopwatch.Elapsed.TotalSeconds);
                Helpers.AddToHistory(score, GameType.Multiplication, (GameDifficulty)mathNums[2], secondsTaken);
                Console.WriteLine($"You answered in {secondsTaken} seconds");
                Console.WriteLine($"Game over. Your final score is {score}. Press enter to return to the main menu.");
                Console.ReadLine();
            }
            return score;
        }

        internal int DivisionGame(string message, int numQuestions, int[] mathNums, bool gameOverMessage = true)
        {
            if (gameOverMessage) Console.Clear();
            Console.WriteLine(message);
            var score = 0;
            var minNum = mathNums[0];
            var maxNum = mathNums[1];
            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < numQuestions; i++)
            {
                // Get division numbers and assign first/second numbers to corresponding results array index
                var divisionNumbers = Helpers.GetDivisionNumbers(minNum, maxNum);
                var firstNumber = divisionNumbers[0];
                var secondNumber = divisionNumbers[1];

                Console.WriteLine($"{firstNumber} / {secondNumber}");
                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber / secondNumber)
                {
                    Console.WriteLine("That's the correct answer! Press enter for the next question.");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Incorrect answer. The correct answer was " + (firstNumber / secondNumber) + ".\nPress enter for the next question.");
                    Console.ReadLine();
                }
            }
            stopwatch.Stop();

            if (gameOverMessage)
            {
                int secondsTaken = (int)Math.Floor(stopwatch.Elapsed.TotalSeconds);
                Helpers.AddToHistory(score, GameType.Division, (GameDifficulty)mathNums[2], secondsTaken);
                Console.WriteLine($"You answered in {secondsTaken} seconds");
                Console.WriteLine($"Game over. Your final score is {score}. Press enter to return to the main menu.");
                Console.ReadLine();
            }
            return score;
        }

        internal void RandomGame(string message, int numQuestions, int[] mathNums)
        {
            Console.Clear(); Console.WriteLine(message);
            int score = 0;
            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < numQuestions; i++)
            {
                var random = new Random();
                int gameType = random.Next(4);
                GameEngine gameEngine = new();
                switch (gameType)
                {
                    case 0:
                        // Add result of math game score to overall random score
                        // Call Game method with gameOverMessage passed as false so it doesn't display message for each random question
                        score += gameEngine.AdditionGame("Addition Game", 1, mathNums, false); break;
                    case 1:
                        score += gameEngine.SubtractionGame("Subtraction Game", 1, mathNums, false); break;
                    case 2:
                        score += gameEngine.MultiplicationGame("Multiplication Game", 1, mathNums, false); break;
                    case 3:
                        score += gameEngine.DivisionGame("Division Game", 1, mathNums, false); break;
                }
            }
            stopwatch.Stop();
            int secondsTaken = (int)Math.Floor(stopwatch.Elapsed.TotalSeconds);
            Helpers.AddToHistory(score, GameType.Random, (GameDifficulty)mathNums[2], secondsTaken);
            Console.WriteLine($"You answered in {secondsTaken} seconds");
            Console.WriteLine($"Random games over. You got {score} out of {numQuestions} correct. Press enter to return to main menu.");
            Console.ReadLine();
        }

    }
}
