using Spectre.Console;

namespace MathGame.Louis_dub.Calculation;

internal class MultiplicationCalculation : IBaseCalculation
{
    public static int Mul(int mode)
    {
        Random rnd = new();
        int n1 = rnd.Next(1, mode);
        int n2 = rnd.Next(1, mode);

        var result = AnsiConsole.Ask<int>($"{n1} * {n2} = ");

        if (result == n1 * n2)
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
            score += Mul(10);
        AnsiConsole.Markup($"Your score : [bold]{score} / 5[/]\n");
        return score;
    }

    public int MediumMode()
    {
        int score = 0;

        for (int i = 0; i < 5; i++)
            score += Mul(100);
        AnsiConsole.Markup($"Your score : [bold]{score} / 5[/]\n");
        return score;
    }

    public int HardMode()
    {
        int score = 0;

        for (int i = 0; i < 5; i++)
            score += Mul(1000);
        AnsiConsole.Markup($"Your score : [bold]{score} / 5[/]\n");
        return score;
    }
}