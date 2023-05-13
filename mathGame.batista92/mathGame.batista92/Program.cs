namespace mathGame.batista92;

internal class Program
{
    static void Main(string[] args)
    {
        DateTime date = DateTime.UtcNow;

        var menu = new Menu();

        string name = GetName();

        menu.ShowMenu(name, date);

        string GetName()
        {
            Console.Clear();
            Console.WriteLine("Please type your name");
            string name = Console.ReadLine();
            return name;
        }
    }
}