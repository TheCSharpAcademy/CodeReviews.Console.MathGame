using MathGame.kjanos89;
using System.Linq.Expressions;

public class Program
{
    int points = 0;
    static void Main(string[] args)
    {
        Console.WriteLine("Hello! Please type in your name below:");
        GameData.Name = Console.ReadLine();
        Start start = new Start();
        start.StartMenu();
    }
    public void QuitGame()
    {
        Console.Clear();
        Console.WriteLine("Bye-Bye!");
        Environment.Exit(2);
    }


}






