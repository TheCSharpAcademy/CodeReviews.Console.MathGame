namespace MathGame;

internal class Multiplication : Operation
{
    public Multiplication(Difficulty difficulty) : base(difficulty) { }

    public override int PerformOperation()
    {
        return FirstOperand * SecondOperand;
    }

    public override string ToString()
    {
        return $"{FirstOperand} * {SecondOperand}";
    }
}
