using MathGame;
using Spectre.Console;
using System.Diagnostics.Contracts;

internal class Program
{
    public static List<bool> games = new();
    public static void Main()
    {
        var menu = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("Welcome to the [bold]MathGame![/]").AddChoices(new[] { "New Game", "History" }));
        if (menu == "New Game")
        {
            NewGame();
        }
        else if (menu == "History")
        {
            History();
        }
    }

    public static void NewGame()
    {
        var operation = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("What operation [blue]you choose?[/]").AddChoices(new[] { "Addition", "Subtraction", "Multiplication", "Division", "Random" }));
        var difficulty = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("Choose a [red]difficulty level:[/]").AddChoices(new[] { "Easy", "Medium", "Hard" }));
        AnsiConsole.MarkupLine($"[lightgreen]Okay!![/] Let´s play a {operation} game.");
        AnsiConsole.MarkupLine($"You have to win five games to [lightgreen]win!![/]");
        Thread.Sleep(2000);
        AnsiConsole.Clear();
        GameEngine.Game(Enum.Parse<GameEngine.Operations>(operation), Enum.Parse<GameEngine.Difficulties>(difficulty));
    }

    public static void History()
    {
        var table = new Table();
        table.Title("History");
        table.AddColumn("Previous games");
        table.Border(TableBorder.Square);
        for (int i = 0; i < games.Count; i++)
        {
            if (games[i] == true) { table.AddRow(new Markup(i + 1 + " - [green] Victory[/]")); }
            else { table.AddRow(new Markup(i + 1 + " - [red] Defeat[/]")); }
        }
        AnsiConsole.Write(table);
        AnsiConsole.WriteLine("");
        var menu = AnsiConsole.Prompt(new SelectionPrompt<string>().AddChoices(new[] { "Menu", "New Game" }));
        AnsiConsole.Clear();

        if (menu == "Menu")
        {
            Main();
        }
        else
        { NewGame(); }
    }
}