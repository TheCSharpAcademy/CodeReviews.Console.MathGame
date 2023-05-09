namespace mathGame.batista92;

internal class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Please type your name");

        string name = Console.ReadLine();
        DateTime date = DateTime.UtcNow;

        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine($"Hello {name.ToUpper()}. It's {date}. This is your math's game. That's great that you're working on improving yourself");
        Console.WriteLine();
        Console.WriteLine($@"What game would you like to play today? Choose from the options below:
A - Addition
S - Subtraction
M - Multiplication
D - Division
Q - Quit the program");
        Console.WriteLine("---------------------------------------------------");

        string gameSelected = Console.ReadLine();
        switch (gameSelected.Trim())
        {
            case "a":
                Console.WriteLine("Addition Game Selected");
                break;
        }

    }
}