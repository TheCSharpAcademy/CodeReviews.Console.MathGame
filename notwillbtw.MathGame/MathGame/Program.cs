using MathGame;

var menu = new Menu();

DateTime date = DateTime.Now;

string name = GetName();

menu.ShowMenu(name, date);

string GetName()
{
    Console.WriteLine("please enter your name.");
    string name = Console.ReadLine();
    return name;
}