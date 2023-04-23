using MathProject;

Menu menu = new Menu();
string date = DateTime.Now.ToString();


string name = Helpers.GetName();

menu.ShowMenu(name, date);


