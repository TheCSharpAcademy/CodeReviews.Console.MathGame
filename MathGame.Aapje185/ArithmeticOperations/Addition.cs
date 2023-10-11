namespace C_Sharp_Academy.ArithmeticOperations;

public class Addition : IArithmeticOperation
{
    public string OperationMessage => "Addition game";
    public char ArithmeticOperator => '+';

    public int PerformOperation(int int1, int int2)
    {
        return int1 + int2;
    }
}