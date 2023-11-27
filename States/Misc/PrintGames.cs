namespace Branch_Console;

internal class PrintGames : State
{
    public override void Print()
    {
        Console.Clear();
        Console.WriteLine("Games History:");
        Console.WriteLine(new string('-', Helpers.ConsoleWidth()));
        foreach (var game in _context.gameHistory)
        {
            Console.WriteLine(game.ToString());
        }
        Console.WriteLine(new string('-', Helpers.ConsoleWidth()));
        Console.WriteLine("Press any key to return to Main Menu");
        Console.ReadLine();
    }

    public override State? Process()
    {
        return new MainMenu();
    }
}