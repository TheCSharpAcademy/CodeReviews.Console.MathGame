using MathGame.WinnieNgina.Models;
namespace MathGame.WinnieNgina
{
    internal class GameEngine
    {
        internal void DivisionGame(string message)
        {
            var score = 0;
            Console.WriteLine(message);
            string count = Helpers.GetQuestions();
            for (int i = 0; i < int.Parse(count); i++)
            {
                var divisionNumbers = Helpers.GetDivisionNumbers();
                var firstNumber = divisionNumbers.FirstNumber;
                var secondNumber = divisionNumbers.SecondNumber;
                var difficultyLevel = divisionNumbers.Level;
                Console.WriteLine($"{firstNumber} / {secondNumber}");
                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);
                if (int.Parse(result) == firstNumber / secondNumber)
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question");
                    score++;
                    Helpers.AddToHistory(score, GameType.Division, difficultyLevel);
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                    Console.ReadLine();
                }
            }
            Console.WriteLine($"Game over! Your score is {score}.Length Press any key to go back to the main menu.");
            Console.ReadLine();

        }

        internal void MultiplicationGame(string message)
        {
            Console.WriteLine(message);
            var score = 0;
            string count = Helpers.GetQuestions();
            for (int i = 0; i < int.Parse(count); i++)
            {
                var multiplicationNumbers = Helpers.GetNumbers();
                var firstNumber = multiplicationNumbers.FirstNumber;
                var secondNumber = multiplicationNumbers.SecondNumber;
                var difficultyLevel = multiplicationNumbers.Level;
                Console.WriteLine($"{firstNumber} * {secondNumber}");
                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);
                if (int.Parse(result) == firstNumber * secondNumber)
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question");
                    score++;
                    Helpers.AddToHistory(score, GameType.Multiplication, difficultyLevel);
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                    Console.ReadLine();
                }
            }
            Console.WriteLine($"Game over! Your score is {score}.Length Press any key to go back to the main menu.");
            Console.ReadLine();
        }

        internal void AdditionGame(string message)
        {
            Console.WriteLine(message);
            var score = 0;
            string count = Helpers.GetQuestions();
            for (int i = 0; i < int.Parse(count); i++)
            {
                var additionNumbers = Helpers.GetNumbers();
                var firstNumber = additionNumbers.FirstNumber;
                var secondNumber = additionNumbers.SecondNumber;
                var difficultyLevel = additionNumbers.Level;
                Console.WriteLine($"{firstNumber} + {secondNumber}");
                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);
                if (int.Parse(result) == firstNumber + secondNumber)
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question");
                    score++;
                    Helpers.AddToHistory(score, GameType.Addition, difficultyLevel);
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                    Console.ReadLine();
                }
            }
            Console.WriteLine($"Game over! Your score is {score}.Length Press any key to go back to the main menu.");
            Console.ReadLine();

        }
        internal void SubtractionGame(string message)
        {
            Console.WriteLine(message);
            var score = 0;
            string count = Helpers.GetQuestions();
            for (int i = 0; i < int.Parse(count); i++)
            {
                var subtractionNumbers = Helpers.GetNumbers();
                var firstNumber = subtractionNumbers.FirstNumber;
                var secondNumber = subtractionNumbers.SecondNumber;
                var difficultyLevel = subtractionNumbers.Level;
                Console.WriteLine($"{firstNumber} - {secondNumber}");
                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);
                if (int.Parse(result) == firstNumber - secondNumber)
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question");
                    score++;
                    Helpers.AddToHistory(score, GameType.Subtraction, difficultyLevel);
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                    Console.ReadLine();
                }
            }
            Console.WriteLine($"Game over! Your score is {score}.Length Press any key to go back to the main menu.");
            Console.ReadLine();

        }

        internal void RandomGame(string message)
        {
            Console.WriteLine(message);
            var random = new Random();
            var game = random.Next(0, 4);
            switch (game)
            {
                case 0:
                    DivisionGame("We are planning division game now");
                    break;
                case 1:
                    AdditionGame("We are playing addition game now");
                    break;
                case 2:
                    MultiplicationGame("We are planning multiplication game now");
                    break;
                case 3:
                    SubtractionGame("We are planning subtraction game now");
                    break;
            }
        }
    }
}
