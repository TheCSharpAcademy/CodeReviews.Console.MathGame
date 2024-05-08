
namespace math_console_app
{
    internal class GameEngine
    {
        internal void AdditionGame(string message)
        {

            var random = new Random();
            int firstNumber;
            int secondNumber;
            var score = 0;
            int numberLimit;
            string difficulty = Helpers.GetDifficulty();

            switch(difficulty)
            {
                case "e":
                    numberLimit = 10;
                    break;
                case "m":
                    numberLimit = 100;
                    break;
                case "h":
                    numberLimit = 1000;
                    break;
                default:
                    numberLimit = 10;
                    break;
            }


            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);

                firstNumber = random.Next(1, numberLimit);
                secondNumber = random.Next(1, numberLimit);

                Console.WriteLine($"{firstNumber} + {secondNumber} = ");

                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber + secondNumber)
                {
                    Console.WriteLine("Your answer is correct! Press any key for the next question.");
                    score++;
                    Console.ReadKey(true);
                }
                else
                {
                    Console.WriteLine("Your answer is incorrect! Press any key for the next question.");
                    Console.ReadKey(true);
                }

                if (i == 4)
                {
                    Console.Clear();
                    Console.WriteLine($"Game Over. Your final score is {score}. Press any key to return the the main menu.");
                    Console.ReadKey(true);
                }
            }

            Helpers.AddToHistory(score, GameType.Addition, difficulty);
        }

        internal void SubtractionGame(string message)
        {

            var random = new Random();
            int firstNumber;
            int secondNumber;
            var score = 0;
            int numberLimit;
            string difficulty = Helpers.GetDifficulty();

            switch (difficulty)
            {
                case "e":
                    numberLimit = 10;
                    break;
                case "m":
                    numberLimit = 100;
                    break;
                case "h":
                    numberLimit = 1000;
                    break;
                default:
                    numberLimit = 10;
                    break;
            }

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);

                firstNumber = random.Next(1, numberLimit);
                secondNumber = random.Next(1, numberLimit);

                Console.WriteLine($"{firstNumber} - {secondNumber} = ");

                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber - secondNumber)
                {
                    Console.WriteLine("Your answer is correct! Press any key for the next question.");
                    score++;
                    Console.ReadKey(true);
                }
                else
                {
                    Console.WriteLine("Your answer is incorrect! Press any key for the next question.");
                    Console.ReadKey(true);
                }

                if (i == 4)
                {
                    Console.Clear();
                    Console.WriteLine($"Game Over. Your final score is {score}. Press any key to return the the main menu.");
                    Console.ReadKey(true);
                }

            }

            Helpers.AddToHistory(score, GameType.Subtraction, difficulty);
        }

        internal void MultiplicationGame(string message)
        {

            var random = new Random();
            int firstNumber;
            int secondNumber;
            var score = 0;
            int numberLimit;
            string difficulty = Helpers.GetDifficulty();

            switch (difficulty)
            {
                case "e":
                    numberLimit = 10;
                    break;
                case "m":
                    numberLimit = 100;
                    break;
                case "h":
                    numberLimit = 1000;
                    break;
                default:
                    numberLimit = 10;
                    break;
            }

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);

                firstNumber = random.Next(1, numberLimit);
                secondNumber = random.Next(1, numberLimit);

                Console.WriteLine($"{firstNumber} * {secondNumber} = ");

                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber * secondNumber)
                {
                    Console.WriteLine("Your answer is correct! Press any key for the next question.");
                    score++;
                    Console.ReadKey(true);
                }
                else
                {
                    Console.WriteLine("Your answer is incorrect! Press any key for the next question.");
                    Console.ReadKey(true);
                }

                if (i == 4)
                {
                    Console.Clear();
                    Console.WriteLine($"Game Over. Your final score is {score}. Press any key to return the the main menu.");
                    Console.ReadKey(true);
                }

            }

            Helpers.AddToHistory(score, GameType.Multiplication, difficulty);
        }

        internal void DivisionGame(string message)
        {

            var score = 0;
            int numberLimitUpper;
            int numberLimitLower;
            string difficulty = Helpers.GetDifficulty();

            switch (difficulty)
            {
                case "e":
                    numberLimitLower = 1;
                    numberLimitUpper = 100;
                    break;
                case "m":
                    numberLimitLower = 11;
                    numberLimitUpper = 10000;
                    break;
                case "h":
                    numberLimitLower = 11;
                    numberLimitUpper = 100000;
                    break;
                default:
                    numberLimitLower = 1000;
                    numberLimitUpper = 1;
                    break;
            }

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);


                var numbers = Helpers.GetDivisionNumbers(numberLimitLower, numberLimitUpper);

                Console.WriteLine($"{numbers[0]} / {numbers[1]} = ");

                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == numbers[0] / numbers[1])
                {
                    Console.WriteLine("Your answer is correct! Press any key for the next question.");
                    score++;
                    Console.ReadKey(true);
                }
                else
                {
                    Console.WriteLine("Your answer is incorrect! Press any key for the next question.");
                    Console.ReadKey(true);
                }

                if (i == 4)
                {
                    Console.Clear();
                    Console.WriteLine($"Game Over. Your final score is {score}. Press any key to return the the main menu.");
                    Console.ReadKey(true);
                }

            }

            Helpers.AddToHistory(score, GameType.Division, difficulty);
        }
    }
}
