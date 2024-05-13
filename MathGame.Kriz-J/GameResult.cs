namespace MathGame.Kriz_J;

public record GameResult(int Score)
{
    public DateTime Timestamp { get; } = DateTime.Now;

    public string? Game { get; set; }

    public Mode Mode { get; set; }

    public Difficulty Difficulty { get; set; }

    public int NumberOfQuestions { get; set; }

    public TimeSpan? TimeNeeded { get; set; }

    public double PercentageScore => 100.0 * Score / NumberOfQuestions;

    public static void PrintGameResults(string title, IEnumerable<GameResult> results)
    {
        ConsoleHelperMethods.PrintTitle(title);

        //TODO: Fix column width/spacing
        Console.WriteLine($"{"\tGAME TYPE",-15}{"MODE",-15}{"DIFFICULTY",-15}{"SCORE",-15}{"TIME NEEDED",-15}");

        PrintResultRows(results);

        ConsoleHelperMethods.PrintMessage(". . . Press any key to go back.");
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

    private static void PrintResultRow(GameResult result)
    {
        //TODO: Fix column width/spacing
        Console.Write($"\t{result.Game,-15}");
        Console.Write($"{result.Mode,-15}");
        Console.Write($"{result.Difficulty,-15}");
        Console.Write($"{$"{result.Score}/{result.NumberOfQuestions} - {result.PercentageScore} %",-15}");

        if (result.TimeNeeded is not null)
            Console.Write($"{$@"{result.TimeNeeded:mm\:ss\.fff}",-15}");

        Console.WriteLine();
    }
}