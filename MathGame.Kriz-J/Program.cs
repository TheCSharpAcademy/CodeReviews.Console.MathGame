namespace MathGame.Kriz_J;

class Program
{
    static void Main(string[] args) => MakeAndRouteSelection();

    private static void MakeAndRouteSelection()
    {
        var selection = new MainMenuSelection();

        while (selection.Value != 'Q')
        {
            PrintMenu();
            selection = SelectMenuOption();
            selection.Route();
        }
    }

    private static void PrintMenu()
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

    private static MainMenuSelection SelectMenuOption()
    {
        var character = char.ToUpper(Console.ReadKey().KeyChar);

        return new MainMenuSelection(character);
    }
}
