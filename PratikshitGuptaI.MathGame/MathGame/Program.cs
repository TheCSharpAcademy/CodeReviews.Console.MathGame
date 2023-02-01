using MathGame;

var menu = new Menu();
Console.WriteLine("Enter your name");
var name = Console.ReadLine();
while (String.IsNullOrEmpty(name))
{
    Console.WriteLine("Name cannot be empty");
    name=Console.ReadLine();
}

DateTime date = DateTime.UtcNow;
Console.WriteLine("Enter number of questions you want to play with:");
var total = Convert.ToInt32(Console.ReadLine());
menu.GameMenu(name, date,total);