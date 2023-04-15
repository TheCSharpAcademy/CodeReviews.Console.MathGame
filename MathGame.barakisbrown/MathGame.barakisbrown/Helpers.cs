namespace MathGame.barakisbrown;

internal class Helpers
{
    internal static string ValidateResults(string result, string prompt)
    {
        while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
        {
            Console.WriteLine("Your answer needs to be an integer. Try Again.");
            Console.Write(prompt);
            result = Console.ReadLine();
        }
        return result;
    }
}
