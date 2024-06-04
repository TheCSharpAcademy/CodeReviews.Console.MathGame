using MathGame.kjanos89;
public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello! Please type in your name below:");
        GameData.Name = Console.ReadLine();
        Start start = new Start();
        start.StartMenu();
    }
}
