using System.Runtime.CompilerServices;
using System.Text.Json;

namespace MathGame.Dknx8888;

public class GameHistory
{
    private readonly JsonSerializerOptions _options = new() { WriteIndented = true };
    public void ShowHistory()
    {
        Console.Clear();

        var filePath = GameHistoryJson.FilePath;

        if (!File.Exists(filePath))
        {
            Console.WriteLine("No game history found.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return;
        }

        var json = File.ReadAllText(filePath);
        var gameResults = JsonSerializer.Deserialize<List<GameResultTemplate.GameResult>>(json, _options) ?? [];

        if (gameResults.Count == 0)
        {
            Console.WriteLine("No game history found.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return;
        }
        
        Console.WriteLine("Game History");
        Console.WriteLine("Please select a game to show more details: ");
        Console.WriteLine("ID | ");
        
        gameResults.Reverse(); // SHow from latest
        for (var i = 0; i < gameResults.Count; i++)
        {
            var selectedGameResult = gameResults[i];
            Console.WriteLine($"{i + 1}. ");
        }
    
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}