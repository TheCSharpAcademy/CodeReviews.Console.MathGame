using MathGame;

var menu = new Menu();

var date = DateTime.UtcNow;
var games = new List<string>();
var name = Helpers.GetName();

menu.ShowMenu(name, date);

