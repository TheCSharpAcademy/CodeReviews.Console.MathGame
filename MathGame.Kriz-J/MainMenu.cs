using MathGame.Kriz_J.GameSections;

namespace MathGame.Kriz_J;

public class MainMenu
{
    public char Selection { get; set; }

    public bool Quit => Selection == 'Q';

    public void Route()
    {
        GameSection _ = Selection switch
        {
            'A' => new Addition(),
            'S' => new Subtraction(),
            'M' => new Multiplication(),
            'D' => new Division(),
            'R' => new RecentGames(),
            'Q' => new Quit(),
            _ => new NotImplemented()
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