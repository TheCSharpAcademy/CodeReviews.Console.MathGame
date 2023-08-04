// See https://aka.ms/new-console-template for more information

using MathGame.lordWalnuts;

var menu = new Menu();

var date = DateTime.UtcNow;

string name = Helpers.GetName();

menu.ShowMenu(name, date);