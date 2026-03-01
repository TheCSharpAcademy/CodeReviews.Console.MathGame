using Game;

var menu = new Menu();
var date = DateTime.Now;

string name = Helpers.GetName();

Menu.ShowMenu(name, date);