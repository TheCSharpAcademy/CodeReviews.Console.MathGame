// See https://aka.ms/new-console-template for more information
// See https://spectreconsole.net/ for spectre.console documentation

using MathGame.Gotcha7770;
using Spectre.Console;

var playersChoice = Choice.MainMenu;

do
{
    AnsiConsole.Clear();

    switch (playersChoice)
    {
        case Choice.MainMenu:
            playersChoice = PrintMainMenu();
            break;
        case Choice.TrainExample:
            StartTrainLoop();
            playersChoice = Choice.MainMenu;
            break;
        case Choice.GameHistory:
            PrintHistory();
            playersChoice = Choice.MainMenu;
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(playersChoice));
    }
} while (playersChoice is not Choice.Quit);

AnsiConsole.Clear();

void PrintTitle()
{
    AnsiConsole.Write(new FigletText("Math Game project for")
        .Centered()
        .Color(Color.Green));
    AnsiConsole.Write(new FigletText("The C# Academy")
        .Centered()
        .Color(Color.Purple));
    AnsiConsole.WriteLine();
}

Choice PrintMainMenu()
{
    PrintTitle();

    return AnsiConsole.Prompt(new SelectionPrompt<Choice>()
        .Title("What`s next?")
        .AddChoices(Choice.TrainExample, Choice.GameHistory, Choice.Quit));
}

void StartTrainLoop()
{
    PrintTitle();

    var input = AnsiConsole.Prompt(new SelectionPrompt<MathOperation>()
        .Title("Choose Math operation:")
        .AddChoices(Enum.GetValues<MathOperation>()));

    bool tryAgain;
    do
    {
        var gameTurn = Game.NextTurn(input);
        AnsiConsole.WriteLine(gameTurn.Expression);
        int answer = AnsiConsole.Ask<int>("Enter the answer:");

        if (answer == gameTurn.Value)
        {
            AnsiConsole.MarkupLine($"Good job! {answer} is correct :thumbs_up:");
        }
        else
        {
            AnsiConsole.MarkupLine($"Sorry, but answer is {gameTurn.Value} :pensive_face:");
        }

        tryAgain = AnsiConsole.Prompt(new SelectionPrompt<bool> { Converter = value => value ? "Yes give me a chance!" : "No i`m done" }
            .Title("Try again?")
            .AddChoices(true, false));

        Game.SaveAnswer(gameTurn, answer);
    } while (tryAgain);
}

void PrintHistory()
{
    AnsiConsole.Write(Game.History.ToRows());
    
    AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("Back to main menu?")
            .AddChoices("Press enter"));
}

public enum Choice
{
    MainMenu,
    TrainExample,
    GameHistory,
    Quit
}