MathGame game = new();

Addition addition = new();
Subtraction subtraction = new();
Multiplication multiplication = new();
Division division = new();

while (true)
{
    game.Main(addition, subtraction, multiplication, division);
}
public class MathGame
{
    
    public void Main(Addition addition, Subtraction subtraction, Multiplication multiplication, Division division)
    {       

        DisplayMenu();
        int number1 = GetRandomNumber();
        int number2 = GetRandomNumber();

        int gameChoice = UserInput("Input: ");
        switch (gameChoice)
        {
            case 1:
                addition.AdditionGame(number1, number2);
                break;
            case 2:
                subtraction.SubtractionGame(number1, number2);
                break;
            case 3:
                multiplication.MultiplicationGame(number1, number2);
                break;
            case 4:
                division.DivisionGame(number1, number2);
                break;
            case 5:
                DisplayGameHistory(addition, subtraction, multiplication, division);
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }
    
    public int UserInput(string text)
    {
        Console.Write(text);
        return Convert.ToInt32(Console.ReadLine());
    }

    public int GetRandomNumber()
    {
        Random random = new();
        return random.Next(0, 100);
    }

    private static void DisplayMenu()
    {
        Console.WriteLine("""
            Please make a selection from the following:

            1. Addition
            2. Subtraction
            3. Multiplication
            4. Division
            5. Game History
            6. End Game
            """);
    }
    private void DisplayGameHistory(Addition addition, Subtraction subtraction, Multiplication multiplication, Division division)
    {
        Console.WriteLine($"Addition: {addition.CorrectAnswers} Correct, {addition.IncorrectAnswers} Incorrect.");
        Console.WriteLine($"Subtraction: {subtraction.CorrectAnswers} Correct, {subtraction.IncorrectAnswers} Incorrect.");
        Console.WriteLine($"Multiplication: {multiplication.CorrectAnswers} Correct, {multiplication.IncorrectAnswers} Incorrect.");
        Console.WriteLine($"Division: {division.CorrectAnswers} Correct, {division.IncorrectAnswers} Incorrect.");
        Console.Write("Press any key to return.");
        Console.ReadKey();
    }
}

public class Addition
{
    MathGame userInput = new();
    public int CorrectAnswers { get; private set; }
    public int IncorrectAnswers { get; private set; }

    public int AdditionGame(int number1, int number2)
    {
        int correctAdditionAnswer = number1 + number2;
        int guessedAdditionAnswer = userInput.UserInput($"{number1} + {number2}: ");

        if (correctAdditionAnswer == guessedAdditionAnswer)
        {
            Console.WriteLine("That is correct!");
            return CorrectAnswers++;
        }
        else
        {
            Console.WriteLine("Sorry, that is incorrect.");
            return IncorrectAnswers++;
        }
    }
}

public class Subtraction
{
    MathGame userInput = new();
    public int CorrectAnswers { get; private set; }
    public int IncorrectAnswers { get; private set; }

    public int SubtractionGame(int number1, int number2)
    {
        int correctSubtractionAnswer = number1 - number2;
        int guessedSubtractionAnswer = userInput.UserInput($"{number1} - {number2}: ");

        if (correctSubtractionAnswer == guessedSubtractionAnswer)
        {
            Console.WriteLine("That is correct!");
            return CorrectAnswers++;
        }
        else
        {
            Console.WriteLine("Sorry, that is incorrect.");
            return IncorrectAnswers++;
        }
    }
}

public class Multiplication
{
    MathGame userInput = new();
    public int CorrectAnswers { get; private set; }
    public int IncorrectAnswers { get; private set; }

    public int MultiplicationGame(int number1, int number2)
    {
        int correctMultiplicationAnswer = number1 * number2;
        int guessedMultiplicationAnswer = userInput.UserInput($"{number1} x {number2}: ");

        if (correctMultiplicationAnswer == guessedMultiplicationAnswer)
        {
            Console.WriteLine("That is correct!");
            return CorrectAnswers++;
        }
        else
        {
            Console.WriteLine("Sorry, that is incorrect.");
            return IncorrectAnswers++;
        }
    }
}

public class Division
{
    MathGame userInput = new();
    public int CorrectAnswers { get; private set; }
    public int IncorrectAnswers { get; private set; }

    public int DivisionGame(int number1, int number2)
    {
        int validatedNumberOne = number1;
        int validatedNumberTwo = number2;
        MathGame random = new();

        if (validatedNumberTwo == 0)
        {
            do
            {
                validatedNumberTwo = random.GetRandomNumber();
            } while (validatedNumberTwo == 0);
        }
        do
        {
            if (!ValidateDivision(validatedNumberOne, validatedNumberTwo))
            {
                validatedNumberOne = random.GetRandomNumber();
                validatedNumberTwo = random.GetRandomNumber();
            }
        } while (!ValidateDivision(validatedNumberOne, validatedNumberTwo));

        int correctDivisionAnswer = validatedNumberOne / validatedNumberTwo;
        int guessedDivisionAnswer = userInput.UserInput($"{validatedNumberOne} / {validatedNumberTwo}: ");

        if (correctDivisionAnswer == guessedDivisionAnswer)
        {
            Console.WriteLine("That is correct!");
            return CorrectAnswers++;
        }
        else
        {
            Console.WriteLine("Sorry, that is incorrect.");
            return IncorrectAnswers++;
        }

    }

    public bool ValidateDivision(int number1, int number2)
    {
        if (number1 % number2 == 0)
        {
            return true;
        }
        return false;
    }

}