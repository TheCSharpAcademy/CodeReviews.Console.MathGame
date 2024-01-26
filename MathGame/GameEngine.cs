using MathGame.Models;
using System.Diagnostics;

namespace MathGame;

internal class GameEngine
{
    internal void AdditionGame(string message, string difficulty, int tries)
    {
        int number1, number2;
        int score = 0;

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        for (int i = 0; i < tries; i++)
        {
            Console.Clear();
            Console.WriteLine(message);
            number1 = Helpers.SetDifficulty(difficulty);
            number2 = Helpers.SetDifficulty(difficulty);

            Console.WriteLine($"{number1} + {number2}");
            var result = Console.ReadLine();
            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == (number1 + number2))
            {
                Console.WriteLine("Your answer was correct. Type any key to get the next question");
                score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"Your answer was wrong. Type any key to get the next question");
                Console.ReadLine();

            }

            if (i == (tries - 1))
            {
                stopwatch.Stop();
                TimeSpan timeSpan = stopwatch.Elapsed;
                Console.WriteLine($"Game over. Your final score was {score}/{tries}. You took {Convert.ToInt32(timeSpan.TotalSeconds)}s to complete the game. Press any key to go back to the menu");
                Console.ReadLine();
            }
        }

        Helpers.AddToHistory(score, GameType.Addition, Helpers.GetDifficultyLevel(difficulty), tries);
    }

    internal void SubtractionGame(string message, string difficulty, int tries)
    {
        int number1, number2;
        int score = 0;

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        for (int i = 0; i < tries; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            number1 = Helpers.SetDifficulty(difficulty);
            number2 = Helpers.SetDifficulty(difficulty);

            Console.WriteLine($"{number1} - {number2}");
            var result = Console.ReadLine();
            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == (number1 - number2))
            {
                Console.WriteLine("Your answer was correct. Type any key to get the next question");
                score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"Your answer was wrong. Type any key to get the next question");
                Console.ReadLine();
            }

            if (i == (tries - 1))
            {
                stopwatch.Stop();
                TimeSpan timeSpan = stopwatch.Elapsed;
                Console.WriteLine($"Game over. Your final score was {score}/{tries}. You took {Convert.ToInt32(timeSpan.TotalSeconds)}s to complete the game. Press any key to go back to the menu");
                Console.ReadLine();
            }
        }

        Helpers.AddToHistory(score, GameType.Subtraction, Helpers.GetDifficultyLevel(difficulty), tries);
    }

    internal void MultiplicationGame(string message, string difficulty, int tries)
    {
        int number1, number2;
        int score = 0;

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        for (int i = 0; i < tries; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            number1 = Helpers.SetDifficulty(difficulty);
            number2 = Helpers.SetDifficulty(difficulty);

            Console.WriteLine($"{number1} * {number2}");
            var result = Console.ReadLine();
            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == (number1 * number2))
            {
                Console.WriteLine("Your answer was correct. Type any key to get the next question");
                score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"Your answer was wrong. Type any key to get the next question");
                Console.ReadLine();
            }

            if (i == (tries - 1))
            {
                stopwatch.Stop();
                TimeSpan timeSpan = stopwatch.Elapsed;
                Console.WriteLine($"Game over. Your final score was {score}/{tries}. You took {Convert.ToInt32(timeSpan.TotalSeconds)}s to complete the game. Press any key to go back to the menu");
                Console.ReadLine();
            }
        }

        Helpers.AddToHistory(score, GameType.Multiplication, Helpers.GetDifficultyLevel(difficulty), tries);
    }

    internal void DivisionGame(string message, string difficulty, int tries)
    {
        int score = 0;
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        for (int i = 0; i < tries; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            int[] numbers = Helpers.GetDivisionNumbers(difficulty);
            Console.WriteLine($"{numbers[0]} / {numbers[1]}");
            var result = Console.ReadLine();
            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == (numbers[0] / numbers[1]))
            {
                Console.WriteLine("Your answer was correct. Type any key to get the next question");
                score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"Your answer was wrong. Type any key to get the next question");
                Console.ReadLine();
            }

            if (i == (tries - 1))
            {
                stopwatch.Stop();
                TimeSpan timeSpan = stopwatch.Elapsed;
                Console.WriteLine($"Game over. Your final score was {score}/{tries}. You took {Convert.ToInt32(timeSpan.TotalSeconds)}s to complete the game. Press any key to go back to the menu");
                Console.ReadLine();
            }
        }

        Helpers.AddToHistory(score, GameType.Division, Helpers.GetDifficultyLevel(difficulty), tries);
    }

    internal void RandomGame()
    {
        Random random = new Random();
        int ran = random.Next(1, 5);
        string? diff;
        int times;

        switch (ran)
        {
            case 1:
                diff = Menu.DifficultyMenu();
                times = Menu.AmountOfGames();
                AdditionGame("Addition Game", diff, times);
                break;
            case 2:
                diff = Menu.DifficultyMenu();
                times = Menu.AmountOfGames();
                SubtractionGame("Subtraction Game", diff, times);
                break; 
            case 3:
                diff = Menu.DifficultyMenu();
                times = Menu.AmountOfGames();
                MultiplicationGame("Multiplication Games", diff, times);
                break;
            case 4:
                diff = Menu.DifficultyMenu();
                times = Menu.AmountOfGames();
                DivisionGame("Division Game", diff, times);
                break;
            default:
                break;
        }
    }
}
