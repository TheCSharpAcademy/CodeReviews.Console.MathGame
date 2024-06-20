using MathGame;
// Top Level Set-Up

string name = GetName();
var date = DateTime.Now;

List<string> games = new();
Menu menu = new Menu();

menu.ShowMenu(name, date);

string GetName()
{
	Console.Write("Please enter your name: ");
	string? name = Console.ReadLine()!;
	return name;
}






