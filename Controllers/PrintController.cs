using Spectre.Console;

namespace mathGame.qua9k.Controllers;

internal static class PrintController
{
    internal static void Welcome()
    {
        AnsiConsole.Clear();

        AnsiConsole.MarkupLine(
            """
            [blue]***********************************************[/]
            [blue]***      Welcome to the Tiny Math Game      ***[/]
            [blue]***********************************************[/]

            What would you like to do?

            [green]p: play game[/]
            [red]x: exit game[/]
            [yellow]h: view history[/]

            """
        );
        AnsiConsole.Write("Please make a choice: ");
    }

    internal static void PresentRules(int winningScore, int losingScore)
    {
        AnsiConsole.Clear();
        AnsiConsole.MarkupLine(
            $"""
            [yellow]********************************************[/]
            [yellow]*****       Tiny Math Game Rules       *****[/]
            [yellow]********************************************[/]

            - Answer [green]correctly[/] and earn 1 point.
            - Answer [red]incorrectly[/] and lose 1 point.
            - To win, reach {winningScore} points.
            - You will lose if you reach {losingScore} points.

            """
        );
        Pause();
    }

    internal static void Pause()
    {
        AnsiConsole.Markup("[blue]Press any key to continue.[/] ");
        Console.ReadKey();
    }

    internal static void PrintHistory(List<(string Result, string PlayTime)> history)
    {
        if (history.Count < 1)
        {
            AnsiConsole.MarkupLine("You haven't played any games!");
            Pause();
            return;
        }

        AnsiConsole.Clear();
        AnsiConsole.MarkupLine(
            """
            [yellow]*********************************************[/]
            [yellow]**********      Play History      ***********[/]
            [yellow]*********************************************[/]

            """
        );

        var table = new Table();

        table.AddColumn("[blue]Game[/]");
        table.AddColumn("[blue]Result[/]");
        table.AddColumn("[blue]Play Time[/]");

        for (int i = 0; i < history.Count; i += 1)
        {
            table.AddRow($"{i + 1}", $"{history[i].Result}", $"{history[i].PlayTime}");
        }

        AnsiConsole.Write(table);
        AnsiConsole.Write("");
        Pause();
    }
}
