Console.WriteLine("Please type your name");

var name = Console.ReadLine();
var date = DateTime.Now;

Console.WriteLine("-----------------------------");
Console.WriteLine($"Hello {name.ToUpper()}. It's {date.DayOfWeek}. This is your math's game. That's great that you're working on improving yourself\n");
Console.WriteLine($@"What game would you like to play today? Choose from the options below:
A - Addition 
S - Subtraction
M - Multiplication
D - Division
Q - Quit the program");
Console.WriteLine("-----------------------------");

Console.ReadLine();