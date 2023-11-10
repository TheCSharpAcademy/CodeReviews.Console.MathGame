using MathGame;
using MathGame.Models;

internal static class HelpersHelpers {

    internal static List<int> DifficultySelector(GameType) {
        if (GameType) {
            Console.WriteLine("Please, select a level of difficulty for the game:\n" +
                              "1 - Easy (Numbers from 1 to 10)\n" +
                              "2 - Medium (Numbers from 1 to 50)\n" +
                              "3 - Hard (Numbers from 1 to 100)");
            int difficulty = int.Parse(Helpers.ValidateResult(Console.ReadLine()));

            int firstNumber;
            int secondNumber;
            switch (difficulty) {
                case 1:
                    firstNumber = Helpers.GenerateRandomNumber(1, 11);
                    secondNumber = Helpers.GenerateRandomNumber(1, 11);
                    break;
                case 2:
                    firstNumber = Helpers.GenerateRandomNumber(1, 51);
                    secondNumber = Helpers.GenerateRandomNumber(1, 51);
                    break;
                case 3:
                    firstNumber = Helpers.GenerateRandomNumber(1, 11);
                    secondNumber = Helpers.GenerateRandomNumber(1, 11);
                    break;
            }
            return new List<int> { firstNumber, secondNumber };

        }

    }
}