using MathGame;

string name = Helpers.GetName();
DateTime date = DateTime.Now;

Menu menu = new();

menu.ShowMenu(name, date);