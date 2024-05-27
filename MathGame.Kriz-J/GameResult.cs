using MathGame.Kriz_J.Enums;

namespace MathGame.Kriz_J;

public record GameResult(int Score, TimeSpan? TimeNeeded = null)
{
    public DateTime Timestamp { get; } = DateTime.Now;

    public GameType GameType { get; set; }

    public Difficulty Difficulty { get; set; }

    public Mode Mode { get; set; }

    public int NumberOfQuestions { get; set; }

    public double PercentageScore => 100.0 * Score / NumberOfQuestions;

    public void SaveGameSettings(Settings settings)
    {
        GameType = settings.GameType;
        Difficulty = settings.Difficulty;
        Mode = settings.Mode;
        NumberOfQuestions = settings.NumberOfQuestions;
    }

    //TODO: Fix column width/spacing
    public static void PrintResultRowHeaders()
    {
        Console.WriteLine($"{"\tGAME TYPE",-15}{"MODE",-15}{"DIFFICULTY",-15}{"SCORE",-15}{"TIME NEEDED",-15}");
    }

    //TODO: Fix column width/spacing
    public static void PrintResultRow(GameResult result)
    {
        var score = $"{result.Score}/{result.NumberOfQuestions} - {result.PercentageScore:F2} %";
        var timeNeeded = $@"{result.TimeNeeded:mm\:ss\.fff}";

        Console.Write("\t");
        Console.Write($"{Enum.GetName(result.GameType),-15}");
        Console.Write($"{result.Mode,-15}");
        Console.Write($"{result.Difficulty,-15}");
        Console.Write($"{score,-15}");
        if (result.TimeNeeded is not null)
            Console.Write($"{timeNeeded,-15}");

        Console.WriteLine();
    }
}