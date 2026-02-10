using Spectre.Console;

namespace CodeReviews.Console.MathGame.Controllers;

internal static class PrintController
{
    internal static void Welcome()
    {
        AnsiConsole.Clear();
        AnsiConsole.MarkupLine("[blue]***********************************************[/]");
        AnsiConsole.MarkupLine("[blue]***      Welcome to the Tiny Math Game      ***[/]");
        AnsiConsole.MarkupLine("[blue]***********************************************[/]");
        AnsiConsole.WriteLine("\nWhat would you like to do?");
        AnsiConsole.MarkupLine("\n[green]p: play game[/]");
        AnsiConsole.MarkupLine("[red]x: exit game[/]");
        AnsiConsole.MarkupLine("[yellow]h: view history[/]");
        AnsiConsole.Write("\nPlease make a choice: ");
    }

    internal static void PresentRules(int winningScore, int losingScore)
    {
        AnsiConsole.Clear();
        AnsiConsole.MarkupLine("[yellow]**************************************[/]");
        AnsiConsole.MarkupLine("[yellow]***      Tiny Math Game Rules      ***[/]");
        AnsiConsole.MarkupLine("[yellow]**************************************[/]");
        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine(" - Answer [green]correctly[/] and earn 1 point.");
        AnsiConsole.MarkupLine(" - Answer [red]incorrectly[/] and lose 1 point.");
        AnsiConsole.MarkupLine($" - To win, reach {winningScore} points.");
        AnsiConsole.MarkupLine($" - You will lose if you reach {losingScore} points.");
        AnsiConsole.WriteLine();
        Pause();
    }

    internal static void Pause()
    {
        AnsiConsole.Markup("[blue]Press any key to continue.[/] ");
        System.Console.ReadKey();
    }

    internal static void PrintHistory(List<string> history)
    {
        if (history.Count < 1)
        {
            AnsiConsole.MarkupLine("You haven't played any games!");
            Pause();
            return;
        }

        AnsiConsole.Clear();
        AnsiConsole.MarkupLine("[yellow]******************************[/]");
        AnsiConsole.MarkupLine("[yellow]***      Play History      ***[/]");
        AnsiConsole.MarkupLine("[yellow]******************************[/]");

        var table = new Table();

        table.AddColumn("[blue]Game[/]");
        table.AddColumn("[blue]Result[/]");

        for (int i = 0; i < history.Count; i += 1)
        {
            table.AddRow($"{i + 1}", $"{history[i]}");
        }

        AnsiConsole.Write(table);
        Pause();
    }
}
