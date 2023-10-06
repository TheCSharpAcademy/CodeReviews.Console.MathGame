using MathGame.Cactus;

class Program
{
    static void Main(string[] args)
    {
        // user information
        Console.WriteLine("Please type your name");
        var username = Console.ReadLine();
        var date = DateTime.UtcNow;
        
        // start game
        var game = new Game(username, date);
        game.Run();
    }
}
