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
}

