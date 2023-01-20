namespace MathGame.Validations;

public class InputValidation
{
    public bool ValidateInput(string choice)
    {
        return !string.IsNullOrWhiteSpace(choice);
    }

    public bool ValidateChoice(string input, out int choice)
    {
        choice = -1;
        return !string.IsNullOrWhiteSpace(input) && int.TryParse(input, out choice);
    }
}
