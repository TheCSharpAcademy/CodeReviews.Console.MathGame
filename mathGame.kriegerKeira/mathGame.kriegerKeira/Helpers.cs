public static class Helpers
{
    public static string GetName()
    {
        Console.Write("Please enter your name: ");
        var name = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Name cannot be empty, press any key to try again");
            Console.ReadKey();
            Console.Clear();
            Console.Write("Please enter your name: ");
            name = Console.ReadLine();
            Console.Clear();
        }
        return name;

    }

}