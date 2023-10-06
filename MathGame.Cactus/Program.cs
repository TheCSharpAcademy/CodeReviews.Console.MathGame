Console.WriteLine("Please type your name");
var username = Console.ReadLine();
var date = DateTime.UtcNow;
Console.WriteLine($"Hello {username?.ToUpper()}, now time is {date}. Let's start the game.\n");

string menu = @"Please choose the option:
A - Addition
S - Subtraction
M - Multiplication
D - Dovision
Q - Quit
";

Console.WriteLine(menu);

var option =  Console.ReadLine();
switch(option?.Trim().ToUpper())
{
    case "A":
        Add();
        break;
    case "S":
        Sub();
        break;
    case "M":
        Mul();
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

void Add()
{
    Console.WriteLine("Addition Game");
    var rand = new Random();
    var num1 = rand.Next(0, 99);
    var num2 = rand.Next(0, 99);
    Console.WriteLine($"Please enter the result of {num1} + {num2}:");
    var res = 0;
    var input = Console.ReadLine();
    if(String.IsNullOrEmpty(input) || !int.TryParse(input, out res))
    {
        Console.WriteLine("Invalid Input");
    }else if(res == num1 + num2)
    {
        Console.WriteLine("Answer Correct!");
    }else {
        Console.WriteLine("Answer Error.");
    };
}

void Sub()
{
    Console.WriteLine("Subtraction Game");
    var rand = new Random();
    var num1 = rand.Next(0, 99);
    var num2 = rand.Next(0, 99);
    Console.WriteLine($"Please enter the result of {num1} - {num2}:");
    var res = 0;
    var input = Console.ReadLine();
    if (String.IsNullOrEmpty(input) || !int.TryParse(input, out res))
    {
        Console.WriteLine("Invalid Input");
    }
    else if (res == num1 - num2)
    {
        Console.WriteLine("Answer Correct!");
    }
    else
    {
        Console.WriteLine("Answer Error.");
    };
}

void Mul()
{
    Console.WriteLine("Muliplication Game");
    var rand = new Random();
    var num1 = rand.Next(0, 10);
    var num2 = rand.Next(0, 10);
    Console.WriteLine($"Please enter the result of {num1} * {num2}:");
    var res = 0;
    var input = Console.ReadLine();
    if (String.IsNullOrEmpty(input) || !int.TryParse(input, out res))
    {
        Console.WriteLine("Invalid Input");
    }
    else if (res == num1 * num2)
    {
        Console.WriteLine("Answer Correct!");
    }
    else
    {
        Console.WriteLine("Answer Error.");
    };
}