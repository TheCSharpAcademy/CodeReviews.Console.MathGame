using MathGame.K_MYR;

var menu = new Menu();

var date = DateTime.UtcNow;

string name = Helpers.GetName();

menu.ShowMenu(name, date);

