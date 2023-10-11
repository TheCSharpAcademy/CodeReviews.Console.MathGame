namespace C_Sharp_Academy.ArithmeticOperations;

public class Multiplication : IArithmeticOperation
{
    public string OperationMessage => "Multiplication game";
    public char ArithmeticOperator => '*';
    public int PerformOperation(int int1, int int2)
    {
        return int1 * int2;
    }
}