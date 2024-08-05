namespace MathGame;

internal class Addition : Operation
{
    public Addition(Difficulty difficulty) : base(difficulty) { }

    public override int PerformOperation()
    {
        return FirstOperand + SecondOperand;
    }

    public override string ToString()
    {
        return $"{FirstOperand} + {SecondOperand}";
    }
}
