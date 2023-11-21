using MathGame.nwdorian;

DateTime date = DateTime.Now;

Menu menu = new Menu();

string name = Helpers.GetName();

menu.ShowMenu(name, date);