using GonzaLorenzo.MathGame;

Console.WriteLine("Welcome to the Math Game, please type your name.");

Menu menu = new();
string name = GetName();

menu.GameMenu(name);

string GetName()
{
    string name = Console.ReadLine();

    while (string.IsNullOrEmpty(name.Trim()) || int.TryParse(name, out _))
    {
        Console.Clear();
        Console.WriteLine("Invalid Input. Please type your name.");
        name = Console.ReadLine();
    } 

    name = char.ToUpper(name[0]) + name.Substring(1);

    return name;
}