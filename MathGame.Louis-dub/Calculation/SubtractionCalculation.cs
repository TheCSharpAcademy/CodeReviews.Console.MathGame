using Spectre.Console;
using System.Diagnostics;

namespace MathGame.Louis_dub.Calculation;

internal class SubtractionCalculation : IBaseCalculation
{
    public static int Sub(int mode)
    {
        Random rnd = new();
        int n1 = rnd.Next(1, mode);
        int n2 = rnd.Next(1, mode);

        var result = AnsiConsole.Ask<int>($"{n1} - {n2} = ");

        if (result == n1 - n2)
        {
            AnsiConsole.MarkupLine("[green]True[/]");
            return 1;
        }
        else
        {
            AnsiConsole.MarkupLine("[red]False[/]");
            return 0;
        }
    }

    public static int Game(int mode, string modeDB)
    {
        Stopwatch stopwatch = new();
        int score = 0;

        stopwatch.Start();
        for (int i = 0; i < 5; i++)
            score += Sub(mode);
        stopwatch.Stop();
        string strScore = $"{score} / 5";

        var newOperation = new Operation(DataBase.Operations.Count + 1, "Subtraction", modeDB, strScore, stopwatch.Elapsed.TotalSeconds);
        DataBase.Operations.Add(newOperation);
        AnsiConsole.Markup($"Your score : [bold]{strScore}[/]\nTime : [bold]{stopwatch.Elapsed.TotalSeconds:F1}s[/]\n");
        return score;
    }

    public int EasyMode()
    {
        return Game(10, "Easy");
    }

    public int MediumMode()
    {
        return Game(100, "Medium");
    }

    public int HardMode()
    {
        return Game(1000, "Hard");
    }
}