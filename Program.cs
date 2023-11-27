namespace Branch_Console;

class Program
{
    static void Main(string[] args)
    {
        var context = new Context(new SetName());

        var isGameOn = context.GetGameOn();

        while (isGameOn)
        {
            context.SetUpConsole();
            context.ProcessInput();
            isGameOn = context.GetGameOn();
        }
        Console.Clear();
        Console.WriteLine("Thank you for playing");
    }
}