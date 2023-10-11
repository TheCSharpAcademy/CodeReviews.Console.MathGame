namespace C_Sharp_Academy.ArithmeticOperations;

public class Subtraction : IArithmeticOperation
{
    public string OperationMessage => "Subtraction game";
    public char ArithmeticOperator => '-';
    public int PerformOperation(int int1, int int2)
    {
        return int1 - int2;
    }
}