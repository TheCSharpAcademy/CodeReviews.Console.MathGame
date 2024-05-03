using MyFirstProgram;


var date = DateTime.UtcNow;

string name = Helpers.GetName();

var menu = new Menu();


menu.ShowMenu(name, date);
