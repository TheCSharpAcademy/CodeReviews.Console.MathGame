namespace jcast24.MathGame;

public class Helper
{
    internal static string ValidateInput(string? result)
    {
        while (string.IsNullOrEmpty(result)|| !int.TryParse(result, out _))
        {
            Console.WriteLine("Your answer needs to be an integer. Please try again: ");
            Console.ReadLine();
        }
        return result;
    }
}