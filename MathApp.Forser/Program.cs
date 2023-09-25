using MathApp;

string? name = GetName();
Menu menu = new Menu();

menu.ShowMenu(name);

string? GetName()
{
    Console.WriteLine("Please type your name");

    string? name = Console.ReadLine();
    return name;
}