// See https://aka.ms/new-console-template for more information
// See https://spectreconsole.net/ for spectre.console documentation

using MathGame.Gotcha7770;
using Spectre.Console;

AnsiConsole.Write(new FigletText("Math Game project for The C# Academy")
    .Centered()
    .Color(Color.Green));

var input = AnsiConsole.Prompt(new SelectionPrompt<MathOperation>()
    .Title("Choose Math operation:")
    .AddChoices(Enum.GetValues<MathOperation>()));

var example = Game.GetExample(input);
AnsiConsole.WriteLine(example);
int answer = AnsiConsole.Ask<int>("Enter the answer:");