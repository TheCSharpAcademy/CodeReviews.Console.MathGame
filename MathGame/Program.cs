using MathGame;

Menu menu = new();

var date = DateTime.UtcNow;

string name = Helpers.GetName();

menu.ShowMenu(name, date);
