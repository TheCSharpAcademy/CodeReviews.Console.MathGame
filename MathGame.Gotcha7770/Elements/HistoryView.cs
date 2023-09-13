using Spectre.Console;

namespace MathGame.Gotcha7770.Elements;

public class HistoryView
{
    private readonly IReadOnlyCollection<GameTurn> _gameHistory;

    public HistoryView(IReadOnlyCollection<GameTurn> gameHistory)
    {
        _gameHistory = gameHistory;
    }

    public void Show(IAnsiConsole console)
    {
        console.Write(_gameHistory.ToRows());
    
        console.Prompt(
            new SelectionPrompt<string>()
                .Title("Back to main menu?")
                .AddChoices("Press enter"));
    }
}