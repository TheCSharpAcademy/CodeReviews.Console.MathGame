using Spectre.Console;
using System.Diagnostics;

namespace MathGame.Louis_dub.Calculation;

internal class DivisionCalculation : IBaseCalculation
{
    public static int Div(int mode)
    {
        Random rnd = new();

        int divisor = rnd.Next(1, mode);
        int result = rnd.Next(0, mode + 1);
        int dividend = divisor * result;

        var resultAsk = AnsiConsole.Ask<int>($"{dividend} / {divisor} = ");

        if (result == resultAsk)
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
            score += Div(mode);
        stopwatch.Stop();
        string strScore = $"{score} / 5";

        var newOperation = new Operation(DataBase.Operations.Count + 1, "Division", modeDB, strScore, stopwatch.Elapsed.TotalSeconds);
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