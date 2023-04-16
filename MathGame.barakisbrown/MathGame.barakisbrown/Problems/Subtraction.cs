namespace MathGame.barakisbrown.Problems;

internal class Subtraction : IProblem
{
    private readonly Random _random = new();
    Model IProblem.Calc()
    {
        Console.WriteLine("This is a subtraction problem");
        return null;
    }
}
