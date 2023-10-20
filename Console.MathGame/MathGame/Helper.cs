namespace MathGame;

public class Helper
{
	public static List<Operation> GetAllOperations()
	{
		return new List<Operation>(){
			new Operation("+", "Addition"),
			new Operation("-", "Subtraction"),
			new Operation("*", "Multiplication"),
			new Operation("/", "Division"),
		};
	}

	public static int GetUserInput()
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

	public static int GetRandomNumber()
	{
		return new Random().Next(101);
	}

	public static void ModifyNumbersForDivision(ref int firstNum, ref int secondNum)
	{
		while(firstNum < secondNum || secondNum == 0 || firstNum % secondNum != 0)
		{
			firstNum = GetRandomNumber();
			secondNum = GetRandomNumber();
		}
	}
}
