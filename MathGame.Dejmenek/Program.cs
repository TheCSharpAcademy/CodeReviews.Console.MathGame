using MathGame.Dejmenek;
internal class Program
{
    public static void Main()
    {
        Menu menu = new();
        Console.WriteLine("Welcome to the Math Game!");
        do
        {
            Menu.ShowMenu();
            menu.SelectMenuOption();
        }
        while (!menu.Exit);
    }
}