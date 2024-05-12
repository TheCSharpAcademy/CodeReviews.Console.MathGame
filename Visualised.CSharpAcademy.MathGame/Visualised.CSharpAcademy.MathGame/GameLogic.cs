using Visualised.CSharpAcademy.MathGame.Models;

namespace Visualised.CSharpAcademy.MathGame
{
    internal class GameLogic
    {
        private bool AbstractGameLogic(int firstNumber, int secondNumber, string selectedOperator)
        {
            var operations = new Dictionary<string, Func<int, int, int>>
            {
                { "+", (a, b) => a + b },
                { "-", (a, b) => a - b },
                { "*", (a, b) => a * b },
                { "/", (a, b) => a / b }

            };

            Console.Write($"{firstNumber} {selectedOperator} {secondNumber} = ");
            int result = Helpers.GetUserIntInput();

            if (result == operations[selectedOperator](firstNumber, secondNumber))
            {
                Console.WriteLine("You're correct! Press any key to continue.");
                Console.ReadLine();
                return true;
            }
            else
            {
                Console.WriteLine("Wrong answer! Press any key to continue.");
                Console.ReadLine();
                return false;
            }
        }

        internal bool AdditionGameLogic(GameDifficultyLevels gameDifficulty)
        {
            int firstNumber = Helpers.GetRandomNumberBasedOnDifficulty(gameDifficulty);
            int secondNumber = Helpers.GetRandomNumberBasedOnDifficulty(gameDifficulty);

            bool hasUserWonTheGame = AbstractGameLogic(firstNumber, secondNumber, "+");

            return hasUserWonTheGame;
        }

        internal bool SubtractionGameLogic(GameDifficultyLevels gameDifficulty)
        {
            int firstNumber = Helpers.GetRandomNumberBasedOnDifficulty(gameDifficulty);
            int secondNumber = Helpers.GetRandomNumberBasedOnDifficulty(gameDifficulty);

            bool hasUserWonTheGame = AbstractGameLogic(firstNumber, secondNumber, "-");

            return hasUserWonTheGame;
        }

        internal bool MultiplicationGameLogic(GameDifficultyLevels gameDifficulty)
        {
            int firstNumber = Helpers.GetRandomNumberBasedOnDifficulty(gameDifficulty);
            int secondNumber = Helpers.GetRandomNumberBasedOnDifficulty(gameDifficulty);

            bool hasUserWonTheGame = AbstractGameLogic(firstNumber, secondNumber, "*");

            return hasUserWonTheGame;
        }

        internal bool DivisionGameLogic(GameDifficultyLevels gameDifficulty)
        {
            int[] divisionNumbers = Helpers.GetDivisibleNumbersBasedOnDifficulty(gameDifficulty);
            int firstNumber = divisionNumbers[0];
            int secondNumber = divisionNumbers[1];

            bool hasUserWonTheGame = AbstractGameLogic(firstNumber, secondNumber, "/");

            return hasUserWonTheGame;
        }
    }
}
