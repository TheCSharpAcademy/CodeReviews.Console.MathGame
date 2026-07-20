using System.Reflection.Metadata;
using Spectre.Console;

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

    public int EasyMode()
    {
        int score = 0;

        for (int i = 0; i < 5; i++)
            score += Div(10);
        AnsiConsole.Markup($"Your score : [bold]{score} / 5[/]\n");
        return score;
    }

    public int MediumMode()
    {
        int score = 0;

        for (int i = 0; i < 5; i++)
            score += Div(100);
        AnsiConsole.Markup($"Your score : [bold]{score} / 5[/]\n");
        return score;
    }

    public int HardMode()
    {
        int score = 0;

        for (int i = 0; i < 5; i++)
            score += Div(1000);
        AnsiConsole.Markup($"Your score : [bold]{score} / 5[/]\n");
        return score;
    }
}