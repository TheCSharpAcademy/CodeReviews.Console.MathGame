using Masherishere.MathGame;

var date = DateTime.UtcNow;

var name = GetName();

var menu = new Menu();

menu.ShowMenu(name, date);

string GetName()
{

    Console.WriteLine("Please type your name: ");
    var name = Console.ReadLine();

    while (string.IsNullOrEmpty(name))
    {
        Console.WriteLine("Your Name should not be empty");
        name = Console.ReadLine();
    }

    return name;
}
