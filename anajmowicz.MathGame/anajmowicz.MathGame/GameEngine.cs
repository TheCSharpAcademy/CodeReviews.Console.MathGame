using anajmowicz.MathGame.Models;

namespace anajmowicz.MathGame
{
    internal class GameEngine
    {
        internal void DivisionGame(GameType type)
        {
            Console.WriteLine($"{type} game selected");
            var random = new Random();
            int firstNumber;
            int secondNumber;
            int product;
            var score = 0;

            for (int i = 0; i < 5; i++)
            {
                firstNumber = random.Next(1, 10);
                secondNumber = random.Next(1, 10);
                product = firstNumber * secondNumber;

                Console.WriteLine($"{product} / {firstNumber} = ");
                var result = Console.ReadLine();

                if (int.Parse(result) == secondNumber)
                {
                    Console.WriteLine("Your answer was correct. Press any key for the next question.");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Press any key for the next question.");
                    Console.ReadLine();
                }

                if (i == 4)
                {
                    Console.WriteLine($"Game over. Your final score: {score}. Press any key to go back to main menu.");
                    Helpers.AddToHistory(type, score);
                    Console.ReadLine();
                }
            }
        }

        internal void MultiplicationGame(GameType type)
        {
            Console.WriteLine($"{type} game selected");
            var random = new Random();
            int firstNumber;
            int secondNumber;
            var score = 0;

            for (int i = 0; i < 5; i++)
            {
                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);

                Console.WriteLine($"{firstNumber} * {secondNumber} = ");
                var result = Console.ReadLine();

                if (int.Parse(result) == firstNumber * secondNumber)
                {
                    Console.WriteLine("Your answer was correct. Press any key for the next question.");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Press any key for the next question.");
                    Console.ReadLine();
                }

                if (i == 4)
                {
                    Console.WriteLine($"Game over. Your final score: {score}. Press any key to go back to main menu.");
                    Helpers.AddToHistory(type, score);
                    Console.ReadLine();
                }
            }
        }

        internal void SubtractionGame(GameType type)
        {
            Console.WriteLine($"{type} game selected");
            var random = new Random();
            int firstNumber;
            int secondNumber;
            var score = 0;

            for (int i = 0; i < 5; i++)
            {
                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);

                Console.WriteLine($"{firstNumber} - {secondNumber} = ");
                var result = Console.ReadLine();

                if (int.Parse(result) == firstNumber - secondNumber)
                {
                    Console.WriteLine("Your answer was correct. Press any key for the next question.");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Press any key for the next question.");
                    Console.ReadLine();
                }

                if (i == 4)
                {
                    Console.WriteLine($"Game over. Your final score: {score}. Press any key to go back to main menu.");
                    Helpers.AddToHistory(type, score);
                    Console.ReadLine();
                }
            }
        }

        internal void AdditionGame(GameType type)
        {
            Console.WriteLine($"{type} game selected");
            var random = new Random();
            int firstNumber;
            int secondNumber;
            var gameScore = 0;

            for (int i = 0; i < 5; i++)
            {
                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);

                Console.WriteLine($"{firstNumber} + {secondNumber} = ");
                var result = Console.ReadLine();

                if (int.Parse(result) == firstNumber + secondNumber)
                {
                    Console.WriteLine("Your answer was correct. Press any key for the next question.");
                    gameScore++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Press any key for the next question.");
                    Console.ReadLine();
                }

                if (i == 4)
                {
                    Console.WriteLine($"Game over. Your final score: {gameScore}. Press any key to go back to main menu.");
                    Helpers.AddToHistory(type, gameScore);
                    Console.ReadLine();
                }
            }
        }
    }
}
