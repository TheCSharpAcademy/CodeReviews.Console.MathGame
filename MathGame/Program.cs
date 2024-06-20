// Top Level Set-Up

string name = GetName();
var date = DateTime.Now;

Menu(name);

string GetName()
{
	Console.Write("Please enter your name: ");
	string? name = Console.ReadLine()!;
	return name;
}

// Menu
void Menu(string name)
{
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
}

// Addition Game
void AdditionGame(string message)
{
	Console.WriteLine(message);

	Random random = new Random();
	int firstNumber;
	int secondNumber;
	int score = 0;

	for (int i = 0; i < 5; i++)
	{
		firstNumber = random.Next(1, 11);
		secondNumber = random.Next(1, 11);
		Console.Write($"{firstNumber} + {secondNumber} = ");
		string? result = Console.ReadLine();

		if (int.Parse(result!) == firstNumber + secondNumber)
		{
			Console.WriteLine("Correct!");
			score++;
		}
		else
		{
			Console.WriteLine("Bzzzt!!! Incorrect!");
		}
	}

	Console.WriteLine($"Game over. Your score is {score} ({(score / 5.0):P2})");
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
