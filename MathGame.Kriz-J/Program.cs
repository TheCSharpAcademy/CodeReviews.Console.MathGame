namespace MathGame.Kriz_J;

public class Program
{
    private static void Main() => MakeAndRouteSelection();

    private static void MakeAndRouteSelection()
    {
        var selection = new MainMenuSelection();

        while (selection.Value != 'Q')
        {
            GameHelperMethods.PrintMainMenu();
            selection = SelectMainMenuOption();
            selection.Route();
        }
    }
    
    private static MainMenuSelection SelectMainMenuOption()
    {
        var character = char.ToUpper(Console.ReadKey().KeyChar);

        return new MainMenuSelection(character);
    }
}
