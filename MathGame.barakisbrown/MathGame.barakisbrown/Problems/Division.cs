namespace MathGame.barakisbrown.Problems;

internal class Division : IProblem
{
    private readonly Random _random = new();
    Model IProblem.Calc()
    {
        Console.WriteLine("Division Problem");
        return null;
    }
}
