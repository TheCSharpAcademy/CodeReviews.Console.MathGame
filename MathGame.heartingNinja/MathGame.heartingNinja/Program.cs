using MathProject;

Menu menu = new Menu();
string date = DateTime.Now.ToString();

List<string> games = new();

string name = Helpers.GetName();

menu.ShowMenu(name, date);


