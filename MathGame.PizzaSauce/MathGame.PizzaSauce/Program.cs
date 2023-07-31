using MyFirstProgram;

var menu = new Menu();

var date = DateTime.UtcNow;


string name = GetName();
string GetName()
{
    Console.WriteLine("Please enter your name:");
    var name = Console.ReadLine();
    while (string.IsNullOrEmpty(name))
    {
        Console.Clear();
        Console.WriteLine("Please enter your name:");
        name = Console.ReadLine();
    }
    return name;
}

menu.ShowMenu(name, date);

Console.ReadLine();