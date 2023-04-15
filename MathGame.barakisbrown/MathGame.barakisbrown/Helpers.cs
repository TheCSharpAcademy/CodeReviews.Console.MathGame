namespace MathGame.barakisbrown;

internal class Helpers
{
    internal static string ValidateResults(string ?result, string prompt)
    {
        while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
        {
            Console.WriteLine("Your answer needs to be an integer. Try Again.");
            Console.Write(prompt);
            result = Console.ReadLine();
        }
        return result;
    }

    internal static string GetName()
    {
        Console.Write("Enter your name: ");
        string ?name = Console.ReadLine();

        while(string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Name can not be empty. Please try again.");
            name = Console.ReadLine();
        }
        return name;
    }
}
