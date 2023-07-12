using Math_Game_lib;

internal class Program
{
    private static void Main()
    {
        DateTime date = DateTime.UtcNow;
        string name = Helpers.GetName();

        Helpers.Greeting(name, date);

        Menu.MainMenu();
    }
}