namespace MathGame;

public class Menu
{
	public static void ShowMenu()
	{
        Console.WriteLine("Welcome to the math game. Choose any operation you'd like:");

        foreach(Operation op in Helper.GetAllOperations())
		{
            Console.Write(op.Symbol.PadRight(10));
            Console.WriteLine(op.Name);
        }
    }

	public static void ShowInputs(int firstNum, string? op, int secondNum)
	{
        Console.WriteLine($"{firstNum} {op} {secondNum} is:");
    }
}
