class MathGameAppConsole
{
    static void Main()
    {
        Console.WriteLine("Welcome to MathGame!");

        var callGame = new MathGame();
        Console.WriteLine($"Thanks for playing {callGame}!");
        Console.ReadLine();
    }
}