using System.Net.Mail;
using Entities;
using Spectre.Console;

List<GameResult> gameResults = new();

while (true)
{

    Console.Clear();

    var choice = AnsiConsole.Prompt( new SelectionPrompt<string>().Title("==================\nMath Game").AddChoices("Start Game","View Scores", "Exit"));


    if(choice == "Exit")
    {
        return;
    }else if(choice == "View Scores")
    {
        var table = new Table().AddColumn("Difficulty").AddColumn("Operation").AddColumn("Score").AddColumn("Duration");

        gameResults.ForEach(x => table.AddRow($"{x._difficultyLevel}",$"{x._operation}",$"{x._score}", $"{x._duration.ToString(@"mm\:ss")}"));

        AnsiConsole.Write(table);
        AnsiConsole.MarkupLine("Press any key to continue...");
        Console.ReadKey();
    }
    else 
    {
        var rand = new Random();
        var timer = new GameTimer();

        var mode = AnsiConsole
        .Prompt(new SelectionPrompt<GameMode>()
        .Title("==================\nMath Game\n==================\nPlease Select a game mode:")
        .AddChoices(Enum.GetValues<GameMode>()));

        var difficulty = AnsiConsole
        .Prompt(new SelectionPrompt<DifficultyLevel>()
        .Title("==================\nMath Game\n==================\nPlease Select a difficulty:")
        .AddChoices(Enum.GetValues<DifficultyLevel>()));

        if(mode == GameMode.Single)
        {
            var option = AnsiConsole.Prompt(
            new SelectionPrompt<Operation>().Title("==================\nMath Game\n==================\nPlease Select an opperation:").AddChoices(Enum.GetValues<Operation>()));

            var fixedOperation = new FixedOperationProvider(option);

            var newGame = new Game(fixedOperation, difficulty, timer, mode, rand);
            gameResults.Add(newGame.Start());
        }
        else
        {
            var randomOperationProvider = new RandomOperationProvider(rand, Enum.GetValues<Operation>().ToList());
            var newGame = new Game(randomOperationProvider, difficulty, timer, mode, rand);
            gameResults.Add(newGame.Start());
        }
    }
}


