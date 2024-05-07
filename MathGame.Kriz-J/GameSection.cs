namespace MathGame.Kriz_J;

public abstract class GameSection
{
    public GameSettings Settings { get; set; } = new();

    public bool Quit { get; set; }

    protected GameSection()
    {
        SectionLoop();
    }

    protected abstract void SectionLoop();

    protected abstract void StandardGame();
    
    protected abstract void TimedGame();
    
    protected abstract void CustomGame();

    protected static void PrintMenu(string title, string description, Difficulty difficulty, Mode mode)
    {
        Console.Clear();
        Console.WriteLine($"{title}");
        Console.WriteLine("\tThe goal of this game is to answer correctly to the set of questions presented.");
        Console.WriteLine($"\t{description}");
        Console.WriteLine("");
        Console.WriteLine("\tSelect difficulty:");
        GameSettings.PrintGameDifficulties(difficulty);
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("\tSelect mode:");
        GameSettings.PrintGameModes(mode);
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("\t[ENTER] / [SPACE] to start game, [Q] to quit.");
        Console.WriteLine();
        Console.Write("\t> ");
    }

    protected void ReadAndRouteUserSelection()
    {
        var input = ConsoleHelperMethods.ReadUserSelection();

        switch (input)
        {
            case 'Q':
                Quit = true;
                break;
            case '\r' or ' ':
                RouteMode(Settings.Mode);
                break;
            default:
                Settings.ChangeDifficultyOrMode(input);
                break;
        }
    }

    private void RouteMode(Mode mode) 
    {
        switch (mode)
        {
            case Mode.Standard:
                StandardGame();
                break;
            case Mode.Timed:
                TimedGame();
                break;
            case Mode.Custom:
                CustomGame();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
        }
    }
}