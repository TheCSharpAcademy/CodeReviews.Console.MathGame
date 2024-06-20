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
			AdditionGame("You selected Addition Game.");
			break;
		case "s":
			SubtractionGame("You selected Subtraction Game.");
			break;
		case "m":
			MultiplicationGame("You selected Multiplication Game.");
			break;
		case "d":
			DivisionGame("You selected Division Game.");
			break;
		case "r":
			RandomGame("You selected Random Game.");
			break;
		case "q":
			Console.WriteLine("You selected quit the game.");
			Environment.Exit(0);
			break;
		default:
			Console.WriteLine("Invalid Input");
			Environment.Exit(0);
			break;
	}



// Addition Game
void AdditionGame(string message)
{
	Console.WriteLine(message);
}

// Subtraction Game
void SubtractionGame(string message)
{
	Console.WriteLine(message);
}

// Multiplication Game
void MultiplicationGame(string message)
{

	Console.WriteLine(message);
}

// Divsion Game
void DivisionGame(string message)
{
	Console.WriteLine(message);

}

// Random Game
void RandomGame(string message)
{
	Console.WriteLine(message);
}
