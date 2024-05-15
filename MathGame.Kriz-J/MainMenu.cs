using MathGame.Kriz_J.Games;
using static MathGame.Kriz_J.ConsoleHelperMethods;

namespace MathGame.Kriz_J;

public class MainMenu
{
    private readonly List<GameResult> _scoreKeeper = [];

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
    }

    public void RouteSelection()
    {
        switch (Selection)
        {
            case 'A' or 'S' or 'M' or 'D' or 'R':
                RouteGameSection();
                break;
            case 'L':
                ShowLatestGames();
                break;
            case 'H':
                ShowHighScore();
                break;
            case 'Q':
                var response = PrintMessage("Do you really want to? [Y/N]");
                if (response == 'N')
                    Selection = ' ';
                break;
            default:
                PrintMessage("Not a valid selection . . .");
                break;
        }
    }

    private void RouteGameSection()
    {
        Game _ = Selection switch
        {
            'A' => new Addition(_scoreKeeper),
            'S' => new Subtraction(_scoreKeeper),
            'M' => new Multiplication(_scoreKeeper),
            'D' => new Division(_scoreKeeper),
            'R' => new RandomOperation(_scoreKeeper),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private void ShowLatestGames()
    {
        GameResult.PrintGameResults(StylizedTitles.LatestGames, _scoreKeeper.OrderByDescending(s => s.Timestamp));
    }
    
    private void ShowHighScore()
    {
        GameResult.PrintGameResults(StylizedTitles.HighScore, _scoreKeeper.OrderByDescending(s => s.PercentageScore));
    }
}