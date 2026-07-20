using Spectre.Console;

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

    public int EasyMode()
    {
        int score = 0;

        for (int i = 0; i < 5; i++)
            score += Sub(10);
        string strScore = $"{score} / 5";

        var newOperation = new Operation(DataBase.Operations.Count + 1, "Subtraction", "Easy", strScore);
        DataBase.Operations.Add(newOperation);
        AnsiConsole.Markup($"Your score : [bold]{strScore}[/]\n");
        return score;
    }

    public int MediumMode()
    {
        int score = 0;

        for (int i = 0; i < 5; i++)
            score += Sub(100);
        string strScore = $"{score} / 5";

        var newOperation = new Operation(DataBase.Operations.Count + 1, "Subtraction", "Medium", strScore);
        DataBase.Operations.Add(newOperation);
        AnsiConsole.Markup($"Your score : [bold]{strScore}[/]\n");
        return score;
    }

    public int HardMode()
    {
        int score = 0;

        for (int i = 0; i < 5; i++)
            score += Sub(1000);
        string strScore = $"{score} / 5";

        var newOperation = new Operation(DataBase.Operations.Count + 1, "Subtraction", "Hard", strScore);
        DataBase.Operations.Add(newOperation);
        AnsiConsole.Markup($"Your score : [bold]{strScore}[/]\n");
        return score;
    }
}