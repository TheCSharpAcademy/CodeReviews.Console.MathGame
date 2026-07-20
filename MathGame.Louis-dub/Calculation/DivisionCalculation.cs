using System.Reflection.Metadata;
using Spectre.Console;

namespace MathGame.Louis_dub.Calculation;

internal class DivisionCalculation : IBaseCalculation
{
    private static int Div(int mode)
    {
        int score = 0;
        Random rnd = new();

        for (int i = 0; i < 5; i++)
        {
            int divisor = rnd.Next(1, mode);
            int result = rnd.Next(0, mode + 1);
            int dividend = divisor * result;

            var resultAsk = AnsiConsole.Ask<int>($"{dividend} / {divisor} = ");

            if (result == resultAsk)
            {
                AnsiConsole.MarkupLine("[green]True[/]");
                score++;
            }
            else
            {
                AnsiConsole.MarkupLine("[red]False[/]");
            }
        }
        AnsiConsole.Markup($"Your score : [bold]{score} / 5[/]\n");
        return score;
    }

    public int EasyMode()
    {
        return Div(10);
    }

    public int MediumMode()
    {
        return Div(100);
    }

    public int HardMode()
    {
        return Div(1000);
    }
}