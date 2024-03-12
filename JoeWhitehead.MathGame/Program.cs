using ConsoleMathsGame;

var menu = new Menu();
var name = Helpers.GetName();
var games = new List<string>();
DateTime date = DateTime.UtcNow;
menu.ShowMenu(name, date);