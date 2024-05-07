namespace MathGame.Kriz_J;

public class Program
{
    private static void Main()
    {
        var mainMenu = new MainMenu();
        while (!mainMenu.Quit)
        {
            MainMenu.Print();
            mainMenu.Selection = ConsoleHelperMethods.ReadUserSelection();
            mainMenu.Route();
        }
    }
}