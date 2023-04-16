namespace MathGame.barakisbrown.Problems;

internal class Subtraction : IProblem
{
    private readonly Random _random = new();
    Model IProblem.Calc(Diffuclty_Levels levels)
    {
        Console.WriteLine("This is a subtraction problem");
        return null;
    }
}
