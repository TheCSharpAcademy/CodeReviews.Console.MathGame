using MathGame.Kriz_J;

var mainMenu = new MainMenu();

while (!mainMenu.Quit)
{
    MainMenu.Print();
    mainMenu.Selection = ConsoleHelperMethods.ReadUserSelection();
    mainMenu.RouteSelection();
}