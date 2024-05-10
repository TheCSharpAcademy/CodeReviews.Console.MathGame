using MathGame.Kriz_J.GameSections;
using static MathGame.Kriz_J.ConsoleHelperMethods;

namespace MathGame.Kriz_J;

public class MainMenu
{
    public char Selection { get; set; }

    public bool Quit => Selection == 'Q';

    public List<ScoreRecord> History { get; set; } = [];

    public void RouteSelection()
    {
        switch (Selection)
        {
            case 'A' or 'S' or 'M' or 'D':
                RouteGameSection();
                break;
            case 'R':
                // Recent Games
            case 'H':
                // High Score?
            case 'Q':
                PrintMessage("Exiting game . . .");
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
            'A' => new Addition(),
            'S' => new Subtraction(),
            'M' => new Multiplication(),
            'D' => new Division(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public static void Print()
    {
        Console.Clear();
        Console.WriteLine($"{StylizedTexts.MainMenu}");
        Console.WriteLine();
        Console.WriteLine("\tSelect to play one of the following games:");
        Console.WriteLine("\t\t[A]ddition");
        Console.WriteLine("\t\t[S]ubtraction");
        Console.WriteLine("\t\t[M]ultiplication");
        Console.WriteLine("\t\t[D]ivision");
        Console.WriteLine();
        Console.WriteLine("\t\t[R]ecent games");
        Console.WriteLine("\t\t[Q]uit");
        Console.WriteLine();
        Console.Write("\t> ");
    }
}