namespace MiroiuDev.MathGame;

internal class Games
{
    internal static int AdditionGame((int, int) numbers)
    {
        Console.WriteLine($"{numbers.Item1} + {numbers.Item2}");

        return numbers.Item1 + numbers.Item2;
    }
    internal static int SubstractionGame((int, int) numbers)
    {
        Console.WriteLine($"{numbers.Item1} - {numbers.Item2}");

        return numbers.Item1 - numbers.Item2;
    }

    internal static int MultiplicationGame((int, int) numbers)
    {
        Console.WriteLine($"{numbers.Item1} * {numbers.Item2}");

        return numbers.Item1 * numbers.Item2;
    }
    internal static int DivisionGame((int, int) numbers)
    {
        Console.WriteLine($"{numbers.Item1} / {numbers.Item2}");

        return numbers.Item1 / numbers.Item2;
    }
    internal static int RandomGame((int, int) numbers)
    {
        var random = new Random();

        var choice = random.Next(1, 4);

        switch (choice)
        {
            case 1:
                Console.WriteLine($"{numbers.Item1} + {numbers.Item2}");
                return numbers.Item1 + numbers.Item2;
            case 2:
                Console.WriteLine($"{numbers.Item1} - {numbers.Item2}");
                return numbers.Item1 - numbers.Item2;
            case 3:
                Console.WriteLine($"{numbers.Item1} * {numbers.Item2}");
                return numbers.Item1 * numbers.Item2;
            case 4:
                Console.WriteLine($"{numbers.Item1} / {numbers.Item2}");
                return numbers.Item1 / numbers.Item2;
            default:
                throw new InvalidOperationException("Unknown operation");
        }
    }
}
