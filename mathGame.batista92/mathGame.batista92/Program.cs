namespace mathGame.batista92;

internal class Program
{
    static void Main(string[] args)
    {
        DateTime date = DateTime.UtcNow;

        var menu = new Menu();

        string name = Helpers.GetName();

        menu.ShowMenu(name, date);
    }
}