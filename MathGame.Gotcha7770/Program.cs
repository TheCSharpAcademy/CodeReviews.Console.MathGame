// See https://aka.ms/new-console-template for more information
// See https://spectreconsole.net/ for spectre.console documentation

using MathGame.Gotcha7770;
using Spectre.Console;

AnsiConsole.Clear();
AnsiConsole.Write(new FigletText("Math Game project for The C# Academy")
    .Centered()
    .Color(Color.Green));

AnsiConsole.WriteLine();
var whatsNext = AnsiConsole.Prompt(
    new SelectionPrompt<Choice>
        {
            Converter = value => value is Choice.PlayAgain ? "Let`s start the game!" : "I`m busy, not now..."
        }
        .Title("Hi! Do you want play or quit?")
        .AddChoices(Choice.PlayAgain, Choice.Quit));

while (whatsNext is not Choice.Quit)
{
    if (whatsNext == Choice.ShowHistory)
    {
        foreach (var item in Game.History)
        {
            AnsiConsole.MarkupLineInterpolated($"Example: {item.Item1.Representation}, Users answer: {item.Item2}, Correct value: {item.Item1.Value}");
        }
    }
    else
    {
        var input = AnsiConsole.Prompt(new SelectionPrompt<MathOperation>().Title("Choose Math operation:")
            .AddChoices(Enum.GetValues<MathOperation>()));

        var gameTurn = Game.NextTurn(input);
        AnsiConsole.WriteLine(gameTurn.Representation);
        int answer = AnsiConsole.Ask<int>("Enter the answer:");

        if (answer == gameTurn.Value)
        {
            AnsiConsole.MarkupLine($"Good job! {answer} is correct :thumbs_up:");
        }
        else
        {
            AnsiConsole.MarkupLine($"Sorry, but answer is {gameTurn.Value} :pensive_face:");
        }
        
        Game.SaveAnswer(gameTurn, answer);
    }

    AnsiConsole.WriteLine();
    whatsNext = AnsiConsole.Prompt(new SelectionPrompt<Choice>()
        .Title("What`s next?")
        .AddChoices(Enum.GetValues<Choice>()));

    AnsiConsole.Clear();
    AnsiConsole.Write(new FigletText("Math Game project for The C# Academy")
        .Centered()
        .Color(Color.Green));
}

AnsiConsole.Clear();

public enum Choice
{
    PlayAgain,
    ShowHistory,
    Quit
}