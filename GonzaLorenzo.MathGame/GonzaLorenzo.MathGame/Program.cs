using GonzaLorenzo.MathGame;

Console.WriteLine("Welcome to the Math Game, please type your name.");

Menu menu = new();
string name = GetName();

menu.GameMenu(name);

string GetName()
{
    string name = Console.ReadLine();

    do
    {
        if (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Please type your name.");
            name = Console.ReadLine();
        }
    } while (string.IsNullOrEmpty(name));

    name = char.ToUpper(name[0]) + name.Substring(1);

    return name;
}