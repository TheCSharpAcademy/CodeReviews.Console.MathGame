public static class Helpers
{
    public static string GetName()
    {
        Console.Write("Please enter your name: ");
        var name = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Name cannot be empty, press any key to try again");
            Console.ReadKey();
            Console.Clear();
            Console.Write("Please enter your name: ");
            name = Console.ReadLine();
            Console.Clear();
        }
        return name;

    }

    public static int[] GetDivisionNumbers()
    {
        var random = new Random();
        var firstNumber = random.Next(1, 99);
        var secondNumber = random.Next(1, 99);
        var result = new int[2];

        while (firstNumber % secondNumber != 0)
        {
            firstNumber = random.Next(1, 99);
            secondNumber = random.Next(1, 99);
        }
        result[0] = firstNumber;
        result[1] = secondNumber;
        return result;
    }

    public static string ValidateResult(string? result)
    {
        while (string.IsNullOrWhiteSpace(result) || !Int32.TryParse(result, out _))
        {
            Console.WriteLine("Invalid entry, please enter an integer");
            result = Console.ReadLine();
        }
        return result;
    }
}