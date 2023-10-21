namespace MathGame;

public class Helper
{
	public static List<Operator> GetAllOperators()
	{
		return new List<Operator>(){
			new Operator("+", "Addition"),
			new Operator("-", "Subtraction"),
			new Operator("*", "Multiplication"),
			new Operator("/", "Division"),
		};
	}

	public static int GetNumberInput(string text = "Enter a number: ")
	{
		string? userInput;
		int result;
		do
		{
			Console.WriteLine(text);
			userInput = Console.ReadLine();
		}
		while (!int.TryParse(userInput, out result));

		return result;
	}

	public static int GetDifficultyInput()
	{
		int input;
		do
		{
			input = GetNumberInput("Enter difficulty level: (1-3)");
		} while (input < (int)Difficulty.Easy || input > (int)Difficulty.Hard);

		return input;
	}

	public static int GetRandomNumber(Difficulty? difficulty = null)
	{
		Random rnd = new Random();

		switch(difficulty)
		{
			case Difficulty.Easy:
				return rnd.Next(1, 30);
			case Difficulty.Medium:
				return rnd.Next(30, 60);
			case Difficulty.Hard:
				return rnd.Next(60, 100);
			default:
				return rnd.Next(0, 101);
		}
	}

	public static void ModifyNumbersForDivision(ref int firstNum, ref int secondNum, Difficulty difficulty)
	{
		while(firstNum < secondNum || secondNum == 0 || firstNum % secondNum != 0)
		{
			firstNum = GetRandomNumber(difficulty);
			secondNum = GetRandomNumber();
		}
	}
}
