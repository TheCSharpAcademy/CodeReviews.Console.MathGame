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
        .AddChoices(Enum.GetValues<Choice>()));

while (whatsNext == Choice.PlayAgain)
{
    var input = AnsiConsole.Prompt(new SelectionPrompt<MathOperation>().Title("Choose Math operation:")
        .AddChoices(Enum.GetValues<MathOperation>()));

    var example = Game.GetExample(input);
    AnsiConsole.WriteLine(example.Representation);
    int answer = AnsiConsole.Ask<int>("Enter the answer:");

    if (answer == example.Value)
    {
        AnsiConsole.MarkupLine($"Good job! {answer} is correct :thumbs_up:");
    }
    else
    {
        AnsiConsole.MarkupLine($"Sorry, but answer is {example.Value} :pensive_face:");
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
    Quit
}