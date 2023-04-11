using MathGame;

var menu = new Menu();

var date = DateTime.Now;

string name = Helpers.GetName();

menu.ShowMenu(name, date);
