using System.ComponentModel.DataAnnotations;

namespace MathGame;

internal class UserInput
{
    internal static int GetAnswer()
    {
        string input = Console.ReadLine();
        while (!Validator.IsValidInteger(input))
        {
            Console.Write("\nThis is not a valid input. Please enter a number: ");
            input = Console.ReadLine();
        }
        return Int32.Parse(input);
    }

    internal static string GetUserOption()
    {
        string input = Console.ReadLine();
        while (!Validator.IsValidOption(input))
        {
            Console.Write("\nThis is not a valid input. Please enter one of the above options: ");
            input = Console.ReadLine();
        }
        return input;
    }
}