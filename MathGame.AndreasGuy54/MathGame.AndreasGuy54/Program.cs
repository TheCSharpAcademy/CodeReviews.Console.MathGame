using MathGame.AndreasGuy54;

var menu = new Menu();

DateTime date = DateTime.UtcNow;
string? name = GetName();

menu.ShowMenu(name, date);

string? GetName()
{
    Console.WriteLine("Please type your name");

    string? name = Console.ReadLine();
    return name;
}

