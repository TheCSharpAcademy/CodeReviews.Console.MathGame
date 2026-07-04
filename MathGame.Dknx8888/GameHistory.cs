using System.Text.Json;
using static MathGame.Dknx8888.GameResultTemplate;

namespace MathGame.Dknx8888;

public class GameHistory
{
    private readonly JsonSerializerOptions _options = new() { WriteIndented = true };
    public void ShowHistory()
    {
        while (true)
        {
            Console.Clear();

        var filePath = GameHistoryJson.FilePath;
        if (!File.Exists(filePath)) 
        { 
            EmptyHistoryError();
            return;
        } 

        var json = File.ReadAllText(filePath);
        if (string.IsNullOrWhiteSpace(json))
        {
            EmptyHistoryError();
            return;
        }
        
        var gameResults = JsonSerializer.Deserialize<List<GameResult>>(json, _options) ?? [];
        if (gameResults.Count == 0)
        {
            EmptyHistoryError();
            return;
        }
        
        Console.WriteLine("Game History\n");
        Console.WriteLine("Please select a game via ID (1,2, etc.) to show more details");
        Console.WriteLine("Type q to go back\n");
        Console.WriteLine($"{"ID",-4} | {"Date and Time Started",-22} | {"Score",-7} | {"Mode",-15} | {"Duration (sec)",-10}");
        Console.WriteLine(new string('-', 76));
        
        // Show from latest (bad idea?)
        // gameResults.Reverse();
        for (var i = 0; i < gameResults.Count; i++)
        {
            var (gameMode, _, score, duration, _, startTime) = gameResults[i];

            Console.WriteLine($"{i + 1,-4} | {startTime,-22} | {score,-7} | {gameMode,-15} | {duration,-10:F2}");
        }

        int selectedId;
        bool isValidId;

        do
        {
            var input = Console.ReadLine()?.Trim();

            // while loop in GameSession.cs does not work here because of this q
            if (string.Equals(input, "q", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            isValidId = int.TryParse(input, out selectedId)
                        && selectedId >= 1
                        && selectedId <= gameResults.Count;

            if (!isValidId)
            {
                Console.WriteLine("Please enter a valid ID number, or q to go back");
            }
        } while (!isValidId);

        var selectedGameResult = gameResults[selectedId - 1];
        ShowDetails(selectedGameResult);
        }
    }

    private static void EmptyHistoryError()
    {
        Console.WriteLine("No game history found.");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private static void ShowDetails(GameResult selectedGameResult)
    {
        var (gameMode, difficulty, score, duration, questionResults, startTime) = selectedGameResult;
        
        Console.Clear();
        Console.WriteLine($"Start time: {startTime}");
        Console.WriteLine($"Game mode: {gameMode}");
        Console.WriteLine($"Difficulty: {difficulty}");
        Console.WriteLine($"Duration (sec): {duration:F2}");
        Console.WriteLine($"Score: {score}/5\n");

        // Way better idea to include id in the records
        var questionId = 1;
        // Mind the one spaces
        Console.WriteLine($"{"Q. Number", -10} {"Result", -8} {"Question", -12} {"Your Answer", 12} {"Correct Answer", 14}");
        Console.WriteLine(new string('-', 62));

        foreach (var questionResult in questionResults)
        {
            var (num1, num2, sign, playerAnswer, correctAnswer, isCorrect) = questionResult;
            var correctDisplay = isCorrect ? "Right" : "Wrong";
            var questionDisplay = $"{num1} {sign} {num2}";
            
            Console.WriteLine($"{questionId, -10} {correctDisplay, -8} {questionDisplay, -12} {playerAnswer, 12} {correctAnswer, 14}");
            ++questionId;
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}