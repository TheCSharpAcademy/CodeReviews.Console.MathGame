using Math_Game;
var menu = new Menu();

var date = DateTime.UtcNow;

var games = new List<string>();

string name = GetName();

menu.ShowMenu(name, date);
static string GetName()
{
    Console.WriteLine("Please type your name");
    var name = Console.ReadLine();
    return name;
}
