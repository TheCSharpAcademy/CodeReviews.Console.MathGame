using MathGame.Arashi256;

Console.WriteLine("C# Academy - 1. Math Game");
var menu = new Menu();
var date = DateTime.UtcNow;
var name = Helpers.GetName();

menu.ShowMenu(name, date);