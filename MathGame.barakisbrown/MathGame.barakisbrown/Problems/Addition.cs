namespace MathGame.barakisbrown.Problems;

internal class Addition : IProblem
{
    private readonly Random _random = new();

    Model IProblem.Calc()
    {
        Console.WriteLine("Doing Additional Problem");
        return null;
    }
}
