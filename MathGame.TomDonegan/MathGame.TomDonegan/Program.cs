using MathGameConsole;

var menu = new Menu();

string name = Helpers.GetName();

var date = DateTime.UtcNow;

var games = new List<string>();

menu.ShowMenu(name, date);



