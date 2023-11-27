namespace Branch_Console;

internal class SetName : State
{
    public override void Print()
    {
        Console.WriteLine("Please type your name");
    }

    public override State? Process()
    {
        var result = Helpers.GetName();
        _context._settings.PlayerName = result;
        return new MainMenu();
    }
}