using MathGame;

{
    Menu menu = new Menu();

    DateTime date = DateTime.UtcNow;

    string name = Helpers.GetName();

    menu.ShowMenu(name, date);
}