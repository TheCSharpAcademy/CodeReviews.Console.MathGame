namespace MathGame._4r73m190r0s;

internal class Helpers
{
    internal static string ValidateResult(string result)
    {
        while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
        {
            Console.WriteLine("Your answer needs to be an integer. Try again.");
            Console.Write("X = ");
            result = Console.ReadLine();    
        }
        return result;  
    }

    internal static int[] GetDivisionNumbers()
    {
        var random = new Random();
        int firstNumber = random.Next(1,99);
        int secondNumber = random.Next(1, 99);

        var numbers = new int[2];

        while (firstNumber % secondNumber != 0)
        {
            firstNumber = random.Next(1, 99);
            secondNumber = random.Next(1, 99);
        }

        numbers[0] = firstNumber;
        numbers[1] = secondNumber;
        return numbers;
    }

    internal static string GetName()
    {
        Console.WriteLine("Enter your name: ");
        var name = Console.ReadLine();
        while (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Name can't be empty.");
            name = Console.ReadLine();
        }
        return name;
    }

    internal static void GetGames()
    {
        Console.Clear();
        Console.WriteLine("Games History");
        Console.WriteLine("-------------");
        foreach (var game in GameEngine.games)
        {
            Console.WriteLine(game);
        }
        Console.WriteLine("-------------");
        Console.WriteLine("Press Any Key to Return to the Main Menu");
        Console.ReadLine();
    }
}
