using math_game.models;

namespace math_game
{
    internal class GameEngine
    {
        internal void AdditionGame(string message)
        {
            var random = new Random();
            var score = 0;

            int firstNumber;
            int secondNumber;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);

                firstNumber = random.Next(1, 20);
                secondNumber = random.Next(1, 20);

                Console.WriteLine($"{firstNumber} + {secondNumber}");
                int.TryParse(Console.ReadLine(), out int result);

                if (result == firstNumber + secondNumber)
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question.");
                    Console.ReadLine();
                    score += 20;
                }
                else
                {
                    Console.WriteLine("Sorry, your answer was wrong! Type any key for the next question.");
                    Console.ReadLine();
                }

            }
            helpers.AddToHistory(score, GameType.Addition);
            Console.WriteLine($"Game Over. Your final score is {score}. Press any key to go back to the main menu.");
            Console.ReadLine();
        }

        internal void SubtractionGame(string message)
        {
            var random = new Random();
            var score = 0;

            int firstNumber;
            int secondNumber;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);

                firstNumber = random.Next(1, 50);
                secondNumber = random.Next(1, firstNumber);

                Console.WriteLine($"{firstNumber} - {secondNumber}");
                int.TryParse(Console.ReadLine(), out int result);

                if (result == firstNumber - secondNumber)
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question.");
                    Console.ReadLine();
                    score += 20;
                }
                else
                {
                    Console.WriteLine("Sorry, your answer was wrong! Type any key for the next question.");
                    Console.ReadLine();
                }
            }
            helpers.AddToHistory(score, GameType.Subtraction);
            Console.WriteLine($"Game Over. Your final score is {score}. Press any key to go back to the main menu.");
            Console.ReadLine();
        }

        internal void MultiplicationGame(string message)
        {
            var random = new Random();
            var score = 0;

            int firstNumber;
            int secondNumber;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);

                firstNumber = random.Next(1, 20);
                secondNumber = random.Next(1, 10);
                Console.WriteLine($"{firstNumber} * {secondNumber}");
                int.TryParse(Console.ReadLine(), out int result);

                if (result == firstNumber * secondNumber)
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question.");
                    Console.ReadLine();
                    score += 20;
                }
                else
                {
                    Console.WriteLine("Sorry, your answer was wrong! Type any key for the next question.");
                    Console.ReadLine();
                }
            }
            helpers.AddToHistory(score, GameType.Multiplication);
            Console.WriteLine($"Game Over. Your final score is {score}. Press any key to go back to the main menu.");
            Console.ReadLine();
        }

        internal void DivisionGame(string message)
        {

            var random = new Random();
            var score = 0;

            int firstNumber;
            int secondNumber;

            for (int i = 0; i < 5; i++)
            {
                do
                {
                    firstNumber = random.Next(1, 100);
                    secondNumber = random.Next(1, firstNumber);
                } while (firstNumber % secondNumber != 0);

                Console.Clear();
                Console.WriteLine(message);

                Console.WriteLine($"{firstNumber} / {secondNumber}");
                int.TryParse(Console.ReadLine(), out int result);

                if (result == firstNumber / secondNumber)
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question.");
                    Console.ReadLine();
                    score += 20;
                }
                else
                {
                    Console.WriteLine("Sorry, your answer was wrong! Type any key for the next question.");
                    Console.ReadLine();
                }
            }

            helpers.AddToHistory(score, GameType.Division);
            Console.WriteLine($"Game Over. Your final score is {score}. Press any key to go back to the main menu.");
            Console.ReadLine();
        }
    }
}
