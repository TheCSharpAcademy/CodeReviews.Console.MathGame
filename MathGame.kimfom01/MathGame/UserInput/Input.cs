using MathGame.Validations;

namespace MathGame.UserInput;

public class Input
{
    private InputValidation _validation = new();

    public int GetChoice()
    {
        Console.Write("Enter your choice: ");
        var input = Console.ReadLine();
        int choice;
        while (!_validation.ValidateChoice(input, out choice))
        {
            Console.Write("Enter your choice: ");
            input = Console.ReadLine();
        }

        return choice;
    }

    public string GetInput()
    {
        Console.Write("Type your input: ");
        var input = Console.ReadLine();
        while (!_validation.ValidateInput(input))
        {
            Console.WriteLine("Error! Invalid entry");
            Console.Write("Enter again: ");
            input = Console.ReadLine();
        }

        return input;
    }
}
