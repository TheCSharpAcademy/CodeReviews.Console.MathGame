
using anajmowicz.MathGame;

var menu = new Menu();
var date = DateTime.Now;
var name = GetName();


menu.ShowMenu(name, date);
string GetName()
{
    Console.WriteLine("Welcome to Math Game. What's your name?");
    Console.Write("> ");
    name = Console.ReadLine();
    return name;
}
