public class Program
{
    static void Main(string[] args)
    {
        Start();


    }

    static void Start()
    {
        Console.WriteLine("__________________________________________________________________");
        Console.WriteLine("Hello! Choose an option from the menu below by pressing the proper key:");
        Console.WriteLine("A - Addition");
        Console.WriteLine("S - Subtraction");
        Console.WriteLine("M - Multiplication");
        Console.WriteLine("D - Division");
        Console.WriteLine("Q - Quit the program");
        Console.WriteLine("__________________________________________________________________");
        var selection = Console.ReadLine();
    }

    public void GameSelected(char selected)
    {

    }


}






