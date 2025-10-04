using MathGame;
using System;

var menu = new Menu();
var games = new List<string>();

string? name = Helpers.GetName();
DateTime date = DateTime.UtcNow;

menu.ShowMenu(name,date);
