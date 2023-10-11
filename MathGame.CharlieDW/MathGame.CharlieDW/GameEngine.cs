using MathGame.CharlieDW.Models;

namespace MathGame.CharlieDW
{
    internal class GameEngine
    {
        internal void Add(string message)
        {
            var score = 0;
            bool isCorrect = true;
            var random = new Random();

            do
            {
                Console.Clear();
                Console.WriteLine(message);

                // create nums
                int firstNumber = random.Next(1, 9);
                int secondNumber = random.Next(1, 9);

                // ask question + get user input
                Console.WriteLine($"{firstNumber} + {secondNumber}");
                string result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber + secondNumber)
                {
                    Console.WriteLine("Success! Press any key for the next exercise.");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Not quite there yet.");
                    isCorrect = false;
                }
            } while (isCorrect);

            Helpers.AddToHistory(score, GameType.Addition);
            Console.WriteLine($"You're score for this game was: {score}");

        }

        internal void Substract(string message)
        {
            var score = 0;
            bool isCorrect = true;
            var random = new Random();

            do
            {
                Console.Clear();
                Console.WriteLine(message);

                // create nums
                int firstNumber = random.Next(1, 9);
                int secondNumber = random.Next(1, 9);

                // ask question + get user input
                Console.WriteLine($"{firstNumber} - {secondNumber}");
                string result = Console.ReadLine();

                result = Helpers.ValidateResult(result);
                
                if (int.Parse(result) == firstNumber - secondNumber)
                {
                    Console.WriteLine("Success! Press any key for the next exercise.");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Not quite there yet.");
                    isCorrect = false;
                }
            } while (isCorrect);

            Helpers.AddToHistory(score, GameType.Substraction);

            Console.WriteLine($"You're score for this game was: {score}");
        }

        internal void Divide(string message)
        {
            var score = 0;
            bool isCorrect = true;
            
            
            do
            {
                Console.Clear();
                Console.WriteLine(message);

                // create nums
                var numbers = Helpers.GetDivisionNumbers();
                int firstNumber = numbers[0];
                int secondNumber = numbers[1];

                // ask question + get user input
                Console.WriteLine($"{firstNumber} / {secondNumber}");
                string result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (int.Parse(result)== firstNumber / secondNumber)
                {
                    Console.WriteLine("Success! Press any key for the next exercise.");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Not quite there yet.");
                    isCorrect = false;
                }
            } while (isCorrect);

            Helpers.AddToHistory(score, GameType.Division);

            Console.WriteLine($"You're score for this game was: {score}");
        }

        internal void Multiply(string message)
        {
            var score = 0;
            bool isCorrect = true;
            var random = new Random();

            do
            {
                Console.Clear();
                Console.WriteLine(message);

                // create nums
                int firstNumber = random.Next(1, 9);
                int secondNumber = random.Next(1, 9);

                // ask question + get user input
                Console.WriteLine($"{firstNumber} * {secondNumber}");
                string result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber * secondNumber)
                {
                    Console.WriteLine("Success! Press any key for the next exercise.");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Not quite there yet.");
                    isCorrect = false;
                }
            } while (isCorrect);

            Helpers.AddToHistory(score, GameType.Multiplication);

            Console.WriteLine($"You're score for this game was: {score}");
        }

        internal void ExitGame(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
        }
    }
}
