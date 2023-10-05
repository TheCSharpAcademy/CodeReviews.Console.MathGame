Console.WriteLine("Please type your name");
var username = Console.ReadLine();
var date = DateTime.UtcNow;
Console.WriteLine($"Hello {username.ToUpper()}, now time is {date}. Let's start the game.\n");

string menu = @"Please choose the option:
A - Addition
S - Subtraction
M - Multiplication
D - Dovision
Q - Quit
";

Console.WriteLine(menu);

var option =  Console.ReadLine();
switch(option.Trim().ToUpper())
{
    case "A":
        Console.WriteLine("Addition Game");
        break;
    case "S":
        Console.WriteLine("Subtraction Game");
        break;
    case "M":
        Console.WriteLine("Muliplication Game");
        break;
    case "D":
        Console.WriteLine("Division Game");
        break;
    case "Q":
        Console.WriteLine("Bye");
        Environment.Exit(0);
        break;
    default:
        Console.WriteLine("Invalid Input");
        break;
}

