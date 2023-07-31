namespace Math_Game_lib
{
    internal static class LevelOfDifficulty
    {
        // levels of game
        internal static int[] Easy(int numberOfQuestions, char operation)
        {
            int minValue = 1, maxValue = 10;
            return Helpers.GetNumbers(numberOfQuestions, operation, minValue, maxValue);
        }

        internal static int[] Medium(int numberOfQuestions, char operation)
        {
            int minValue = 1, maxValue = 100;
            return Helpers.GetNumbers(numberOfQuestions, operation, minValue, maxValue);
        }

        internal static int[] Hard(int numberOfQuestions, char operation)
        {
            int minValue = 1, maxValue = 1000;
            return Helpers.GetNumbers(numberOfQuestions, operation, minValue, maxValue);
        }
    }
}
