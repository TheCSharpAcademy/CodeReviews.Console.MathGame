namespace SinghxRaj.MathGame.MathGame;

internal class DivideGame : MathGame
{

    public override double Compute(int operand1, int operand2)
    {
        if (operand2 == 0)
        {
            return double.NaN;
        }
        return operand1 / (operand2 * 1.0);
    }

    public override string GetOperator()
    {
        return "/";
    }
}
