namespace MathGame;

public static class MessageHandler
{
    public static void WelcomeMessage(string userName)
    {
        Console.WriteLine($"Hello {userName}. Welcome to Math's game.");
    }

    public static void DisplayOperation(int[] operands ,string operatorSymbol)
    {
        Console.Write($"{operands[0]} {operatorSymbol} {operands[1]} = ");
    }

    public static void PrintScore(int score)
    {
        Console.WriteLine($"Your score is {score}");
    }

    public static void AskToContinueToMenu()
    {
        Console.WriteLine("\nPress any key to proceed to the Menu.");
        Console.ReadLine();
        Console.Clear();
    }
}

