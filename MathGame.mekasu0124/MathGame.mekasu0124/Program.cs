namespace MathGame.mekasu0124;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome To The Math Game!\n");
        
        string username = GetUsername();
        DateTime date = DateTime.Now;
        
        GameMenu.ShowMenu(username, date);
    }

    private static string GetUsername()
    {
        Console.Write("Create A Username: ");

        string username = Console.ReadLine();
        username = Helpers.ValidateUsernameInput(username);

        return username;
    }
}