namespace MathGame.HopelessCoding
{
    internal class GameEngine
    {
        private Random rnd = new Random();

        // Checks the user input and compares to correct answer
        internal void PlayGame(string operation)
        {
            var (maxValue, difficultyLevel) = SetDifficulty();
            var (num1, num2) = GenerateNumbers(operation, maxValue);
            var correctAnswer = PerformCalculation(num1, num2, maxValue, operation);

            Console.WriteLine($"Fill the result for:\n{num1} {operation} {num2}");
            CheckAnswer(correctAnswer, num1, num2, operation, difficultyLevel);
        }

        // Calculates the correct answer
        internal int PerformCalculation(int num1, int num2, int maxValue, string operation)
        {
            switch (operation)
            {
                case "+":
                    return num1 + num2;
                case "-":
                    return num1 - num2;
                case "*":
                    return num1 * num2;
                case "/":
                    return num1 / num2;
                default:
                    throw new ArgumentException("Invalid operation");
            }
        }

        // Function to generate numbers for Math Game
        internal (int, int) GenerateNumbers(string operation, int maxValue)
        {
            var num1 = rnd.Next(0, maxValue);
            var num2 = rnd.Next(0, maxValue);

            // For dividing check that numbers are suitable and find new ones if not
            if (operation == "/" && (num2 == 0 || num1 % num2 != 0))
            {
                return GenerateNumbers("/", maxValue);
            }

            return (num1, num2);
        }

        internal (int, string) SetDifficulty()
        {
            Console.WriteLine("Choose your game difficulty:\n" +
                "- (e)asy\n" +
                "- (m)edium\n" +
                "- (h)ard");

            var difficultyLevel = Console.ReadLine();

            switch (difficultyLevel)
            {
                case "e":
                    return (10, "easy");
                case "m":
                    return (50, "medium");
                case "h":
                    return (100, "hard");
                default:
                    Console.WriteLine("Invalid input. Setting to Easy by default.");
                    return (10, "easy");
            }
        }

        internal void CheckAnswer(int correctAnswer, int num1, int num2, string operation, string difficultyLevel)
        {
            int userAnswer;

            do
            {
                userAnswer = Helpers.ValidateInput(Console.ReadLine());

                if (userAnswer != correctAnswer)
                {
                    Console.WriteLine("That's not the correct answer, try again");
                }
                else
                {
                    Console.WriteLine("Correct answer, good work!");
                    Helpers.AddToHistory(num1, num2, userAnswer, operation, difficultyLevel);
                }

            } while (userAnswer != correctAnswer);
        }
    }
}
