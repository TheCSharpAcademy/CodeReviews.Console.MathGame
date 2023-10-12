namespace MathGame_CSA;

public static class KeyExtension
{
    public static bool TryParseToMathOperation(this char c, out MathOperation operation)
    {
        (bool success, operation) = c switch
        {
            '+' => (true, MathOperation.Addition),
            '-' => (true, MathOperation.Subtraction),
            '*' => (true, MathOperation.Multiplication),
            '/' => (true, MathOperation.Division),
            'r' or 'R' => (true, MathOperation.Random),
            _ => (false, MathOperation.Addition)
        };

        return success;
    }

    public static string ToOperatorString(this MathOperation op) =>
        op switch
        {
            MathOperation.Addition => "+",
            MathOperation.Subtraction => "-",
            MathOperation.Multiplication => "*",
            MathOperation.Division => "/",
            _ => throw new ArgumentOutOfRangeException(nameof(op)),
        };

    public static int Calculate(this MathOperation op, int firstOperand, int secondOperand) =>
        op switch
        {
            MathOperation.Addition => firstOperand + secondOperand,
            MathOperation.Subtraction => firstOperand - secondOperand,
            MathOperation.Multiplication => firstOperand * secondOperand,
            MathOperation.Division => firstOperand / secondOperand,
            _ => throw new ArgumentOutOfRangeException(nameof(op)),
        };
}
