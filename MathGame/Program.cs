using MathGame;
using System.Reflection.Metadata.Ecma335;
var menu = new Menu();

var date = DateTime.UtcNow;

string name = Helpers.GetName();

menu.ShowMenu(name, date);