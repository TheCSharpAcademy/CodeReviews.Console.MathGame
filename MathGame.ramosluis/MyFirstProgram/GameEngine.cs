using MyFirstProgram.Models;

namespace MyFirstProgram
{
    internal class GameEngine
    {
        internal void AdditionGame(string message)
        {
            var random = new Random();
            var score = 0;
            int firstNumber;
            int secondNumber;

            for (var i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);

                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);

                Console.WriteLine($"{firstNumber} + {secondNumber}");
                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == (firstNumber + secondNumber))
                {
                    Console.WriteLine("Your answer was correct! Press enter for the next question");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Press enter for the next question");
                    Console.ReadLine();
                }

                if (i == 4)
                {
                    Console.Clear();
                    Console.WriteLine($"Game over. Your final score is {score}. Press enter to go back to the main menu");
                    Console.ReadLine();
                }
            }

            Helpers.AddToHistory(score, GameType.Addition);
        }

        internal void SubtractionGame(string message)
        {
            var random = new Random();
            var score = 0;
            int firstNumber;
            int secondNumber;

            for (var i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);

                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);

                Console.WriteLine($"{firstNumber} - {secondNumber}");
                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == (firstNumber - secondNumber))
                {
                    Console.WriteLine("Your answer was correct! Press enter for the next question");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Press enter for the next question");
                    Console.ReadLine();
                }

                if (i == 4)
                {
                    Console.Clear();
                    Console.WriteLine($"Game over. Your final score is {score}. Press enter to go back to the main menu");
                    Console.ReadLine();
                }
            }

            Helpers.AddToHistory(score, GameType.Subtraction);
        }

        internal void MultiplicationGame(string message)
        {
            var random = new Random();
            var score = 0;
            int firstNumber;
            int secondNumber;

            for (var i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);

                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);

                Console.WriteLine($"{firstNumber} * {secondNumber}");
                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == (firstNumber * secondNumber))
                {
                    Console.WriteLine("Your answer was correct! Press enter for the next question");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Press enter for the next question");
                    Console.ReadLine();
                }

                if (i == 4)
                {
                    Console.Clear();
                    Console.WriteLine($"Game over. Your final score is {score}. Press enter to go back to the main menu");
                    Console.ReadLine();
                }
            }

            Helpers.AddToHistory(score, GameType.Multiplication);
        }

        internal void DivisionGame(string message)
        {
            var score = 0;
            int firstNumber;
            int secondNumber;

            for (var i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);

                int[] divisionNumbers = Helpers.GetDivisionNumbers();
                firstNumber = divisionNumbers[0];
                secondNumber = divisionNumbers[1];
                Console.WriteLine($"{firstNumber} / {secondNumber}");

                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == (firstNumber / secondNumber))
                {
                    Console.WriteLine("Your answer was correct! Press enter for the next question");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Press enter for the next question");
                    Console.ReadLine();
                }

                if (i == 4)
                {
                    Console.Clear();
                    Console.WriteLine($"Game over. Your final score is {score}. Press enter to go back to the main menu");
                    Console.ReadLine();
                }
            }

            Helpers.AddToHistory(score, GameType.Division);
        }
    }
}
