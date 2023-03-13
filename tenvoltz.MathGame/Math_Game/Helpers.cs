using Math_Game.Model;
using Math_Game.Model.Problems;

namespace Math_Game;
internal class Helpers
{
    internal static List<HistoryModel> history = new List<HistoryModel>();
    internal static void AddToHistory(ProblemType problemType, int score, TimeSpan averageDuration)
    {
        history.Add(new HistoryModel
        {
            Date = DateTime.Now,
            Score = score,
            Type = problemType,
            AverageDuration = averageDuration
        });
    }
    internal static void PrintHistory()
    {
        Console.Clear();
        Console.WriteLine("Games History - High Score");
        Helpers.PrintDivider();

        var gamesToPrint = history.OrderByDescending(x => x.Score).Take(10);
        foreach (var game in gamesToPrint)
        {
            Console.WriteLine(game.ToString());
        }
        Helpers.PrintDivider();
        Helpers.PrintContinue();
    }

    internal static string GetName()
    {
        Console.WriteLine("Please type your name");
        var name = Console.ReadLine();

        while (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Name can't be empty");
            name = Console.ReadLine();
        }

        return name;
    }

    internal static void PrintDivider()
    {
        Console.WriteLine("---------------------------");
    }
    internal static void PrintContinue()
    {
        Console.WriteLine("Press enter to continue");
        Console.ReadLine();
    }

}