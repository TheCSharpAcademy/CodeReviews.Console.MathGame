namespace MathGame.Kriz_J;

public class ResultKeeper : List<GameResult>
{
    public void PrintLatestGames()
    {
        PrintResults(this.OrderByDescending(s => s.Timestamp));
    }

    public void PrintHighScore()
    {
        PrintResults(this.OrderByDescending(s => s.PercentageScore));
    }

    private static void PrintResults(IEnumerable<GameResult> results)
    {
        GameResult.PrintResultRowHeaders();
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
            GameResult.PrintResultRow(result);
        }
    }
}