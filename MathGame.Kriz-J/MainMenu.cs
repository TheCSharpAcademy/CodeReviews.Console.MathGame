using MathGame.Kriz_J.Games;
using static MathGame.Kriz_J.ConsoleHelperMethods;

namespace MathGame.Kriz_J;

public class MainMenu
{
    private readonly List<GameResult> _resultKeeper = [];

    public char Selection { get; set; }

    public bool Quit => Selection == 'Q';
    
    public static void Print()
    {
        PrintTitle(StylizedTitles.MainMenu);
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
                RouteGame();
                break;
            case 'L':
                ShowLatestGames();
                break;
            case 'H':
                ShowHighScore();
                break;
            case 'Q':
                var response = PrintMessage("Do you really want to? [N] to stay.");
                if (response == 'N')
                    Selection = ' ';
                break;
            default:
                _ = PrintMessage("Not a valid selection. Press any key . . .");
                break;
        }
    }

    private void RouteGame()
    {
        Game _ = Selection switch
        {
            'A' => new Addition(_resultKeeper),
            'S' => new Subtraction(_resultKeeper),
            'M' => new Multiplication(_resultKeeper),
            'D' => new Division(_resultKeeper),
            'R' => new RandomOperation(_resultKeeper),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private void ShowLatestGames()
    {
        PrintTitle(StylizedTitles.LatestGames);
        GameResult.PrintGameResults(_resultKeeper.OrderByDescending(s => s.Timestamp));
        _ = PrintMessage(". . . Press any key to go back.");
    }
    
    private void ShowHighScore()
    {
        PrintTitle(StylizedTitles.HighScore);
        GameResult.PrintGameResults(_resultKeeper.OrderByDescending(s => s.PercentageScore));
        _ = PrintMessage(". . . Press any key to go back.");
    }
}