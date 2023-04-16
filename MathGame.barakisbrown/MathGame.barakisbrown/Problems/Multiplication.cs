namespace MathGame.barakisbrown.Problems;

internal class Multiplication : IProblem
{
    private readonly Random _random = new();
    Model IProblem.Calc()
    {
        Console.WriteLine("Multiple Problem");
        return null;
    }
}
