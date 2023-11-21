using MyFirstProgram;

var date = DateTime.UtcNow;

var menu = new Menu();

var name = Helpers.GetName();

menu.ShowMenu(name, date);