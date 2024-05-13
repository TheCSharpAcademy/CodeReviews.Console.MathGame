
using MyFirstProgram;

var menu = new Menu();
string name = GetName();
var date = DateTime.UtcNow;
menu.ShowMenu(name,date);


string GetName()
{
    Console.WriteLine("Please type your name");
    var name = Console.ReadLine();
    return name;
}



