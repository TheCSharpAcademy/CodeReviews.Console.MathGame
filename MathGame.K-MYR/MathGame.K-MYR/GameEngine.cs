using MathGame.K_MYR.Models;

namespace MathGame.K_MYR
{
    internal class GameEngine
    {
        internal int AdditionGame(int NumberOfGames, DifficultyMode difficulty, bool randomGame = false)
        {
            DateTime startDate = DateTime.UtcNow;
            Random random = new Random();
            int score = 0;
            int firstNumber = 0;
            int secondNumber = 0;

            for (int i = 0; i < NumberOfGames; i++)
            {
                Console.Clear();

                switch (difficulty)
                {
                    case DifficultyMode.Hard:
                        firstNumber = random.Next(50, 100);
                        secondNumber = random.Next(50, 100);
                        break;
                    case DifficultyMode.Medium:
                        firstNumber = random.Next(10, 50);
                        secondNumber = random.Next(10, 50);
                        break;
                    case DifficultyMode.Easy:
                        firstNumber = random.Next(1, 10);
                        secondNumber = random.Next(1, 10);
                        break;
                }

                Console.WriteLine($"{firstNumber} + {secondNumber}");

                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);


                if (int.Parse(result) == firstNumber + secondNumber)
                {
                    Console.WriteLine("Your answer was correct. Press enter to continue");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Press enter to continue");
                    Console.ReadLine();
                }
                if (i == (NumberOfGames - 1) && !randomGame)
                {
                    TimeSpan gameDuration = Helpers.GetGameDuration(startDate);
                    Helpers.AddToHistory(score, difficulty, GameType.Addition, gameDuration);
                    Console.WriteLine($"Gamer over. Your final score is {score}. Press enter to continue");
                    Console.ReadLine();
                }
            }
            return score;
        }

        internal int SubtractionGame(int NumberOfGames, DifficultyMode difficulty, bool randomGame = false)
        {
            DateTime startDate = DateTime.UtcNow;
            Random random = new Random();
            int score = 0;
            int firstNumber = new();
            int secondNumber = new();

            for (int i = 0; i < NumberOfGames; i++)
            {
                Console.Clear();

                switch (difficulty)
                {
                    case DifficultyMode.Hard:
                        firstNumber = random.Next(50, 100);
                        secondNumber = random.Next(50, 100);
                        break;
                    case DifficultyMode.Medium:
                        firstNumber = random.Next(10, 50);
                        secondNumber = random.Next(10, 50);
                        break;
                    case DifficultyMode.Easy:
                        firstNumber = random.Next(1, 10);
                        secondNumber = random.Next(1, 10);
                        break;
                }

                Console.WriteLine($"{firstNumber} - {secondNumber}");

                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber - secondNumber)
                {
                    Console.WriteLine("Your answer was correct. Press enter to continue");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Press enter to continue");
                    Console.ReadLine();
                }
                if (i == (NumberOfGames - 1) && !randomGame)
                {
                    TimeSpan GameDuration = Helpers.GetGameDuration(startDate);
                    Helpers.AddToHistory(score, difficulty, GameType.Subtraction, GameDuration);
                    Console.WriteLine($"Gamer over. Your final score is {score}. Press enter to continue");
                    Console.ReadLine();
                }
            }
            return score;
        }

        internal int DivisionGame(int NumberOfGames, DifficultyMode difficulty, bool randomGame = false)
        {
            DateTime startDate = DateTime.UtcNow;
            Random random = new Random();
            int score = 0;
            for (int i = 0; i < NumberOfGames; i++)
            {
                Console.Clear();

                var divisionNumbers = Helpers.GetDivisionNumbers(difficulty);
                int firstNumber = divisionNumbers[0];
                int secondNumber = divisionNumbers[1];

                Console.WriteLine($"{firstNumber} / {secondNumber}");

                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber / secondNumber)
                {
                    Console.WriteLine("Your answer was correct. Press enter to continue");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Press enter to continue");
                    Console.ReadLine();
                }
                if (i == (NumberOfGames - 1) && !randomGame)
                {
                    TimeSpan GameDuration = Helpers.GetGameDuration(startDate);
                    Helpers.AddToHistory(score, difficulty, GameType.Division, GameDuration);
                    Console.WriteLine($"Gamer over. Your final score is {score}. Press enter to continue");
                    Console.ReadLine();
                }
            }
            return score;
        }

        internal int MultiplicationGame(int NumberOfGames, DifficultyMode difficulty, bool randomGame = false)
        {
            DateTime startDate = DateTime.UtcNow;
            Random random = new Random();
            int score = 0;
            int firstNumber = new();
            int secondNumber = new();

            for (int i = 0; i < NumberOfGames; i++)
            {
                Console.Clear();

                switch (difficulty)
                {
                    case DifficultyMode.Hard:
                        firstNumber = random.Next(25, 50);
                        secondNumber = random.Next(25, 50);
                        break;
                    case DifficultyMode.Medium:
                        firstNumber = random.Next(10, 25);
                        secondNumber = random.Next(10, 25);
                        break;
                    case DifficultyMode.Easy:
                        firstNumber = random.Next(1, 10);
                        secondNumber = random.Next(1, 10);
                        break;
                }

                Console.WriteLine($"{firstNumber} * {secondNumber}");

                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber * secondNumber)
                {
                    Console.WriteLine("Your answer was correct. Press enter to continue");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Press enter to continue");
                    Console.ReadLine();
                }
                if (i == (NumberOfGames - 1) && !randomGame)
                {
                    TimeSpan GameDuration = Helpers.GetGameDuration(startDate);
                    Helpers.AddToHistory(score, difficulty, GameType.Multiplication, GameDuration);
                    Console.WriteLine($"Gamer over. Your final score is {score}. Press enter to continue");
                    Console.ReadLine();
                }
            }
            return score;
        }

        internal void RandomGame(int NumberOfGames, DifficultyMode difficulty)
        {
            DateTime startDate = DateTime.UtcNow;
            int score = 0;
            Random random = new();

            for (int i = 0; i < NumberOfGames; i++)
            {
                Console.Clear();
                int randomGame = random.Next(0, 4);

                switch (randomGame)
                {
                    case 0:
                        score += AdditionGame(1, difficulty, randomGame: true);
                        break;
                    case 1:
                        score += SubtractionGame(1, difficulty, randomGame: true);
                        break;
                    case 2:
                        score += DivisionGame(1, difficulty, randomGame: true);
                        break;
                    case 3:
                        score += MultiplicationGame(1, difficulty, randomGame: true);
                        break;
                }
                if (i == (NumberOfGames - 1))
                {
                    TimeSpan GameDuration = Helpers.GetGameDuration(startDate);
                    Helpers.AddToHistory(score, difficulty, GameType.Random, GameDuration);
                    Console.WriteLine($"Gamer over. Your final score is {score}. Press enter to continue");
                    Console.ReadLine();
                }
            }
        }
    }
}
