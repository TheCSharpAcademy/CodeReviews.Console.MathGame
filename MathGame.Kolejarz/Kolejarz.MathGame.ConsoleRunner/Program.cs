using Kolejarz.MathGame.GameEngine;
using Spectre.Console;
using System.Diagnostics;

var game = new Game();

while (true)
{
    AnsiConsole.Clear();

    var choices = game.Guesses.Any() ?
        Enum.GetValues<Menu>() :
        Enum.GetValues<Menu>().Except(new[] { Menu.ShowScores });
    var action = AnsiConsole.Prompt(new SelectionPrompt<Menu>()
        .Title("What do you want [blue]to do[/]?")
        .AddChoices(choices));

    switch (action)
    {
        case Menu.StartGame:
            PlayGame(game);
            break;
        case Menu.ShowScores:
            PrintScores(game);
            break;
        case Menu.Exit:
            return;
    }    
}

void PlayGame(Game game)
{
    var level = AnsiConsole.Prompt(new SelectionPrompt<DifficultyLevel>()
        .Title("Please select [blue]difficulty level[/]")
        .AddChoices(Enum.GetValues<DifficultyLevel>()));

    game.SetDifficulty(level);

    var operation = AnsiConsole.Prompt(new SelectionPrompt<Operation>()
        .Title("Please select [blue]operation[/]")
        .AddChoices(Enum.GetValues<Operation>()));

    var numberOfRounds = AnsiConsole.Prompt(new SelectionPrompt<int>()
        .Title("How [blue]many rounds[/] would you like to play?")
        .AddChoices(new[] { 3, 10, 25 }));

    var stopwatch = new Stopwatch();
    for (var i = 0; i < numberOfRounds; i++)
    {
        var rule = new Rule($"[blue]{i + 1,2}[/][gray] / {numberOfRounds,2}[/]").LeftJustified().RuleStyle("gray");
        AnsiConsole.Write(rule);

        var puzzle = game.GetPuzzle(operation);

        stopwatch.Start();
        var answer = AnsiConsole.Ask<int>($"{puzzle.Question} = ");
        var result = game.Answer(puzzle, answer, stopwatch.Elapsed);
        stopwatch.Reset();

        AnsiConsole.MarkupLine($"Your answer was {(result.IsCorrect ? "[green]CORRECT[/]" : "[red]INCORRECT[/]")}");
    }

    PrintScores(game);
}

void PrintScores(Game game)
{
    var table = new Table();
    table.AddColumn(new TableColumn("Level").Centered());
    table.AddColumns(new string[] { "Question", "Correct Answer", "User Answer", "Time" });

    foreach (var (difficulty, guess) in game.Guesses)
    {
        var level = (int)difficulty + 1;
        var stars = $"[gray]{new string('*', 3 - level)}[/][yellow]{new string('*', level)}[/]";
        table.AddRow(
            $"{stars}", 
            guess.Puzzle.Question, 
            $"{guess.Puzzle.Answer}", 
            $"{(guess.IsCorrect ? "[green]" : "[red]")}{guess.Answer}[/]",
            $"{guess.TimeTaken:c}"[3..]);
    }

    AnsiConsole.Write(table);
    AnsiConsole.MarkupLine("Press [blue]any key[/] to continue");
    Console.ReadKey();
}

enum Menu
{
    
    StartGame,
    ShowScores,
    Exit
}