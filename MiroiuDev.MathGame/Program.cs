using MiroiuDev.MathGame;

var menu = new Menu();

Console.WriteLine("What is your name?");

var name = Console.ReadLine();

while (string.IsNullOrEmpty(name)) name = Console.ReadLine();

var date = DateTime.UtcNow;

menu.ShowMenu(name, date);


