namespace MathGame.Mateusz_Platek;

public static class Menu
{
    private static int GetInput()
    {
        string? input = Console.ReadLine();

        if (int.TryParse(input, out int number))
        {
            return number;
        }
        
        return 0;
    }

    public static int GetNumberOfQuestions()
    {
        Console.WriteLine("Choose number of questions:");

        return GetInput();
    }

    public static int GetDifficultyLevel()
    {
        Console.WriteLine("Choose difficulty level:");
        Console.WriteLine("1 - Easy");
        Console.WriteLine("2 - Medium");
        Console.WriteLine("3 - Hard");

        return GetInput();
    }
    
    public static int GetOperation()
    {
        Console.WriteLine("Choose operation:");
        Console.WriteLine("1 - Addition");
        Console.WriteLine("2 - Subtraction");
        Console.WriteLine("3 - Multiplication");
        Console.WriteLine("4 - Division");
        
        return GetInput();
    }

    public static int GetRoundType()
    {
        Console.WriteLine("Choose round type:");
        Console.WriteLine("1 - Play round");
        Console.WriteLine("2 - Play random round");
        
        return GetInput();
    }

    public static int GetOption()
    {
        Console.WriteLine("Choose option:");
        Console.WriteLine("1 - Play round");
        Console.WriteLine("2 - Play random round");
        Console.WriteLine("3 - Play many rounds");
        Console.WriteLine("4 - View history");
        Console.WriteLine("5 - Difficulty level");
        Console.WriteLine("6 - Exit");
        
        return GetInput();
    }
}