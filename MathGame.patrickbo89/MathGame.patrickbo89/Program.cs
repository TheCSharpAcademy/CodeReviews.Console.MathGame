using MathGame.patrickbo89;

var date = DateTime.UtcNow;

var menu = new Menu();

string name = Helpers.GetName();

menu.DisplayMenu(name, date);