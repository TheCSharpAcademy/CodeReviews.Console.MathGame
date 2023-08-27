using MathGameConsole.Models;

namespace MathGameConsole
{
    internal class GameEngine
    {
        internal void PlayGame(int choice)
        {
            var difficulty = Helpers.DifficultyMultiplier();
            var numberOfQuestions = Helpers.totalQuestions();
            var random = new Random();
            int score = 0;

            var gameList = new Dictionary<int, GameType>()
                {
                    {1, GameType.Addition}, {2, GameType.Subtraction}, {3, GameType.Division }, {4, GameType.Multiplication }, {5, GameType.Random }
                };

            DateTime startTime = DateTime.Now;

            for (int i = 0; i < numberOfQuestions; i++)
            {
                Console.Clear();

                Console.WriteLine($"Current score: {score}/{numberOfQuestions}");

                int firstNumber = random.Next(1, 9 * difficulty);
                int secondNumber = random.Next(1, 9 * difficulty);

                var result = "No Value";
                int correctAnswer = 0;
                int operation;

                if (choice == 5)
                {
                    operation = random.Next(1, 5);
                }
                else
                {
                    operation = choice;
                }

                switch (operation)
                {
                    case 1:
                        Console.WriteLine($"{firstNumber} + {secondNumber}");
                        correctAnswer = firstNumber + secondNumber;
                        result = Console.ReadLine();
                        break;
                    case 2:
                        if (secondNumber > firstNumber)
                        {
                            Console.WriteLine($"{secondNumber} - {firstNumber}");
                            correctAnswer = secondNumber - firstNumber;
                        } else 
                        {
                            Console.WriteLine($"{firstNumber} - {secondNumber}");
                            correctAnswer = firstNumber - secondNumber;
                        }                        
                        result = Console.ReadLine();
                        break;
                    case 3:
                        var divisionNumbers = Helpers.GetDivisionNumbers();
                        firstNumber = divisionNumbers[0] * difficulty;
                        secondNumber = divisionNumbers[1] * difficulty;
                        Console.WriteLine($"{firstNumber} / {secondNumber}");
                        correctAnswer = firstNumber / secondNumber;
                        result = Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine($"{firstNumber} * {secondNumber}");
                        correctAnswer = firstNumber * secondNumber;
                        result = Console.ReadLine();
                        break;
                    default:
                        break;
                }

                result = Helpers.ValidateResult(result!);

                if (int.Parse(result!) == correctAnswer)
                {
                    score++;
                }
            }
            Console.Clear();
            String gameTime = Helpers.GameTime(startTime, score, numberOfQuestions);
            Console.ReadLine();
            Helpers.AddToHistory(numberOfQuestions, score, gameList[choice], gameTime);
        }

    }
}
