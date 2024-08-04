using Math_Game.Models;
using System.Timers;

namespace Math_Game;

internal class Helpers
{
    private static int timer = 0;
    private static System.Timers.Timer _timer;

    static List<Game> gameHistory = new();
    internal static string Mode()
    {
        Console.WriteLine("Choose Game Mode :");
        Console.WriteLine("Easy - Medium - Hard");
        string? gameMode = Console.ReadLine();
        
        switch (gameMode.ToLower())
        {
            case "easy":
                return "Easy";
            case "medium":
                return "Medium";
            case "hard":
                return "Hard";
            default:
                Console.Clear();
                Console.WriteLine("Invalid Mode, Please try again:\n");
                return Mode();
        }
    }

    internal static void AddToHistory(int score, int numberOfQuestions, GameType gameType, string gameMode, int time)
    {
        gameHistory.Add(new Game
        {
            DateTime = DateTime.UtcNow.AddHours(3),
            Score = score,
            Time = time,
            NumberOfQuestions = numberOfQuestions,
            Type = gameType,
            GameMode = gameMode
        });
    }

    internal static void ShowHistory()
    {
        Console.Clear();
        Console.WriteLine("History: ");
        foreach (var history in gameHistory)
        {
            Console.WriteLine($"{history.DateTime} - {history.GameMode} - {history.Type} - {history.Score}/{history.NumberOfQuestions} in {history.Time} Sec");
        }
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("Press any key to return to main menu");
        Console.ReadLine();
    }

    internal static string ValidateResult(string result)
    {
        while (!int.TryParse(result, out _) || String.IsNullOrEmpty(result))
        {
            Console.WriteLine("You Must Enter a number, Try agein");
            result = Console.ReadLine().Trim();
        }
        return result;
    }

    internal static string GetName()
    {
        string name = Console.ReadLine().Trim();

        while (string.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Please Enter a valid Name");
            name = Console.ReadLine();
        }
        Console.Clear();
        return name;
    }




    public static void StartTimer()
    {
        _timer = new System.Timers.Timer(1000);
        _timer.Elapsed += (sender, e) =>
        {
            int currentValue = Time();
        };
        _timer.Enabled = true;
    }

    public static void StopTimer()
    {
        _timer.Stop();
        _timer.Dispose();
    }

    public static int Time()
    {
        timer++;
        return timer;
    }
}
