using MathGame;

var name = Helpers.GetName();
var date = DateTime.UtcNow;
Menu menu = new Menu();
menu.ShowMenu(name, date);
