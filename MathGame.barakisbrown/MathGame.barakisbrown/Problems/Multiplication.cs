namespace MathGame.barakisbrown.Problems;

internal class Multiplication : IProblem
{
    private readonly Random _random = new();
    Model IProblem.Calc(Diffuclty_Levels levels)
    {
        Console.WriteLine("Multiple Problem");
        return null;
    }
}
