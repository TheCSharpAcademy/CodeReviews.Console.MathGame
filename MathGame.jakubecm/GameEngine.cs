using MathGame.jakubecm.Models;

namespace MathGame.jakubecm
{
    internal class GameEngine
    {

        internal void Game(string message, GameType gameType) 
        {
            var random = new Random();
            var score = 0;
            int firstNumber;
            int secondNumber;
            string currentGameOperator = Helpers.GetGameOperator(gameType);

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);

                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);

                if (currentGameOperator == "/")
                {
                    var divisionNumbers = Helpers.GetDivisionNumbers();
                    firstNumber = divisionNumbers[0];
                    secondNumber = divisionNumbers[1];
                }

                Console.WriteLine($"{firstNumber} {currentGameOperator} {secondNumber}");
                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result!) == Helpers.GetOperationResult(currentGameOperator, firstNumber, secondNumber))
                {
                    score++;
                    Console.WriteLine("Your answer was correct! Type any key for the next question.");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Type any key for the next question.");
                    Console.ReadLine();
                }
            }
            Console.WriteLine($"Game over. Your final score is {score}");
            Helpers.AddToHistory(score, gameType);

        }
    }
}
