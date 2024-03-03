using math_game;
Menu menu = new Menu();

var date = DateTime.UtcNow;

//List<string> games = new List<string>();
var games = new List<string>();

string name = GetName();

menu.DisplayMenu(name, date.DayOfWeek.ToString());

string GetName()
{
    Console.WriteLine("Please type your name");
    var name = Console.ReadLine();
    return name;
}