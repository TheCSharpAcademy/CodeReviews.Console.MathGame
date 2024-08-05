namespace MathGame;

internal class Subtraction : Operation
{
    public Subtraction(Difficulty difficulty) : base(difficulty) { }

    public override int PerformOperation()
    {
        return FirstOperand - SecondOperand;
    }

    public override string ToString()
    {
        return $"{FirstOperand} - {SecondOperand}";
    }
}
