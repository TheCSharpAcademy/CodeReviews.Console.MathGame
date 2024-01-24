namespace ShihabudheenSha.MathGame
{
    static internal class Helpers
    {
        static internal int[] GetRandomDivisionNumbers()
        {
            int[] randomDivisonNumbers = new int[2];
            int firstNumber;
            int secondNumber;
            do
            {
                firstNumber = new Random().Next(1, 99);
                secondNumber = new Random().Next(1, 99);
            } while (firstNumber % secondNumber != 0);
            randomDivisonNumbers[0] = firstNumber;
            randomDivisonNumbers[1] = secondNumber;
            return randomDivisonNumbers;

        }
        static internal string GetUserName()
        {
            Console.WriteLine("Enter Your Name");
            Console.WriteLine("---------------------------");
            string userName = Console.ReadLine();
            while (string.IsNullOrEmpty(userName))
            {
                Console.WriteLine("Name can't be empty");
                userName = Console.ReadLine();
            }
            return userName;
        }

        static internal string ValidateGameUserAnswer(string usrAnswer)
        {
            while (string.IsNullOrEmpty(usrAnswer) || !Int32.TryParse(usrAnswer, out _))
            {
                Console.WriteLine("Answer must be an integer");
                usrAnswer = Console.ReadLine();
            }
            return usrAnswer;
        }
    }
}
