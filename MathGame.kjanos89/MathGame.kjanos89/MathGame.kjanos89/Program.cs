using System.Linq.Expressions;

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
        string selection = Console.ReadLine();
        char firstChar = selection[0];
        Console.WriteLine(GameSelected(firstChar));
    }

    public static string GameSelected(char selected)
    {
        string result = "";
        switch (selected)
        {
            case 'A':
                result = "You chose Addition.";
                break;
            case 'S':
                result = "You chose Subtraction.";
                break;
            case 'M':
                result = "You chose Multiplication.";
                break;
            case 'D':
                result = "You chose Division.";
                break;
            case 'Q':
                result = "Program closes. Hope to see you soon!";
                break;

            default:
                result = "Wrong input, please choose from the menu.";
                break;
        }
        return result;
    }


}






