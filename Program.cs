using MathGame;

Menu menu = new Menu();

DateTime date = DateTime.UtcNow;
string? name = GetName();

menu.ShowMenu(name, date);

string GetName()
{
    Console.WriteLine("Please enter your first name");
    string? name = Console.ReadLine();
    while (String.IsNullOrWhiteSpace(name))
    {
        Console.WriteLine("Please type your first name without spaces");
        name = Console.ReadLine();
    }
    Console.Clear();
    return name.Trim();

}