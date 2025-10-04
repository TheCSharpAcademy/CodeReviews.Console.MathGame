using MathGame.Models;

namespace MathGame
{
    internal class GameEngine
    {
        internal void AdditionGame(string message)
        {
            DifficultyOptions difficultyOption = Helpers.GetDifficultyOption();
            
            int firstNumber;
            int secondNumber;
            int score = 0;
            DateTime start = DateTime.Now;
            TimeSpan duration = TimeSpan.Zero;
            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);
                firstNumber = Helpers.GetRandomNumber(difficultyOption);
                secondNumber = Helpers.GetRandomNumber(difficultyOption);

                Console.WriteLine($"{firstNumber} + {secondNumber}");
                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);
                
                if (int.Parse(result) == (firstNumber + secondNumber))
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question.");
                    Console.ReadLine();
                    score++;
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Type any key for the next question.");
                    Console.ReadLine();
                }
                if (i == 4)
                {
                    DateTime end = DateTime.Now;
                    duration = end - start;
                    Console.WriteLine($"Game over. Your final score is {score}. Time: {duration.Seconds} seconds. Press any key to go back to the main menu.");
                    Console.ReadLine();
                }
            }
            
            Helpers.AddToHistory(score, GameType.Addition, difficultyOption, duration);

        }

        internal void SubstractionGame(string message)
        {
            DifficultyOptions difficultyOption = Helpers.GetDifficultyOption();

            int firstNumber;
            int secondNumber;
            int score = 0;
            DateTime start = DateTime.Now;
            TimeSpan duration = TimeSpan.Zero;
            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);
                firstNumber = Helpers.GetRandomNumber(difficultyOption);
                secondNumber = Helpers.GetRandomNumber(difficultyOption);

                Console.WriteLine($"{firstNumber} - {secondNumber}");
                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == (firstNumber - secondNumber))
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question.");
                    Console.ReadLine();
                    score++;
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Type any key for the next question.");
                    Console.ReadLine();
                }
                if (i == 4)
                {
                    DateTime end = DateTime.Now;
                    duration = end - start;
                    Console.WriteLine($"Game over. Your final score is {score}. Time: {duration.Seconds} seconds. Press any key to go back to the main menu.");
                    Console.ReadLine();
                }
            }
            Helpers.AddToHistory(score, GameType.Substraction, difficultyOption, duration);
        }

        internal void MultiplicationGame(string message)
        {
            DifficultyOptions difficultyOption = Helpers.GetDifficultyOption();

            int firstNumber;
            int secondNumber;
            int score = 0;
            DateTime start = DateTime.Now;
            TimeSpan duration = TimeSpan.Zero;
            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);
                firstNumber = Helpers.GetRandomNumber(difficultyOption);
                secondNumber = Helpers.GetRandomNumber(difficultyOption);

                Console.WriteLine($"{firstNumber} * {secondNumber}");
                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == (firstNumber * secondNumber))
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question.");
                    Console.ReadLine();
                    score++;
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Type any key for the next question.");
                    Console.ReadLine();
                }
                if (i == 4)
                {
                    DateTime end = DateTime.Now;
                    duration = end - start;
                    Console.WriteLine($"Game over. Your final score is {score}. Time: {duration.Seconds} seconds. Press any key to go back to the main menu.");
                    Console.ReadLine();
                }
            }
            Helpers.AddToHistory(score, GameType.Multiplication, difficultyOption, duration);
        }

        internal void DivisionGame(string message)
        {
            DifficultyOptions difficultyOption = Helpers.GetDifficultyOption();
            int score = 0;
            DateTime start = DateTime.Now;
            TimeSpan duration = TimeSpan.Zero;
            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);
                var divisionNumbers = Helpers.GetDivisionNumbers(difficultyOption);
                var firstNumber = divisionNumbers[0];
                var secondNumber = divisionNumbers[1];

                Console.WriteLine($"{firstNumber} / {secondNumber}");
                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == (firstNumber / secondNumber))
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question.");
                    Console.ReadLine();
                    score++;
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Type any key for the next question.");
                    Console.ReadLine();
                }
                if (i == 4)
                {
                    DateTime end = DateTime.Now;
                    duration = end - start;
                    Console.WriteLine($"Game over. Your final score is {score}. Time: {duration.Seconds} seconds. Press any key to go back to the main menu.");
                    Console.ReadLine();
                }
            }
            Helpers.AddToHistory(score, GameType.Division, difficultyOption, duration);
        }
    }
}
