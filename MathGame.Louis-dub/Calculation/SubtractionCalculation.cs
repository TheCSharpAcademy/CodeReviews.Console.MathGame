using Spectre.Console;

namespace MathGame.Louis_dub.Calculation;

internal class SubtractionCalculation : IBaseCalculation
{
    private static int Sub(int mode)
    {
        int score = 0;
        Random rnd = new();

        for (int i = 0; i < 5; i++)
        {
            int n1 = rnd.Next(1, mode);
            int n2 = rnd.Next(1, mode);

            var result = AnsiConsole.Ask<int>($"{n1} - {n2} = ");

            if (result == n1 - n2)
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
        return Sub(10);
    }

    public int MediumMode()
    {
        return Sub(100);
    }

    public int HardMode()
    {
        return Sub(1000);
    }
}