
using static Math_Game.Models.Game;

namespace Math_Game
{
    internal class GameEngine
    {
        internal void DivisionGame(string message,DifficultyLevel difficulty)
        {

            var score = 0;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.Write($@"Difficulty: ");
                Helpers.ColorPicker(difficulty);
                Console.WriteLine(message);
                var divisionNumbers = Helpers.GetDivisionNumbers(difficulty);
                var firstNumber = divisionNumbers[0];
                var secondNumber = divisionNumbers[1];

                Console.WriteLine($"{firstNumber} / {secondNumber}");
                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber / secondNumber)
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question.");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Type any key for the next question.");
                    Console.ReadLine();
                }

                if (i == 4)
                {
                    Console.WriteLine($"Game over. Your final score is {score}! Press any key to go back to the main method.");
                    Console.ReadLine();

                }


            }

            Helpers.AddToHistory(score, GameType.Division, difficulty);
        }
        internal void MultiplicationGame(string message, DifficultyLevel difficulty)
        {
            var random = new Random();
            var score = 0;
            var firstNumber = 0;
            var secondNumber = 0;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.Write($@"Difficulty: ");
                Helpers.ColorPicker(difficulty);
                Console.WriteLine(message);

                switch (difficulty)//random numbers for each difficulty level
                {
                    case DifficultyLevel.Easy:
                        firstNumber = random.Next(1, 5);
                        secondNumber = random.Next(1, 5);
                        break;
                    case DifficultyLevel.Medium:
                        firstNumber = random.Next(1, 10);
                        secondNumber = random.Next(1, 10);
                        break;
                    case DifficultyLevel.Hard:
                        firstNumber = random.Next(9, 30);
                        secondNumber = random.Next(9, 30);
                        break;
                }

                Console.WriteLine($"{firstNumber} * {secondNumber}");
                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber * secondNumber)
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question.");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Type any key for the next question.");
                    Console.ReadLine();
                }

                if (i == 4)
                {
                    Console.WriteLine($"Game over. Your final score is {score}! Press any key to go back to the main method.");
                    Console.ReadLine();
                }

            }

            Helpers.AddToHistory(score, GameType.Multiplication, difficulty);
        }
        internal void SubtractionGame(string message, DifficultyLevel difficulty)
        {
            var random = new Random();
            var score = 0;
            var firstNumber = 0;
            var secondNumber = 0;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.Write($@"Difficulty: ");
                Helpers.ColorPicker(difficulty);
                Console.WriteLine(message);

                switch (difficulty)
                {
                    case DifficultyLevel.Easy:
                        firstNumber = random.Next(6, 10);
                        secondNumber = random.Next(0, 5);
                        break;
                    case DifficultyLevel.Medium:
                        firstNumber = random.Next(1, 10);
                        secondNumber = random.Next(1, 9);
                        break;
                    case DifficultyLevel.Hard:
                        firstNumber = random.Next(9, 30);
                        secondNumber = random.Next(9, 30);
                        break;
                }

                Console.WriteLine($"{firstNumber} - {secondNumber}");
                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);



                if (int.Parse(result) == firstNumber - secondNumber)
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question.");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Type any key for the next question.");
                    Console.ReadLine();
                }

                if (i == 4)
                {
                    Console.WriteLine($"Game over. Your final score is {score}! Press any key to go back to the main method.");
                    Console.ReadLine();
                }

            }

            Helpers.AddToHistory(score, GameType.Subtraction, difficulty);
        }
        internal void AdditionGame(string message, DifficultyLevel difficulty)
        {
            var random = new Random();
            var score = 0;
            var firstNumber = 0;
            var secondNumber = 0;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.Write($@"Difficulty: ");
                Helpers.ColorPicker(difficulty);
                Console.WriteLine(message);
                switch (difficulty)
                {
                    case DifficultyLevel.Easy:
                        firstNumber = random.Next(1, 5);
                        secondNumber = random.Next(1, 5);
                        break;
                    case DifficultyLevel.Medium:
                        firstNumber = random.Next(1, 9);
                        secondNumber = random.Next(1, 9);
                        break;
                    case DifficultyLevel.Hard:
                        firstNumber = random.Next(9, 30);
                        secondNumber = random.Next(9, 30);
                        break;
                }

                Console.WriteLine($"{firstNumber} + {secondNumber}");

                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber + secondNumber)
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question.");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Type any key for the next question.");
                    Console.ReadLine();
                }

                if (i == 4)
                {
                    Console.WriteLine($"Game over. Your final score is {score}! Press any key to go back to the main method.");
                    Console.ReadLine();
                }

            }

            Helpers.AddToHistory(score, GameType.Addition, difficulty);
        
        }

    }
}
