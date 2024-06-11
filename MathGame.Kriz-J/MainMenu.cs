 using MathGame.Kriz_J.Games;

namespace MathGame.Kriz_J;

public class MainMenu
{
    private readonly ResultKeeper _resultKeeper = [];
    
    public char Selection { get; set; }

    public bool Quit => Selection == 'Q';
    
    public static void Print()
    {
        ConsoleHelperMethods.PrintTitle(StylizedTitles.MainMenu);
        Console.WriteLine("\tSelect to play one of the following games:");
        Console.WriteLine("\t\t[A]ddition");
        Console.WriteLine("\t\t[S]ubtraction");
        Console.WriteLine("\t\t[M]ultiplication");
        Console.WriteLine("\t\t[D]ivision");
        Console.WriteLine("\t\t[R]andom");
        Console.WriteLine();
        Console.WriteLine("\t\t[L]atest Games");
        Console.WriteLine("\t\t[H]igh Score");
        Console.WriteLine("\t\t[Q]uit");
        Console.WriteLine();
        Console.Write("\t> ");
        Console.CursorVisible = true;
    }

    public void RouteSelection()
    {
        switch (Selection)
        {
            case 'A' or 'S' or 'M' or 'D' or 'R':
                InitializeAndStartGame();
                break;
            case 'L':
                ShowLatestGames();
                break;
            case 'H':
                ShowHighScore();
                break;
            case 'Q':
                ConfirmQuit();
                break;
            default:
                _ = ConsoleHelperMethods.PrintMessageAwaitResponse("Not a valid selection. Press any key . . .");
                break;
        }
    }

    private void InitializeAndStartGame()
    {
        Game game = Selection switch
        {
            'A' => new Addition(_resultKeeper),
            'S' => new Subtraction(_resultKeeper),
            'M' => new Multiplication(_resultKeeper),
            'D' => new Division(_resultKeeper),
            'R' => new RandomOperation(_resultKeeper),
            _ => throw new ArgumentOutOfRangeException()
        };

        game.Start();
    }

    private void ShowLatestGames()
    {
        ConsoleHelperMethods.PrintTitle(StylizedTitles.LatestGames);
        _resultKeeper.PrintLatestGames();
        _ = ConsoleHelperMethods.PrintMessageAwaitResponse(". . . Press any key to go back.");
    }
    
    private void ShowHighScore()
    {
        ConsoleHelperMethods.PrintTitle(StylizedTitles.HighScore);
        _resultKeeper.PrintHighScore();
        _ = ConsoleHelperMethods.PrintMessageAwaitResponse(". . . Press any key to go back.");
    }

    private void ConfirmQuit()
    {
        var response = ConsoleHelperMethods.PrintMessageAwaitResponse("Do you really want to quit? [N] to stay.");
        if (response == 'N')
        {
            Selection = '\0';
        }
    }
}