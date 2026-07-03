using System.Diagnostics;

namespace MathGame.Dknx8888;

public class GameSession(GameMode gameMode, Difficulty difficulty)
{
    private readonly Random _random = new();

    public void Start()
    {
        Console.Clear();
        Console.WriteLine("Please answer the following questions: ");
        var count = 0;
        var score = 0;
        var questions = new HashSet<(int, int, GameMode)>();
        var timer = Stopwatch.StartNew();
        while (count < 5)
        {
            int num1;
            int num2;
            GameMode selectedGameMode;
            
            // Handle duplicate questions
            do
            {
                (num1, num2) = NumGen();

                selectedGameMode = gameMode == GameMode.Random ? GetRandomGameMode() : gameMode;
                
                // Division handling
                if (gameMode != GameMode.Division) continue;
                while (num1 % num2 != 0 && num2 != 0)
                {
                    (num1, num2) = NumGen();
                }
            } while (!questions.Add((num1, num2, selectedGameMode))); // True if new q, False if already had
            
            var sign = selectedGameMode switch
            {
                GameMode.Addition => '+',
                GameMode.Subtraction => '-',
                GameMode.Multiplication => '*',
                GameMode.Division => '/',
            };

            var correctResult = selectedGameMode switch
            {
                GameMode.Addition => num1 + num2,
                GameMode.Subtraction => num1 - num2,
                GameMode.Multiplication => num1 * num2,
                GameMode.Division => num1 / num2,
            };
            
            Console.WriteLine($"{num1} {sign} {num2} = ?");

            // Checking int would give the player a hint instead so nah
            double playerInput;
            while (!double.TryParse(Console.ReadLine()?.Trim(), out playerInput))
            {
                Console.WriteLine("Please enter a valid number");
            }

            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (playerInput == correctResult)
            {
                ++score;
                Console.WriteLine("Congratulations! You are correct!");
            }
            else
            {
                Console.WriteLine($"You are incorrect. The correct answer is {correctResult}");
            }
        
            count++;
        }
        timer.Stop();
        var roundTime = timer.Elapsed.TotalSeconds;
        Console.WriteLine($"Your final score is {score} out of 5!");
        Console.WriteLine($"You completed this game in {roundTime:F2} seconds.");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private (int, int) NumGen()
    {
        return difficulty switch
        {
            Difficulty.Easy => (_random.Next(0, 10), _random.Next(0, 10)),
            Difficulty.Medium => (_random.Next(10, 101), _random.Next(0, 10)),
            Difficulty.Hard => (_random.Next(10, 101), _random.Next(10, 101)),
            _ => throw new InvalidOperationException("Somehow an invalid difficulty is selected. Fix your bug.")
        };
    }

    private GameMode GetRandomGameMode()
    {
        GameMode[] gameModes =
        [
            GameMode.Addition,
            GameMode.Subtraction,
            GameMode.Multiplication,
            GameMode.Division
        ];
        return gameModes[_random.Next(gameModes.Length)];
    }
}