using Spectre.Console;
using MathGame.Models;
namespace MathGame.Games;

internal static class History
{
    public static void ShowHistory(List<GameResult> gameHistory)
    {
        AnsiConsole.Clear();
        if ( gameHistory.Count > 0) // Check if there are any game results in the history
        {
            var table = new Table();
            table.AddColumn("Played");
            table.AddColumn("Operation");
            table.AddColumn("Score");
            table.AddColumn("Progress");

            AnsiConsole.MarkupLine("[green]Game History:[/]");
            foreach (var entry in gameHistory)
            {
                string filled = new string ('█', entry.Score); // make a string of filled blocks based on the score, so if the score is 3, it will be "███"
                string empty = new string('░', entry.QuestionCount - entry.Score); // make a string of empty blocks based on the remaining questions
                table.AddRow(
                    $"[blue]{entry.PlayedAt:dd/MM/yyyy HH:mm}[/]",
                    $"[yellow]{entry.Operation}[/]",
                    $"[green]{entry.Score}/{entry.QuestionCount}[/]",
                    $"[green]{filled}[/][grey]{empty}[/]"
                );

            }
            AnsiConsole.Write(table);

        }
        else
        {
            AnsiConsole.MarkupLine("[red]No game history available.[/]");
            
            
        }
    }

}
