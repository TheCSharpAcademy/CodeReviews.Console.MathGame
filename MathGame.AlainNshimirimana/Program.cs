using MathGame.AlainNshimirimana;

var menu = new Menu();
var date = DateTime.Now; 

var games = new List<string>();
string name = GetName();

menu.ShowMenu(name, date);

string GetName()
{
    Console.WriteLine("Please type your name");
    var name = Console.ReadLine();
    return name;
}
