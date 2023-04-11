using Math_Game;
var menu = new Menu();

var date = DateTime.UtcNow;

string name = GetName();

menu.ShowMenu(name, date);
static string GetName()
{
    Console.WriteLine("Please type your name");
    var name = Console.ReadLine();
    return name;
}
