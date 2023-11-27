namespace Branch_Console;

internal class SetDifficulty : State
{
    public override void Print()
    {
        Console.Clear();
        Console.WriteLine(new string('-', Helpers.ConsoleWidth()));
        Console.WriteLine(@$"Current Difficulty is: {_context._settings.Difficulty}.");
        Console.WriteLine($"What would you like the new difficulty to be?\nChoose from the options below:");
        foreach (int i in Enum.GetValues(typeof(Difficulty)))
        {
            Console.WriteLine($"            {i} - {Enum.GetName(typeof(Difficulty), i)}");
        }
        Console.WriteLine($"            0 - Return to main menu");
    }

    public override State? Process()
    {
        State? newState = null;
        var input = Console.ReadLine();

        if (!int.TryParse(input, out int result))
            result = -1;

        switch (result)
        {
            case 0:
                newState = new GameSettings();
                break;
            case 1:
                _context._settings.Difficulty = Difficulty.Easy;
                newState = new GameSettings();
                break;
            case 2:
                _context._settings.Difficulty = Difficulty.Normal;
                newState = new GameSettings();
                break;
            case 3:
                _context._settings.Difficulty = Difficulty.Hard;
                newState = new GameSettings();
                break;
            /* case 4:
                _context._settings.Difficulty = Difficulty.Impossible;
                newState = new GameSettings();
                break; */
            default:
                Console.WriteLine($"Invalid input. Select an option from above.\nPress Any Key");
                Console.ReadLine();
                newState = this;
                break;
        }
        return newState;
    }
}