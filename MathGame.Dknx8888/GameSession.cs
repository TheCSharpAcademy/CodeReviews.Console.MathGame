using System.Diagnostics;
using System.Text.Json;
using static MathGame.Dknx8888.GameResultTemplate;

namespace MathGame.Dknx8888;

public class GameSession(GameMode gameMode, Difficulty difficulty)
{
    private readonly Random _random = new();
    private readonly JsonSerializerOptions _options = new JsonSerializerOptions { WriteIndented = true };
    
    public void Start()
    {
        var count = 0;
        var score = 0;
        HashSet<(int, int, GameMode)> questions = [];
        var timer = Stopwatch.StartNew();
        List<QuestionResult> questionResults = [];
        List<GameResult> gameResults;
        var startingDateTime = DateTime.Now;
        
        Console.Clear();
        Console.WriteLine("Please answer the following questions: ");
        
        //May implement quitting in the middle of the game later
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
                if (selectedGameMode != GameMode.Division) continue;
                while (num2 == 0 || num1 % num2 != 0)
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
                _ => throw new InvalidOperationException("Invalid game mode selected.")
            };

            var correctResult = selectedGameMode switch
            {
                GameMode.Addition => num1 + num2,
                GameMode.Subtraction => num1 - num2,
                GameMode.Multiplication => num1 * num2,
                GameMode.Division => num1 / num2,
                _ => throw new InvalidOperationException("Invalid game mode selected.")
            };
            
            Console.WriteLine($"{num1} {sign} {num2} = ?");

            // Checking int would give the player a hint instead so nah
            double playerInput;
            // Put ReadLine in while to avoid infinite loops 
            while (!double.TryParse(Console.ReadLine()?.Trim(), out playerInput))
            {
                Console.WriteLine("Please enter a valid number");
            }

            // ReSharper disable once CompareOfFloatsByEqualityOperator
            var isCorrect = playerInput == correctResult;
            if (isCorrect)
            {
                ++score;
                Console.WriteLine("Congratulations! You are correct!");
            }
            else
            {
                Console.WriteLine($"You are incorrect. The correct answer is {correctResult}");
            }
            
            // Add record
            questionResults.Add(new QuestionResult (
                num1,
                num2,
                sign,
                playerInput,
                correctResult,
                isCorrect
            ));
        
            count++;
        }
        timer.Stop();
        var duration = timer.Elapsed.TotalSeconds;
        Console.WriteLine($"Your final score is {score} out of 5!");
        Console.WriteLine($"You completed this game in {duration:F2} seconds.");
        
        // Save
        var gameResult = new GameResult(
            gameMode,
            difficulty,
            score,
            duration,
            questionResults,
            startingDateTime
        );

        var filePath = GameHistoryJson.FilePath;
        if (File.Exists(filePath))
        {
            var existingJson = File.ReadAllText(filePath);
            gameResults = JsonSerializer.Deserialize<List<GameResult>>(existingJson, _options) ?? [];
        }
        else
        {
            gameResults = [];
        }

        gameResults.Add(gameResult);
        var json = JsonSerializer.Serialize(gameResults, _options);
        File.WriteAllText(filePath, json);
        Console.WriteLine($"Game history saved to: {filePath}");
        
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
