using MathGame;

var menu = new Menu();

var date = DateTime.Now;

int questionAmount = 5;

string name = Helpers.GetName();

menu.ShowMenu(name, date, questionAmount);

