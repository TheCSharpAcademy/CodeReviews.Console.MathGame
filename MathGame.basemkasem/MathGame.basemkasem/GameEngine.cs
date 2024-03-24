using MathGame.basemkasem.Modles;

namespace MathGame.basemkasem
{
    internal class GameEngine
    {
        internal void AdditionGame(string message)
        {
            Console.Clear();
            Console.WriteLine(message);

            var difficulty = Helpers.DifficultyLevelChosen();

            var random = new Random();
            var score = 0;

            int firstNumber;
            int secondNumber;
            for (int i = 0; i < 5; i++)
            {
                if (difficulty == GameDifficulty.Easy)
                {
                    firstNumber = random.Next(1, 9);
                    secondNumber = random.Next(1, 9);
                }
                else if (difficulty == GameDifficulty.Medium)
                {
                    firstNumber = random.Next(1, 100);
                    secondNumber = random.Next(1, 100);
                }
                else
                {
                    firstNumber = random.Next(1, 1000);
                    secondNumber = random.Next(1, 1000);
                }


                Console.Write($"{firstNumber} + {secondNumber} = ");

                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber + secondNumber)
                {
                    Console.WriteLine("Correct answer. Type any key for the next question");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Wrong answer. Type any key for the next question");
                    Console.ReadLine();
                }
            }
            Console.WriteLine($"Game Over. Your score is {score}. Press Any key to go back to menu.");
            Console.ReadLine();
            Helpers.AddToHistory(score, GameType.Addition, difficulty);
        }
        internal void SubtractionGame(string message)
        {
            Console.Clear();
            Console.WriteLine(message);

            var difficulty = Helpers.DifficultyLevelChosen();

            var random = new Random();
            var score = 0;

            int firstNumber;
            int secondNumber;
            for (int i = 0; i < 5; i++)
            {
                if (difficulty == GameDifficulty.Easy)
                {
                    firstNumber = random.Next(1, 9);
                    secondNumber = random.Next(1, 9);
                }
                else if (difficulty == GameDifficulty.Medium)
                {
                    firstNumber = random.Next(1, 100);
                    secondNumber = random.Next(1, 100);
                }
                else
                {
                    firstNumber = random.Next(1, 1000);
                    secondNumber = random.Next(1, 1000);
                }

                Console.Write($"{firstNumber} - {secondNumber} = ");

                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber - secondNumber)
                {
                    Console.WriteLine("Correct answer. Type any key for the next question");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Wrong answer. Type any key for the next question");
                    Console.ReadLine();
                }
            }
            Console.WriteLine($"Game Over. Your score is {score}. Press Any kkey to go back to menu.");
            Console.ReadLine();
            Helpers.AddToHistory(score, GameType.Subtraction, difficulty);
        }
        internal void MultiplicationGame(string message)
        {
            Console.Clear();
            Console.WriteLine(message);

            var difficulty = Helpers.DifficultyLevelChosen();

            var random = new Random();
            var score = 0;

            int firstNumber;
            int secondNumber;
            for (int i = 0; i < 5; i++)
            {
                if (difficulty == GameDifficulty.Easy)
                {
                    firstNumber = random.Next(1, 9);
                    secondNumber = random.Next(1, 9);
                }
                else if (difficulty == GameDifficulty.Medium)
                {
                    firstNumber = random.Next(1, 50);
                    secondNumber = random.Next(1, 50);
                }
                else
                {
                    firstNumber = random.Next(1, 100);
                    secondNumber = random.Next(1, 100);
                }

                Console.Write($"{firstNumber} * {secondNumber} = ");

                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber * secondNumber)
                {
                    Console.WriteLine("Correct answer. Type any key for the next question");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Wrong answer. Type any key for the next question");
                    Console.ReadLine();
                }
            }
            Console.WriteLine($"Game Over. Your score is {score}. Press Any kkey to go back to menu.");
            Console.ReadLine();
            Helpers.AddToHistory(score, GameType.Multiplication, difficulty);
        }
        internal void DivisionGame(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            var difficulty = Helpers.DifficultyLevelChosen();
            var score = 0;
            for (int i = 0; i < 5; i++)
            {
                var divisionNumbers = Helpers.GetDivisionNumbers(difficulty);

                var firstNumber = divisionNumbers[0];
                var secondNumber = divisionNumbers[1];

                Console.Write($"{firstNumber} / {secondNumber} = ");

                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber / secondNumber)
                {
                    Console.WriteLine("Correct answer. Type any key for the next question");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Wrong answer. Type any key for the next question");
                    Console.ReadLine();
                }
            }
            Console.WriteLine($"Game Over. Your score is {score}. Press Any key to go back to menu.");
            Console.ReadLine();
            Helpers.AddToHistory(score, GameType.Division, difficulty);
        }
    }
}
