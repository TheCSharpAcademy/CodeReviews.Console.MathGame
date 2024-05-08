using math_console_app;

var menu = new Menu(); //Same as Menu menu = new();

var date = DateTime.UtcNow;

var games = new List<string>();

string name = Helpers.GetName();

menu.ShowMenu(name, date);


