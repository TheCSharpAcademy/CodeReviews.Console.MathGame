using MathGame.kjanos89;
public class Program
{
    static void Main(string[] args)
    {
        //Asking for name, setting it in the static GameData class and initializing points variable
        Console.WriteLine("Hello! Please type in your name below:");
        GameData.Name = Console.ReadLine();
        GameData.Points = 0;
        //Immediately showing the Main Menu with its object
        Start start = new Start();
        start.StartMenu();
    }
}
