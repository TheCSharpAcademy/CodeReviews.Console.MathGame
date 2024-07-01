using MathGame.Kriz_J.Enums;

namespace MathGame.Kriz_J;

public record GameResult(int Score, TimeSpan? TimeNeeded = null)
{
    private const int ColumnWidth = 20;

    public DateTime Timestamp { get; } = DateTime.Now;

    public GameType GameType { get; set; }

    public Difficulty Difficulty { get; set; }

    public Mode Mode { get; set; }

    public int NumberOfQuestions { get; set; }

    public double PercentageScore => 100.0 * Score / NumberOfQuestions;

    public static void PrintResultRowHeaders()
    {
        Console.Write("\t");

        foreach (var header in new List<string> { "GAME TYPE", "MODE", "DIFFICULTY", "SCORE", "TIME NEEDED" })
        {
            Console.Write(header.PadRight(ColumnWidth));
        }

        Console.WriteLine();
    }

    public static void PrintResultRow(GameResult result)
    {
        var score = $"{result.Score}/{result.NumberOfQuestions} - {result.PercentageScore:F2} %";
        var timeNeeded = $@"{result.TimeNeeded:mm\:ss\.fff}";

        Console.Write("\t");
        Console.Write(Enum.GetName(result.GameType)!.PadRight(ColumnWidth));
        Console.Write(result.Mode.ToString().PadRight(ColumnWidth));
        Console.Write(result.Difficulty.ToString().PadRight(ColumnWidth));
        Console.Write(score.PadRight(ColumnWidth));

        if (result.TimeNeeded.HasValue)
        {
            Console.Write(timeNeeded.PadRight(ColumnWidth));
        }

        Console.WriteLine();
    }
    
    public void SaveGameSettings(Settings settings)
    {
        GameType = settings.GameType;
        Difficulty = settings.Difficulty;
        Mode = settings.Mode;
        NumberOfQuestions = settings.NumberOfQuestions;
    }
}