using ConsoleMathsGame;

var menu = new Menu();
var name = Helpers.GetName();
DateTime date = DateTime.UtcNow;
menu.ShowMenu(name, date);