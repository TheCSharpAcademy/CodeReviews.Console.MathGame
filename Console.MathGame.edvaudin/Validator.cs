namespace MathGame;

internal class Validator
{
    internal static bool IsValidOption(string? input)
    {
        string[] validOptions = { "a", "s", "m", "d", "h", "0" };
        foreach (string validOption in validOptions)
        {
            if (input == validOption)
            {
                return true;
            }
        }
        return false;
    }

    internal static bool IsValidInteger(string? input)
    {
        return !string.IsNullOrWhiteSpace(input) && Int32.TryParse(input, out int _);
    }
}
