namespace MathGame.frockett;

internal class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();

        DateTime date = DateTime.UtcNow;

        menu.ShowMenu(date);
    }


}