using MathLibrary;

namespace Schnopsi.MathGame;

internal static class ConsoleInteractions
{
	internal static void ShowWelcomeMessage()
	{
		Console.WriteLine("Welcome to my MathGame!\n    - by Schnopsi");
		Console.WriteLine("-------------------------\n");
	}
	internal static string MainMenu()
	{
		ShowMainOptions();
		string userInput;
		bool isValidInput = false;
		do
		{
			string possibleInputs = "ASDMPE";
			userInput = Console.ReadLine().ToUpper();
			if (userInput.Length == 1 && possibleInputs.Contains(userInput))
			{
				isValidInput = true;
			}
			else
			{
				Console.Write("\nInvalid input!\nPlease enter a valid option: ");
			}
		} while (isValidInput == false);
		return userInput;
	}

	private static void ShowMainOptions()
	{
		Console.WriteLine("Choose one of:\n");
		Console.WriteLine("Add:      A");
		Console.WriteLine("Subtract: S");
		Console.WriteLine("Multiply: M");
		Console.WriteLine("Divide:   D");
		Console.WriteLine("\nShow list of previous calculations: P");
		Console.WriteLine("End program: E");
		Console.WriteLine("-------------------------\n");
		Console.Write("Your choise here: ");
	}

	private static int GetNumber(string numPos)
	{
		int userInputInt;
		bool isValidInput;
		do
		{
			Console.Write($"Please enter your {numPos} number: ");
			string userInputStr = Console.ReadLine();
			isValidInput = int.TryParse(userInputStr, out userInputInt);
			if (isValidInput == false)
			{
				Console.WriteLine("Invalid input!");
			}
		} while (isValidInput == false);
		return userInputInt;
	}

	private static void ShowResult(int firstNumber, int secondNumber, int resultNumber, string oper)
	{
		Console.Clear();
		Console.WriteLine($"The result of {firstNumber} {oper} {secondNumber} is {resultNumber}.");
		Console.WriteLine("\nPress enter to return to main menu.");
		Console.ReadKey();
		Console.Clear();
	}

	internal static void HandleAdd(List<string> calculations)
	{
		int firstNumber = GetNumber("first");
		int secondNumber = GetNumber("second");
		int resultNumber = MathOperations.Add(firstNumber, secondNumber);
		ShowResult(firstNumber, secondNumber, resultNumber, "+");
		calculations.Add($"{firstNumber} + {secondNumber} = {resultNumber}");
	}

	internal static void HandleSubtract(List<string> calculations)
	{
		int firstNumber = GetNumber("first");
		int secondNumber = GetNumber("second");
		int resultNumber = MathOperations.Subtact(firstNumber, secondNumber);
		ShowResult(firstNumber, secondNumber, resultNumber, "-");
		calculations.Add($"{firstNumber} - {secondNumber} = {resultNumber}");
	}

	internal static void HandleMultiply(List<string> calculations)
	{
		int firstNumber = GetNumber("first");
		int secondNumber = GetNumber("second");
		int resultNumber = MathOperations.Multiply(firstNumber, secondNumber);
		ShowResult(firstNumber, secondNumber, resultNumber, "*");
		calculations.Add($"{firstNumber} * {secondNumber} = {resultNumber}");
	}

	internal static void HandleDivide(List<string> calculations)
	{
		int firstNumber = GetNumber("first");
		int secondNumber = GetNumber("second");
		int resultNumber = MathOperations.Divide(firstNumber, secondNumber);
		ShowResult(firstNumber, secondNumber, resultNumber, "/");
		calculations.Add($"{firstNumber} / {secondNumber} = {resultNumber}");
	}

	internal static void ShowCalculations(List<string> calculations)
	{
		Console.Clear();
		Console.WriteLine("List of previous calculations:\n");
		if (calculations.Count == 0)
		{
			Console.WriteLine("There are no calculations yet.");
		}
		foreach (var item in calculations)
		{
			Console.WriteLine(item);
		}
		Console.WriteLine("\nPress enter to return to main menu.");
		Console.ReadKey();
		Console.Clear();
	}
}
