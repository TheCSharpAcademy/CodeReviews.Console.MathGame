using Spectre.Console;
using System.Diagnostics;

namespace MathGame.Louis_dub.Calculation;

internal class RandomCalculation : IBaseCalculation
{
    public static int RandomOperation(int mode)
    {
        int score = 0;
        Func<int, int>[] operations = {
            AdditionCalculation.Sum, SubtractionCalculation.Sub, MultiplicationCalculation.Mul, DivisionCalculation.Div
        };
        Random op = new();

        for (int i = 0; i < 5; i++)
            score += operations[op.Next(0, 4)](mode);
        return score;
    }
    public int EasyMode()
    {
        Stopwatch stopwatch = new();
        stopwatch.Start();
        int score = RandomOperation(10);
        stopwatch.Stop();
        string strScore = $"{score} / 5";

        var newOperation = new Operation(DataBase.Operations.Count + 1, "Random", "Easy", strScore, stopwatch.Elapsed.TotalSeconds);
        DataBase.Operations.Add(newOperation);
        AnsiConsole.Markup($"Your score : [bold]{strScore}[/]\nTime : [bold]{stopwatch.Elapsed.TotalSeconds:F1}s[/]");
        return score;
    }

    public int MediumMode()
    {
        Stopwatch stopwatch = new();
        stopwatch.Start();
        int score = RandomOperation(100);
        stopwatch.Stop();
        string strScore = $"{score} / 5";

        var newOperation = new Operation(DataBase.Operations.Count + 1, "Random", "Medium", strScore, stopwatch.Elapsed.TotalSeconds);
        DataBase.Operations.Add(newOperation);
        AnsiConsole.Markup($"Your score : [bold]{strScore}[/]\nTime : [bold]{stopwatch.Elapsed.TotalSeconds:F1}s[/]\n");
        return score;
    }

    public int HardMode()
    {
        Stopwatch stopwatch = new();
        stopwatch.Start();
        int score = RandomOperation(1000);
        stopwatch.Stop();
        string strScore = $"{score} / 5";

        var newOperation = new Operation(DataBase.Operations.Count + 1, "Random", "Hard", strScore, stopwatch.Elapsed.TotalSeconds);
        DataBase.Operations.Add(newOperation);
        AnsiConsole.Markup($"Your score : [bold]{strScore}[/]\nTime : [bold]{stopwatch.Elapsed.TotalSeconds:F1}s[/]\n");
        return score;
    }
}