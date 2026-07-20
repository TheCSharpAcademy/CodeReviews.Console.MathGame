using Spectre.Console;
using MathGame.Louis_dub;

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
        string strScore = $"{score} / 5";

        var newOperation = new Operation(DataBase.Operations.Count + 1, "Division", "Easy", strScore);
        DataBase.Operations.Add(newOperation);
        AnsiConsole.Markup($"Your score : [bold]{strScore}[/]\n");
        return score;
    }

    public int MediumMode()
    {
        int score = 0;

        for (int i = 0; i < 5; i++)
            score += Div(100);
        string strScore = $"{score} / 5";

        var newOperation = new Operation(DataBase.Operations.Count + 1, "Division", "Medium", strScore);
        DataBase.Operations.Add(newOperation);
        AnsiConsole.Markup($"Your score : [bold]{strScore}[/]\n");
        return score;
    }

    public int HardMode()
    {
        int score = 0;

        for (int i = 0; i < 5; i++)
            score += Div(1000);
        string strScore = $"{score} / 5";

        var newOperation = new Operation(DataBase.Operations.Count + 1, "Division", "Hard", strScore);
        DataBase.Operations.Add(newOperation);
        AnsiConsole.Markup($"Your score : [bold]{strScore}[/]\n");
        return score;
    }
}