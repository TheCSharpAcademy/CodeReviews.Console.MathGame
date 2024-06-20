using MathGame;
// Top Level Set-Up

string? name = Helpers.GetName();
var date = DateTime.Now;

List<string> games = new();
Menu menu = new Menu();

menu.ShowMenu(name!, date);








