namespace MathGame;

internal static class Program
{
    static void Main()
    {
        var game = new Gameplay();
        game.MainMenu();
        Console.WriteLine("\n\nThanks for playing!");
    }
}