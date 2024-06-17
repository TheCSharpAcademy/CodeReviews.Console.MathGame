
using static MathGame.Models.Game;



namespace MathGame
{
    internal class GameEngine
    {
        internal void AdditionGame(string message)
        {
            Console.WriteLine($"{message}");

            var random = new Random();

            int score = 0;
            int lives = 3;
            for (int i = 0; i < 10; i++)
            {

                int firstNumber = random.Next(1, 9);
                int secondNumber = random.Next(1, 9);
                Console.WriteLine($"{firstNumber} + {secondNumber}");

                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);
                
                if (int.Parse(result) == firstNumber + secondNumber)
                {
                    Console.WriteLine("Your answer was correct");
                    score++;
                }
                else
                {
                    Console.WriteLine("Your answer is incorrect");
                    lives--;
                }

                if (lives == 0)
                {
                    Console.WriteLine("you are out of lives! try again!");
                    
                    break;
                }
            }
            Console.WriteLine($"You scored {score}!");
            Helpers.AddToHistory(GameType.Addition, score);
        }
        internal void SubtractionGame(string message)
        {
            Console.WriteLine($"{message}");

            var random = new Random();

            int score = 0;
            int lives = 3;
            for (int i = 0; i < 10; i++)
            {

                int firstNumber = random.Next(1, 9);
                int secondNumber = random.Next(1, 9);
                Console.WriteLine($"{firstNumber} - {secondNumber}");

                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber - secondNumber)
                {
                    Console.WriteLine("Your answer was correct");
                    score++;
                }
                else
                {
                    Console.WriteLine("Your answer is incorrect");
                    lives--;
                }

                if (lives == 0)
                {
                    Console.WriteLine("you are out of lives! try again!");
                    break;
                    
                }
            }
            Console.WriteLine($"You scored {score}!");
            Helpers.AddToHistory(GameType.Subtraction, score);
        }
        internal void MultiplicationGame(string message)
        {
            Console.WriteLine($"{message}");

            var random = new Random();

            int score = 0;
            int lives = 3;
            for (int i = 0; i < 10; i++)
            {

                int firstNumber = random.Next(1, 9);
                int secondNumber = random.Next(1, 9);
                Console.WriteLine($"{firstNumber} * {secondNumber}");

                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber * secondNumber)
                {
                    Console.WriteLine("Your answer was correct");
                    score++;
                }
                else
                {
                    Console.WriteLine("Your answer is incorrect");
                    lives--;
                }

                if (lives == 0)
                {
                    Console.WriteLine("you are out of lives! try again!");
                    break;
                    
                }
            }
            Console.WriteLine($"You scored {score}!");
            Helpers.AddToHistory(GameType.Multiplication, score);
        }
        internal void DivisionGame(string message)
        {
            int score = 0;
            int lives = 3;
            for (int i = 0; i < 10; i++)
            {
                var divisionNumbers = Helpers.GetDivisionNumbers();
                var firstNumber = divisionNumbers[0];
                var secondNumber = divisionNumbers[1];

                Console.WriteLine($"{firstNumber} / {secondNumber}");
                
                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber / secondNumber)
                {
                    Console.WriteLine("Your answer was correct");
                    score++;
                }
                else
                {
                    Console.WriteLine("Your answer is incorrect");
                    lives--;
                }

                if (lives == 0)
                {
                    Console.WriteLine("you are out of lives! try again!");
                    break;
                    
                }
            }
            Console.WriteLine($"You scored {score}!");
            Helpers.AddToHistory(GameType.Division, score);
        }
    }
}
