using ConsoleMathsGame;

var date = DateTime.UtcNow;

string name = Helpers.GetName();

var menu = new Menu();
menu.ShowMainMenu(name, date);