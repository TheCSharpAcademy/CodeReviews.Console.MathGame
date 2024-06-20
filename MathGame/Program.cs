// Top Level Set-Up



Console.Write("Please enter your name: ");
string? name = Console.ReadLine();
var date = DateTime.Now;

// Menu
Console.WriteLine("------------------------------------------------------");
Console.WriteLine($"Welcome to The Math Game, {name}.\nThe time is {date.Hour}:{date.Minute} on {date.DayOfWeek}.\n");
Console.WriteLine($@"Please select a game to play from the list below:
A - Addition
S - Subtraction
M - Multiplication
D - Division
R - Random
Q - Quit");
Console.WriteLine("------------------------------------------------------");

string? gameSelected = Console.ReadLine();
if (gameSelected != null)
switch (gameSelected.Trim().ToLower())
{
	case "a":
		Console.WriteLine("You selected Addition Game.");
		break;
	case "s":
		Console.WriteLine("You selected Subtraction Game.");
		break;
	case "m":
		Console.WriteLine("You selected Multiplication Game.");
		break;
	case "d":
		Console.WriteLine("You selected Division Game.");
		break;
	case "r":
		Console.WriteLine("You selected Random Game.");
		break;
	case "q":
		Console.WriteLine("You selected quit the game.");
		break;
	default:
		Console.WriteLine("Invalid Input");
		break;
}


// Addition Game

// Subtraction Game

// Multiplication Game

// Divsion Game