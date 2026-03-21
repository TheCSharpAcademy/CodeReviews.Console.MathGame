using MathGame.Models;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace MathGame
{
    internal class GameEngine
    {
        private readonly IConfiguration _configuration;

        public GameEngine(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        internal void PlayGame(GameType gametype, string message, DifficultyLevel difficulty)
        {
            Random random = new Random();
            byte score = 0;

            int max = int.Parse(_configuration[$"{difficulty}:Max"] ?? "9");

            Stopwatch timer = new Stopwatch();
            timer.Start();

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);

                GameType currentType = gametype == GameType.Random ? (GameType)random.Next(0, 4) : gametype;

                int firstNum;
                int secondNum;

                if (currentType == GameType.Division)
                {
                    var divisionNumbers = Helpers.GetDivisionNumbers(1, max);
                    firstNum = divisionNumbers[0];
                    secondNum = divisionNumbers[1];
                }
                else
                {
                    firstNum = random.Next(1, max + 1);
                    secondNum = random.Next(1, max + 1);
                }

                var (operatorSymbol, correctAnswer) = currentType switch
                {
                    GameType.Addition => ("+", firstNum + secondNum),
                    GameType.Subtraction => ("-", firstNum - secondNum),
                    GameType.Multiplication => ("*", firstNum * secondNum),
                    GameType.Division => ("/", firstNum / secondNum),
                    _ => throw new InvalidOperationException("Unexpected game type")
                };

                Console.WriteLine($"{firstNum} {operatorSymbol} {secondNum}");
                string res = Console.ReadLine()!;
                Helpers.ValidateResult(res);

                if (int.Parse(res) == correctAnswer)
                {
                    Console.WriteLine("Your answer was correct.");
                    score++;
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect.");
                }

                Console.WriteLine("Type any key for the next question");
                Console.ReadLine();
            }

            timer.Stop();

            Helpers.AddToHistory(score, gametype, timer.Elapsed, difficulty);
            Console.WriteLine($"Game over. Your final score is {score}. Time taken: {timer.Elapsed.Minutes}m {timer.Elapsed.Seconds}s. Press any key to go back to the main menu");
            Console.ReadLine();
        }
    }
}