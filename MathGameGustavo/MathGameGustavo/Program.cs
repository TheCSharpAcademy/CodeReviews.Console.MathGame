using MathGameGustavo;

Menu menu = new Menu();
Helpers helpers = new Helpers();

var date = DateTime.Now;
string name = helpers.GetName();

menu.ShowMenu(name, date);