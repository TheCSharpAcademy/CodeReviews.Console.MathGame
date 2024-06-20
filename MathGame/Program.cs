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
	bool firstRun = true;
	bool playGame = true;
	do
	{
		if (!firstRun)
			Console.Clear();
		firstRun = false;
		Console.WriteLine($@"Please select a game to play from the list below:
A - Addition
S - Subtraction
M - Multiplication
D - Division
R - Random
Q - Quit");
		Console.WriteLine("------------------------------------------------------");
		Console.Write("Game Selection: ");

		string? gameSelected = Console.ReadLine();
		if (gameSelected != null)
			switch (gameSelected.Trim().ToLower())
			{
				case "a":
					AdditionGame("Addition Game");
					break;
				case "s":
					SubtractionGame("Subtraction Game");
					break;
				case "m":
					MultiplicationGame("Multiplication Game");
					break;
				case "d":
					DivisionGame("Division Game");
					break;
				case "r":
					RandomGame("Random Game");
					break;
				case "q":
					Console.WriteLine("You selected quit the game.");
					playGame = false;

					break;
				default:
					Console.WriteLine("Invalid Input. Press any key to select a valid entry.");
					Console.ReadLine();

					break;
			}
	} while (playGame);
}

// Addition Game
void AdditionGame(string message)
{

	Random random = new Random();
	int firstNumber;
	int secondNumber;
	int score = 0;

	for (int i = 0; i < 5; i++)
	{
		Console.Clear();
		Console.WriteLine(message + $" (Question {i + 1})");
		firstNumber = random.Next(1, 11);
		secondNumber = random.Next(1, 11);
		Console.Write($"{firstNumber} + {secondNumber} = ");
		string? result = Console.ReadLine();

		if (int.Parse(result!) == firstNumber + secondNumber)
		{
			Console.WriteLine("Correct! Press any key for next question.");
			score++;
			Console.ReadLine();
		}
		else
		{
			Console.WriteLine("Bzzzt!!! Incorrect! Press any key for next question.");
			Console.ReadLine();
		}
	}

	Console.WriteLine($"Game over. Your score is {score} ({(score / 5.0):P2})");
	Console.Write("Press any key to return to main menu.");
	Console.ReadLine();
}

// Subtraction Game
void SubtractionGame(string message)
{

	Random random = new Random();
	int firstNumber;
	int secondNumber;
	int score = 0;

	for (int i = 0; i < 5; i++)
	{
		Console.Clear();
		Console.WriteLine(message + $" (Question {i + 1})");
		firstNumber = random.Next(1, 11);
		secondNumber = random.Next(1, 11);
		Console.Write($"{firstNumber} - {secondNumber} = ");
		string? result = Console.ReadLine();

		if (int.Parse(result!) == firstNumber - secondNumber)
		{
			Console.WriteLine("Correct! Press any key for next question.");
			score++;
			Console.ReadLine();
		}
		else
		{
			Console.WriteLine("Bzzzt!!! Incorrect! Press any key for next question.");
			Console.ReadLine();
		}
	}

	Console.WriteLine($"Game over. Your score is {score} ({(score / 5.0):P2})");
	Console.Write("Press any key to return to main menu.");
	Console.ReadLine();
}

// Multiplication Game
void MultiplicationGame(string message)
{

	Random random = new Random();
	int firstNumber;
	int secondNumber;
	int score = 0;

	for (int i = 0; i < 5; i++)
	{
		Console.Clear();
		Console.WriteLine(message + $" (Question {i + 1})");
		firstNumber = random.Next(1, 11);
		secondNumber = random.Next(1, 11);
		Console.Write($"{firstNumber} x {secondNumber} = ");
		string? result = Console.ReadLine();

		if (int.Parse(result!) == firstNumber * secondNumber)
		{
			Console.WriteLine("Correct! Press any key for next question.");
			score++;
			Console.ReadLine();
		}
		else
		{
			Console.WriteLine("Bzzzt!!! Incorrect! Press any key for next question.");
			Console.ReadLine();
		}
	}

	Console.WriteLine($"Game over. Your score is {score} ({(score / 5.0):P2})");
	Console.Write("Press any key to return to main menu.");
	Console.ReadLine();
}

// Divsion Game
void DivisionGame(string message)
{


	int score = 0;

	for (int i = 0; i < 5; i++)
	{
		Console.Clear();
		Console.WriteLine(message + $" (Question {i + 1})");
		int[] divisionNumbers = GetDivisionNumbers();
		int firstNumber = divisionNumbers[0];
		int secondNumber = divisionNumbers[1];

		Console.Write($"{firstNumber} / {secondNumber} = ");
		string? result = Console.ReadLine();

		if (int.Parse(result!) == firstNumber / secondNumber)
		{
			Console.WriteLine("Correct! Press any key for next question.");
			score++;
			Console.ReadLine();
		}
		else
		{
			Console.WriteLine("Bzzzt!!! Incorrect! Press any key for next question.");
			Console.ReadLine();
		}
	}

	Console.WriteLine($"Game over. Your score is {score} ({(score / 5.0):P2})");
	Console.Write("Press any key to return to main menu.");
	Console.ReadLine();

}

int[] GetDivisionNumbers()
{
	Random random = new Random();
	int[] result = new int[2];

	result[0] = random.Next(1, 101);
	result[1] = random.Next(1, 101);

	while (result[0] % result[1] != 0)
	{
		result[0] = random.Next(1, 101);
		result[1] = random.Next(1, 101);
	}

	return result;
}

// Random Game
void RandomGame(string message)
{
	Console.WriteLine(message);
}
