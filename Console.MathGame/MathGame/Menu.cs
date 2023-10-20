namespace MathGame;

public class Menu
{
	public static void ShowMenu()
	{
        Console.WriteLine("Welcome to the math game. Choose any operation you'd like:");
        Console.WriteLine("Any operator you choose, you will get 5 questions.");

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Press q to quit the game.");
		Console.ForegroundColor = ConsoleColor.White;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Press l to see history of all games.");
		Console.ForegroundColor = ConsoleColor.White;

		foreach (Operation op in Helper.GetAllOperations())
		{
            Console.Write(op.Symbol.PadRight(10));
            Console.WriteLine(op.Name);
        }
    }

    public static void ShowEquation(int firstNum, int secondNum, string? op)
    {
        Console.WriteLine($"{firstNum} {op} {secondNum} is:");
    }

    public static void ShowScore(int score, int questionsCount)
    {
        Console.WriteLine($"You've reached a score of: {score}/{questionsCount}");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Press any key to continue.");
		Console.ForegroundColor = ConsoleColor.White;

		Console.ReadKey();
        Console.Clear();
    }

    public static void ShowFeedbackCorrect()
    {
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine("Correct.");
		Console.ForegroundColor = ConsoleColor.White;
	}

    public static void ShowFeedbackWrong()
    {
		Console.ForegroundColor = ConsoleColor.Red;
		Console.WriteLine("Wrong.");
		Console.ForegroundColor = ConsoleColor.White;
	}

    public static void ShowHistory(List<History> gameHistory)
    {
		Console.WriteLine("\nHistory of all games:");
		foreach (History history in gameHistory)
        {
            Console.WriteLine($"{history.DateTime} [{history.Operator}] Score: {history.Score}");
        }
        Console.WriteLine();
    }
}
