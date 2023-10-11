using Math_Game;

var date = DateTime.UtcNow;
var menu = new Menu();

string name = Helpers.GetName();

menu.ShowMenu(name, date);
