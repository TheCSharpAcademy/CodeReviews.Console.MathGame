using Maths_Game;

Menu menu = new();

DateTime date = DateTime.UtcNow;

List<string> games = new();

string name = Helpers.GetName();

menu.MainMenu(name);