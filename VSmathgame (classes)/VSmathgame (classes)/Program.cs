
using VSmathgame__classes_;
using VSmathgame__classes_.Models;

Console.WriteLine("Please enter your name.");

var menu = new Menu();
// to use the class we need to instantiate it.

var name = Console.ReadLine();
var date = DateTime.UtcNow;

List<Game> games = new();

menu.ShowMenu(name, date);

//var engine = new GameEngine();


while (true)
{
    menu.ShowMenu(name, date);
}
// allows the loop to run whilst the menu loop is true 