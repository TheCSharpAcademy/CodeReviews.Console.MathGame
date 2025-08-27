using MathGame.Models;

namespace MathGame
{
    internal class GameEngine
    {
        internal void AdditionGame(string message)
        {
            Console.Clear();
            Console.WriteLine(message);

            Difficulty difficulty = Helpers.ChooseDifficulty();
            var random = new Random();
            var score = 0;
            int firstNumber = 0;
            int secondNumber = 0;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);

                Helpers.CheckDifficulty(difficulty, random, ref firstNumber, ref secondNumber);

                Console.WriteLine($"{firstNumber} + {secondNumber}");

                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber + secondNumber)
                {
                    Console.WriteLine("Your answer is correct!\nType any key for the next question");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("your answer is incorrect!\nType any key for the next question");
                    Console.ReadLine();
                }
                if (i == 4)
                {
                    Console.WriteLine($"Game over.Your final score is {score}.\nType any key to go back to main menu");
                    Console.ReadLine();
                }
            }
            Helpers.AddToHistory(GameType.Addition, score, difficulty);
        }
        internal void SubtractionGame(string message)
        {
            Console.Clear();
            Console.WriteLine(message);

            Difficulty difficulty = Helpers.ChooseDifficulty();
            var random = new Random();
            var score = 0;

            int firstNumber = 0;
            int secondNumber = 0;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);

                Helpers.CheckDifficulty(difficulty, random, ref firstNumber, ref secondNumber);
                Console.WriteLine($"{firstNumber} - {secondNumber}");

                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber - secondNumber)
                {
                    Console.WriteLine("Your answer is correct!\nType any key for the next question");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("your answer is incorrect!\nType any key for the next question");
                    Console.ReadLine();
                }
                if (i == 4)
                {
                    Console.WriteLine($"Game over.Your final score is {score}/5");
                }
            }
            Helpers.AddToHistory(GameType.Subtraction, score, difficulty);
        }
        internal void MultiplicationGame(string message)
        {
            Console.Clear();
            Console.WriteLine(message);

            Difficulty difficulty = Helpers.ChooseDifficulty();
            var random = new Random();
            var score = 0;

            int firstNumber = 0;
            int secondNumber = 0;
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(message);
                Console.Clear();
                Helpers.CheckDifficulty(difficulty, random, ref firstNumber, ref secondNumber);
                Console.WriteLine($"{firstNumber} x {secondNumber}");

                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber * secondNumber)
                {
                    Console.WriteLine("Your answer is correct!\nType any key for the next question");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("your answer is incorrect!\nType any key for the next question");
                    Console.ReadLine();
                }
                if (i == 4)
                {
                    Console.WriteLine($"Game over.Your final score is {score}/5");
                }
            }
            Helpers.AddToHistory(GameType.Multiplication, score, difficulty);
        }
        internal void DivisionGame(string message)
        {
            Console.Clear();
            Difficulty difficulty = Helpers.ChooseDifficulty();

            var score = 0;
            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);

                var divisonNumbers = Helpers.GetDivisionNumbers(difficulty);

                var firstNumber = divisonNumbers[0];
                var secondNumber = divisonNumbers[1];

                Console.WriteLine($"{firstNumber} / {secondNumber}");
                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);
                if (int.Parse(result) == firstNumber / secondNumber)
                {
                    Console.WriteLine("Your answer is correct!\nType any key for the next question");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("your answer is incorrect!\nType any key for the next question");
                    Console.ReadLine();
                }
                if (i == 4)
                {
                    Console.WriteLine($"Game over.Your final score is {score}.\nType any key to go back to main menu");
                    Console.ReadLine();
                }
            }
            Helpers.AddToHistory(GameType.Division, score, difficulty);
        }
    }
}
