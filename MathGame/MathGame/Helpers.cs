namespace MathGame;

internal class Helpers
{
    internal static string GetName()
    {
        Console.WriteLine("Please enter a name for the game");
        return Console.ReadLine();
    }
}