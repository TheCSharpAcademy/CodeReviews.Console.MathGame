using MathGame.jakubecm.Models;
using System.Diagnostics;

namespace MathGame.jakubecm
{
    internal class GameEngine
    {
        /// <summary>
        /// The game method itself, takes care of asking questions and evaluates answers
        /// </summary>
        /// <param name="message">The message that gets printed at the top</param>
        /// <param name="gameType">The type of game selected from menu, eg. Addition, Subtraction,...</param>
        internal void Game(string message, GameType gameType) 
        {
            var random = new Random();
            var score = 0;
            int questionAmount = Helpers.GetQuestionAmount(); // Lets the user select number of questions
            Stopwatch stopWatch = new Stopwatch(); // Timer for tracking how long the user takes to finish
            string currentGameOperator = Helpers.GetGameOperator(gameType);

            for (int i = 0; i < questionAmount; i++)
            {
                stopWatch.Start();
                Console.Clear();
                Console.WriteLine(message);

                int firstNumber = random.Next(1, 9);
                int secondNumber = random.Next(1, 9);

                if (currentGameOperator == "/")
                {
                    var divisionNumbers = Helpers.GetDivisionNumbers();
                    firstNumber = divisionNumbers[0];
                    secondNumber = divisionNumbers[1];
                }

                Console.WriteLine($"{firstNumber} {currentGameOperator} {secondNumber}");
                int correctAnswer = Helpers.GetOperationResult(currentGameOperator, firstNumber, secondNumber);
                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result!) == correctAnswer)
                {
                    score++;
                    Console.WriteLine("Your answer was correct! Enter any key for the next question.");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Enter any key for the next question.");
                    Console.ReadLine();
                }

                // In case the game is random, a new operator is rolled for the next question
                if(gameType == GameType.Random)
                {
                    currentGameOperator = Helpers.GetRandomGameOperator();
                }
            }
            stopWatch.Stop();
            Console.WriteLine($"Game over. Your final score is {score}/{questionAmount}. Press any key to return to menu.");
            Console.ReadLine();
            Helpers.AddToHistory(score, questionAmount, gameType, stopWatch.Elapsed);
        }
    }
}
