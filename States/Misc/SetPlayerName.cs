namespace Branch_Console;

internal class SetPlayerName : State
{
    public override void Print()
    {
        Console.Clear();
        Console.WriteLine(new string('-', Helpers.ConsoleWidth()));
        Console.WriteLine(@$"Current player name is: {_context._settings.PlayerName}.");
        Console.WriteLine("Please type your name");
    }

    public override State? Process()
    {
        var result = Helpers.GetName();
        _context._settings.PlayerName = result;
        return new GameSettings();
    }
}