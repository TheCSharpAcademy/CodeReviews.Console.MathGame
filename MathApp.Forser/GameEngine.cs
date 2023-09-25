namespace MathApp
{
    internal class GameEngine
    {
        internal void AdditionGame(string message)
        {
            Console.Clear();
            Console.WriteLine(message);

            var random = new Random();
            var score = 0;
            int firstNumber, secondNumber;

            for (int i = 0; i < 5; i++)
            {
                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);

                Console.WriteLine($"{firstNumber} + {secondNumber}");
                var result = Console.ReadLine();

                if (int.Parse(result) == firstNumber + secondNumber)
                {
                    Console.WriteLine("Your answer was correct!. Press any key for the next question!");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect!. Press any key for the next question!");
                    Console.ReadLine();
                }
            }

            Helpers.AddToHistory(score, "Addition");

            Console.WriteLine($"Game over. Your final score is {score}. Press any key to return to Main Menu!");
            Console.ReadLine();
        }
        internal void SubstractionGame(string message)
        {
            Console.Clear();
            Console.WriteLine(message);

            var random = new Random();
            var score = 0;
            int firstNumber, secondNumber;

            for (int i = 0; i < 5; i++)
            {
                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);

                Console.WriteLine($"{firstNumber} - {secondNumber}");
                var result = Console.ReadLine();

                if (int.Parse(result) == firstNumber - secondNumber)
                {
                    Console.WriteLine("Your answer was correct!. Press any key for the next question!");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect!. Press any key for the next question!");
                    Console.ReadLine();
                }
            }

            Helpers.AddToHistory(score, "Subtraction");
            Console.WriteLine($"Game over. Your final score is {score}. Press any key to return to Main Menu!");
            Console.ReadLine();
        }
        internal void MultiplicationGame(string message)
        {
            Console.Clear();
            Console.WriteLine(message);

            var random = new Random();
            var score = 0;
            int firstNumber, secondNumber;

            for (int i = 0; i < 5; i++)
            {
                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);

                Console.WriteLine($"{firstNumber} * {secondNumber}");
                var result = Console.ReadLine();

                if (int.Parse(result) == firstNumber * secondNumber)
                {
                    Console.WriteLine("Your answer was correct!. Press any key for the next question!");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect!. Press any key for the next question!");
                    Console.ReadLine();
                }
            }

            Helpers.AddToHistory(score, "Multiplication");
            Console.WriteLine($"Game over. Your final score is {score}. Press any key to return to Main Menu!");
            Console.ReadLine();
        }
        internal void DivisionGame(string message)
        {
            Console.Clear();
            Console.WriteLine(message);

            var score = 0;

            for (int i = 0; i < 5; i++)
            {
                var divisionNumbers = Helpers.GetDivisionNumbers();
                var firstNumber = divisionNumbers[0];
                var secondNumber = divisionNumbers[1];

                Console.WriteLine($"{firstNumber} / {secondNumber}");
                var result = Console.ReadLine();

                if (int.Parse(result) == firstNumber / secondNumber)
                {
                    Console.WriteLine("Your answer was correct!. Press any key for the next question!");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect!. Press any key for the next question!");
                    Console.ReadLine();
                }
            }

            Helpers.AddToHistory(score, "Division");
            Console.WriteLine($"Game over. Your final score is {score}. Press any key to return to Main Menu!");
            Console.ReadLine();
        }
    }
}
