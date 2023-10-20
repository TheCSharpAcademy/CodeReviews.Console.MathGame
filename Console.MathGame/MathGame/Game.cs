namespace MathGame;

public class Game
{
	public static void Start()
	{
		Menu.ShowMenu();
		Menu.ShowInputs(GetUserInput(), GetOperator(), GetUserInput());
    }

	private static int GetUserInput()
	{
		string? userInput;
		int result;
		do
		{
			Console.WriteLine("Enter a number: ");
			userInput = Console.ReadLine();
		}
		while (!int.TryParse(userInput, out result));

		return result;
    }

	private static string? GetOperator()
	{
		string? userOperator;
		do
		{
			Console.WriteLine("Enter an operator: (+, -, *, /)");
			userOperator = Console.ReadLine();
		} while (!Helper.GetAllOperations().Any(op => op.Symbol == userOperator));

		return userOperator;
	}

	private static int GetRandomNumber()
	{
		return new Random().Next(0, 101);
	}
}
