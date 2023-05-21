using MathGame.AlainNshimirimana;

var menu = new Menu();
var date = DateTime.Now; 

var games = new List<string>();
string name = Helpers.GetName();

menu.ShowMenu(name, date);
