namespace MathGame
{
    internal class Helpers
    {
        internal static int[] GetDivisionNumbers()
        {
            Random random = new Random();
            int firstNumber = random.Next(1, 99);
            int secondNumber = random.Next(1, 99);

            int[] divisionNumbers = new int[2];

            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(1, 99);
                secondNumber = random.Next(1, 99);
            }

            divisionNumbers[0] = firstNumber;
            divisionNumbers[1] = secondNumber;

            return divisionNumbers;
        }
    }
}