using MathGame.Kriz_J.Enums;

namespace MathGame.Kriz_J;

public record GameResult(int Score, TimeSpan? TimeNeeded = null)
{
    public DateTime Timestamp { get; } = DateTime.Now;

    public string? Game { get; set; }

    public Difficulty Difficulty { get; set; }

    public Mode Mode { get; set; }

    public int NumberOfQuestions { get; set; }

    public TimeSpan? TimeNeeded { get; set; }

    public double PercentageScore => 100.0 * Score / NumberOfQuestions;

    public void SaveGameSettings(Settings settings)
    {
        Game = settings.Game;
        Difficulty = settings.Difficulty;
        Mode = settings.Mode;
        NumberOfQuestions = settings.NumberOfQuestions;
    }

    //TODO: Fix column width/spacing
    public static void PrintGameResults(IEnumerable<GameResult> results)
    {
        Console.WriteLine($"{"\tGAME TYPE",-15}{"MODE",-15}{"DIFFICULTY",-15}{"SCORE",-15}{"TIME NEEDED",-15}");
        PrintResultRows(results);
    }

    private static void PrintResultRows(IEnumerable<GameResult> results)
    {
        var gameResults = results.ToList();

        if (gameResults.Count == 0)
        {
            Console.WriteLine("\tNo results yet . . .");
            return;
        }

        foreach (var result in gameResults)
        {
            PrintResultRow(result);
        }
    }

    //TODO: Fix column width/spacing
    private static void PrintResultRow(GameResult result)
    {
        var score = $"{result.Score}/{result.NumberOfQuestions} - {result.PercentageScore:F2} %";
        var timeNeeded = $@"{result.TimeNeeded:mm\:ss\.fff}";

        Console.Write("\t");
        Console.Write($"{result.Game,-15}");
        Console.Write($"{result.Mode,-15}");
        Console.Write($"{result.Difficulty,-15}");
        Console.Write($"{score,-15}");
        if (result.TimeNeeded is not null)
            Console.Write($"{timeNeeded,-15}");

        Console.WriteLine();
    }
}