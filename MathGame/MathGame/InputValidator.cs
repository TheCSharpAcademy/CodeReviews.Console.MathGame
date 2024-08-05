namespace MathGame;

internal static class InputValidator
{
    public static (bool, Options) MenuValidator(string? input)
    {
        Options optionSelected = Options.Unknown;
        if (input == null) return (false, optionSelected);

        if (Options.TryParse<Options>(input.Trim(), out optionSelected) && Enum.IsDefined(typeof(Options), optionSelected))
        {
            return (true, optionSelected);
        }

        return (false, optionSelected);
    }

    public static (bool, Difficulty) DifficultyValidator(string? input)
    {
        Difficulty difficulty = new Difficulty();
        if (input == null) return (false, difficulty);

        if (Difficulty.TryParse<Difficulty>(input.Trim(), out difficulty) && Enum.IsDefined(typeof(Difficulty), difficulty))
        {
            return (true, difficulty);
        }

        return (false, difficulty);
    }

    public static (bool, int) NumericInputValidator(string? input)
    {
        if (input == null) return (false, -1);
        if (int.TryParse(input,out int result))
        {
            return (true, result);
        }

        return (false, -1);
    }

    public static bool OperationValidator(Operation operation, int userAnswer)
    {
        return operation.PerformOperation() == userAnswer;
    }
}
