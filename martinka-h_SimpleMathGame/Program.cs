using SimpleMathGame;

//class instances
Menu menu = new Menu();

//menu variables
string name = Helpers.GetName();
DateTime date = DateTime.UtcNow;

menu.ShowMenu(name, date);



