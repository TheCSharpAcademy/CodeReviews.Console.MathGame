// See https://aka.ms/new-console-template for more information
// See https://spectreconsole.net/ for spectre.console documentation

using MathGame.Gotcha7770;
using MathGame.Gotcha7770.Elements;
using Spectre.Console;

var playersChoice = Choice.MainMenu;

var game = new ConsoleGame();
var menu = Menu.From(
    new MenuItem<Choice>(Choice.Training, "Train operation"),
    new MenuItem<Choice>(Choice.History, "Show history"),
    new MenuItem<Choice>(Choice.Quit, "Quit"));
var history = new HistoryView(game.History);

while (playersChoice != Choice.Quit)
{
    switch (playersChoice)
    {
        case Choice.MainMenu:
            playersChoice = AnsiConsole.Console.ShowMenu(menu);
            break;
        case Choice.Training:
            game.StartTraining();
            playersChoice = Choice.MainMenu;
            break;
        case Choice.History:
            AnsiConsole.Console.ShowHistory(history);
            playersChoice = Choice.MainMenu;
            break;
        default:
            throw new NotImplementedException(nameof(playersChoice));
    }
}

AnsiConsole.Clear();