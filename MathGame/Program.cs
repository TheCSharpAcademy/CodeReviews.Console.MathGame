using MathGame;

// Top Level Set-Up
string? name = Helpers.GetName();
var date = DateTime.Now;

Menu menu = new Menu();
menu.ShowMenu(name!, date);








